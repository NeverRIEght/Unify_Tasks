using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Unify_Tasks.Models;

namespace Unify_Tasks.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class Register : Page
    {

        public Register()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow win = (MainWindow)Window.GetWindow(this);

            win.MinWidth = 430;
            win.MinHeight = 650;
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void Register_MouseUp(object sender, MouseButtonEventArgs e)
        {
            string Login = NickBox.Text.Trim();
            string Password = PasswordBox.Password.Trim();
            string RPassword = RepeatPasswordBox.Password.Trim();

            if (Login.Length < 5)
            {
                NickBox.ToolTip = "Nickname length must be more than 5 characters";
                NickBox.Background = Brushes.DarkRed;
                NickBoxBorder.Background = Brushes.DarkRed;
            }
            else if (Login.Length > 20)
            {
                NickBox.ToolTip = "Nickname length must be less than 20 characters";
                NickBox.Background = Brushes.DarkRed;
                NickBoxBorder.Background = Brushes.DarkRed;
            }
            else if (!Regex.Match(Login, "^[A-Za-z0-9]+$").Success)
            {
                NickBox.ToolTip = "Login must contains only english letters and numbers";
                NickBox.Background = Brushes.DarkRed;
                NickBoxBorder.Background = Brushes.DarkRed;
            }
            else if (Password.Length > 20)
            {
                PasswordBox.ToolTip = "Password length must be less than 20 characters";
                PasswordBox.Background = Brushes.DarkRed;
                PasswordBoxBorder.Background = Brushes.DarkRed;

            }
            else if (Password.Length < 5)
            {
                PasswordBox.ToolTip = "Password length must be more than 5 characters";
                PasswordBox.Background = Brushes.DarkRed;
                PasswordBoxBorder.Background = Brushes.DarkRed;
            }
            else if (Regex.Match(Password, "^[A-Za-z]+$").Success)
            {
                PasswordBox.ToolTip = "Password must contains numbers too";
                PasswordBox.Background = Brushes.DarkRed;
                PasswordBoxBorder.Background = Brushes.DarkRed;
            }
            else if (Regex.Match(Password, "^[0-9]+$").Success)
            {
                PasswordBox.ToolTip = "Password must contains letters too";
                PasswordBox.Background = Brushes.DarkRed;
                PasswordBoxBorder.Background = Brushes.DarkRed;
            }
            else if (Password != RPassword)
            {
                RepeatPasswordBox.ToolTip = "Passwords do not match";
                RepeatPasswordBox.Background = Brushes.DarkRed;
                RepeatPasswordBoxBorder.Background = Brushes.DarkRed;
            }


            else
            {
                using (var context = new Unify_TasksEntities())
                {
                    context.Users.Local.Add(new User()
                    {
                        login = Login,
                        password = Password,
                    });
                    context.SaveChanges();
                }
                MessageBox.Show("Register Success!");
                NavigationService.Navigate(new Login());
            }
        }

        private void BackLogin_MouseUp(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }
    }
}
