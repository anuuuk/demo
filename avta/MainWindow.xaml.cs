using avta.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace avta
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text.Trim(); //связь с переменными интерфейса
            string password = txtPassword.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) //проверка на заполнение полей
            {
                MessageBox.Show("Введите логин и пароль.");
                return;
            }

            using var context = new HotelManagementContext(); //подключение к бд
            var user = await context.Users.FirstOrDefaultAsync(x => x.Username == username); //поиск пользователя по логину

            if (user == null) //если пользователь с таким логином не существует
            {
                MessageBox.Show("Неправильный логин или пользователь не существует.");
                return;
            }

            if (user.IsLocked == true) //если пользователь заблокирован
            {
                MessageBox.Show("Вы заблокированы. Обратитесь к администратору.");
                return;
            }


            if (user.Password == password) //если пароль верный
            {
                bool isFirstLogin = !user.LastLoginDate.HasValue; //переменная для проверки первого входа, если дата пустая

                if (isFirstLogin) //если первый вход
                {
                    
                    var changePassword = new ChangePasswordWindow(user.Id); //то смена пароля
                    changePassword.Owner = this;
                    changePassword.ShowDialog();
                    user.LastLoginDate = DateTime.Now; //обновление последней даты входа
                    await context.SaveChangesAsync(); //сохранение
                }
                else
                {
                    if (user.LastLoginDate.HasValue && (DateTime.Now - user.LastLoginDate.Value).TotalDays > 30 && user.Role != "Admin") //блокировка после долгого отсутствия
                    {
                        user.IsLocked = true;
                        await context.SaveChangesAsync();
                        MessageBox.Show("Вы заблокированы из-за длительного отсутствия.");
                        return;
                     }
                    else
                    {
                        // Успешный вход
                       
                        MessageBox.Show("Успешный вход!");
                        Window nextWindow = user.Role == "Admin" ? new Admin() : new MainWindow(); // переход на нужное
                        nextWindow.Show();
                        this.Close(); 
                        user.LastLoginDate = DateTime.Now; //обновление последней даты входа
                        user.FailedLoginAttempts = 0; //сброс счетчика
                        await context.SaveChangesAsync(); //сохранение
                    }
                    
                 }
                
            }
            else
            {
                user.FailedLoginAttempts = (user.FailedLoginAttempts ?? 0) + 1;

                if (user.FailedLoginAttempts >= 3)
                {
                    user.IsLocked = true;
                    MessageBox.Show("Вы заблокированы после 3 неудачных попыток.");
                }
                else
                {
                    int attemptsLeft = 3 - user.FailedLoginAttempts.Value;
                    MessageBox.Show($"Неправильный пароль. Осталось попыток: {attemptsLeft}.");
                }

                await context.SaveChangesAsync();
                return;
            }
        }

    }
}