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
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
         public User? NewUser { get; private set; }
        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

            if (RoleBox.SelectedItem is not ComboBoxItem selectedItem || selectedItem.Content == null)
            {
                MessageBox.Show("Пожалуйста, выберите роль пользователя.");
                return;
            }

            string role = selectedItem.Content.ToString();


            NewUser = new User
            {
                Username = UsernameBox.Text,
                Password = PasswordBox.Password,
                Role = role, 
                IsFirstLogin = true,
                IsLocked = false
            };

            this.DialogResult = true;
            this.Close();
        }

    }
}
