using avta.Models;
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

namespace avta
{
    /// <summary>
    /// Логика взаимодействия для ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        private readonly int _userId;
        public ChangePasswordWindow(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string currentPassword = txtCurrentPassword.Password;
            string newPassword = txtNewPassword.Password;
            string confirmNewPassword = txtConfirmNewPassword.Password;

            if (string.IsNullOrWhiteSpace(currentPassword) || string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmNewPassword) )
            {
                MessageBox.Show("Все поля обязательны для заполнения.");
                return;
            }

            if (newPassword != confirmNewPassword)
            {
                MessageBox.Show("Новый пароль и подтверждение не совпадают.");
                return;
            }

            try
            {
                using (var context = new HotelManagementContext())
                {
                    var user = context.Users.FirstOrDefault(x => x.Id == _userId);

                    if (user == null)
                    {
                        MessageBox.Show("Пользователь не найден");
                        return;
                    }

                    if (user.Password != currentPassword)
                    {
                        MessageBox.Show("Текущий пароль не верен.");
                        return;
                    }

                    user.Password = newPassword;
                    user.IsFirstLogin = false;

                    context.SaveChanges();

                    MessageBox.Show("Пароль успешно изменен.");
                    this.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при изменении пароля: {ex.Message}");
            }
        }
    }
}
