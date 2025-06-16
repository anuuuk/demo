using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

//using System.Runtime.Remoting.Contexts;
using avta.Models;


namespace avta
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {

        private HotelManagementContext _context; //hotel_managementEntities();

        public Admin()
            {
                InitializeComponent();
                LoadUsers();
                _context = new HotelManagementContext();//hotel_managementEntities();
            LoadRoomsAndStatistics();

            }

            private async void LoadUsers()
            {
                using (var context = new HotelManagementContext())//hotel_managementEntities();
            {
                    var users = await context.Users.ToListAsync();
                    Users.ItemsSource = users;
                }
            }

            private async void AddUser_Click(object sender, RoutedEventArgs e)
            {
                var newUserWindow = new AddUserWindow();
            if (newUserWindow.ShowDialog() == true && newUserWindow.NewUser != null)
                {
                    var newUser = newUserWindow.NewUser;

                    using (var context = new HotelManagementContext())//hotel_managementEntities();
                {
                        if (await context.Users.AnyAsync(u => u.Username == newUser.Username))
                        {
                            MessageBox.Show("Пользователь с таким именем уже существует.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            try
                            {
                                context.Users.Add(newUser);
                                await context.SaveChangesAsync();
                            }
                            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
                            {
                                MessageBox.Show($"Ошибка при сохранении данных: {ex.InnerException?.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            LoadUsers();
                            MessageBox.Show("Пользователь успешно добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Добавление пользователя отменено.", "Отмена", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            private async void UnlockUser_Click(object sender, RoutedEventArgs e)
            {
                if (Users.SelectedItem is User selectedUser) //Users
                {
                    using (var context = new HotelManagementContext())//hotel_managementEntities();
                {
                        var users = await context.Users.FindAsync(selectedUser.Id);

                        if (users != null)
                        {
                            users.IsLocked = false;
                            users.LastLoginDate = null;
                            await context.SaveChangesAsync();
                            LoadUsers();
                            MessageBox.Show("Пользователь разблокирован", "Ура!", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выберите пользователя", "грусть", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            private async void Save_Click(object sender, RoutedEventArgs e)
            {
                using (var context = new HotelManagementContext())//hotel_managementEntities();
            {
                    foreach (var user in Users.ItemsSource as IEnumerable<User>) //Users
                {
                        var existingUser = await context.Users.FindAsync(user.Id);
                        if (existingUser != null)
                        {
                            existingUser.Role = user.Role;
                            existingUser.Username = user.Username;
                            existingUser.IsLocked = user.IsLocked;
}
                    }
                    await context.SaveChangesAsync();
                    LoadUsers();
                    MessageBox.Show("Изменения успешно сохранены", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

            private void LoadRoomsAndStatistics()
            {
                try
                {
                    var rooms = _context.Rooms.ToList();


                    int totalRooms = rooms.Count;
                    int occupiedRooms = rooms.Count(r => r.Status == "Занят");
                    double occupancyPercentage = totalRooms > 0 ? (double)occupiedRooms / totalRooms * 100 : 0;

                    OccupancyPercentageText.Text = $"Загрузка: {occupancyPercentage:F2}%";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            private void RefreshRooms_Click(object sender, RoutedEventArgs e)
            {
                LoadRoomsAndStatistics();
            }
        }
    }