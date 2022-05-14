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

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string Login = NickBox.Text.Trim();
            string Password = PasswordBox.Password.Trim();
            string RPassword = RepeatPasswordBox.Password.Trim();

            if (Login.Length < 5)
            {
                NickBox.ToolTip = "Nickname length must be more than 5 characters";
                NickBoxBorder.Background = Brushes.DarkRed;
                NickBox.Background = Brushes.DarkRed;
            }
            else if (Login.Length > 20)
            {
                NickBox.ToolTip = "Nickname length must be less than 20 characters";
                NickBoxBorder.Background = Brushes.DarkRed;
                NickBox.Background = Brushes.DarkRed;
            }
            else if (!Regex.Match(Login, "^[A-Za-z0-9]+$").Success)
            {
                NickBox.ToolTip = "Login must contains only english letters and numbers";
                NickBoxBorder.Background = Brushes.DarkRed;
                NickBox.Background = Brushes.DarkRed;
            }
            else if (Password.Length > 20)
            {
                PasswordBox.ToolTip = "Password length must be less than 20 characters";
                PasswordBoxBorder.Background = Brushes.DarkRed;
                PasswordBox.Background = Brushes.DarkRed;

            }
            else if (Password.Length < 5)
            {
                PasswordBox.ToolTip = "Password length must be more than 5 characters";
                PasswordBoxBorder.Background = Brushes.DarkRed;
                PasswordBox.Background = Brushes.DarkRed;
            }
            else if(Password != RPassword)
            {
                RepeatPasswordBox.ToolTip = "Passwords do not match";
                RepeatPasswordBoxBorder.Background = Brushes.DarkRed;
                RepeatPasswordBox.Background = Brushes.DarkRed;
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

        private void BackLogin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }

        private void CreateID_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void CreateID_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void BackLogin_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void BackLogin_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }
    }
}
