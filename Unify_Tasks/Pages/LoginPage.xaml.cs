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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Unify_Tasks.Models;

namespace Unify_Tasks.Pages
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Login : Page
    {
        static MainWindow w1 = (MainWindow)Application.Current.MainWindow;

        public Login()
        {
            InitializeComponent();
        }

        private void LoginPage_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow win = (MainWindow)Window.GetWindow(this);
            win.MinWidth = 430;
            win.MinHeight = 550;
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void LogIn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            LoginUser();
        }

        private void NewAcc_MouseUp(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Register());
        }

        private void LoginBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoginBorder.Background = (Brush)Application.Current.FindResource("AccentI");
            LoginBox.Background = Brushes.Transparent;
            PasswordBorder.Background = (Brush)Application.Current.FindResource("AccentI");
            PasswordBox.Background = Brushes.Transparent;

            var tool1 = new ToolTip();
            tool1.Background = Brushes.Transparent;
            tool1.Foreground = Brushes.Transparent;
            tool1.BorderThickness = new Thickness(0);
            tool1.Content = "";
            LoginBox.ToolTip = tool1;

            var tool2 = new ToolTip();
            tool2.Background = Brushes.Transparent;
            tool2.Foreground = Brushes.Transparent;
            tool2.BorderThickness = new Thickness(0);
            tool2.Content = "";
            PasswordBox.ToolTip = tool2;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            LoginBorder.Background = (Brush)Application.Current.FindResource("AccentI");
            LoginBox.Background = Brushes.Transparent;
            PasswordBorder.Background = (Brush)Application.Current.FindResource("AccentI");
            PasswordBox.Background = Brushes.Transparent;

            var tool1 = new ToolTip();
            tool1.Background = Brushes.Transparent;
            tool1.Foreground = Brushes.Transparent;
            tool1.BorderThickness = new Thickness(0);
            tool1.Content = "";
            LoginBox.ToolTip = tool1;

            var tool2 = new ToolTip();
            tool2.Background = Brushes.Transparent;
            tool2.Foreground = Brushes.Transparent;
            tool2.BorderThickness = new Thickness(0);
            tool2.Content = "";
            PasswordBox.ToolTip = tool2;
        }

        private void LoginUser()
        {
            string login = LoginBox.Text.Trim();
            string password = PasswordBox.Password.Trim();

            try
            {
                User authUser = null;
                using (var context = new Unify_TasksEntities())
                {
                    authUser = context.Users.Where(b => b.login == login && b.password == password).FirstOrDefault();
                }
                if (authUser != null)
                {
                    HomePage homePage = new HomePage();
                    NavigationService.Navigate(new HomePage());
                    w1.currUser = authUser.UserID;
                    w1.userNickname = authUser.login;
                }


                else
                {
                    LoginBox.Background = Brushes.DarkRed;
                    LoginBorder.Background = Brushes.DarkRed;
                    PasswordBox.Background = Brushes.DarkRed;
                    PasswordBorder.Background = Brushes.DarkRed;

                    var tool1 = new ToolTip();
                    tool1.Background = (Brush)Application.Current.FindResource("BackI");
                    tool1.Content = "Login or password incorrect";
                    LoginBox.ToolTip = tool1;

                    var tool2 = new ToolTip();
                    tool2.Background = (Brush)Application.Current.FindResource("BackI");
                    tool2.Content = "Login or password incorrect";
                    PasswordBox.ToolTip = tool2;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while trying to login.\r\n" +

                                        "Try to repeat the steps that led to the error. If the error still occurs,\r\n" +
                                        "please, contact the program developer");
            }
        }

        private void Page_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoginUser();
            }
        }
    }
}
