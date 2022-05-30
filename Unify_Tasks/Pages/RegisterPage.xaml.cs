using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
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
            RegisterUser();
        }

        private void BackLogin_MouseUp(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }

        private void NickBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            NickBoxBorder.Background = (Brush)Application.Current.FindResource("AccentI");
            NickBox.Background = Brushes.Transparent;
            PasswordBoxBorder.Background = (Brush)Application.Current.FindResource("AccentI");
            PasswordBox.Background = Brushes.Transparent;
            RepeatPasswordBoxBorder.Background = (Brush)Application.Current.FindResource("AccentI");
            RepeatPasswordBox.Background = Brushes.Transparent;

            var tool1 = new ToolTip();
            tool1.Background = Brushes.Transparent;
            tool1.Foreground = Brushes.Transparent;
            tool1.BorderThickness = new Thickness(0);
            tool1.Content = "";
            NickBox.ToolTip = tool1;
            PasswordBox.ToolTip = tool1;
            RepeatPasswordBox.ToolTip = tool1;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            NickBoxBorder.Background = (Brush)Application.Current.FindResource("AccentI");
            NickBox.Background = Brushes.Transparent;
            PasswordBoxBorder.Background = (Brush)Application.Current.FindResource("AccentI");
            PasswordBox.Background = Brushes.Transparent;
            RepeatPasswordBoxBorder.Background = (Brush)Application.Current.FindResource("AccentI");
            RepeatPasswordBox.Background = Brushes.Transparent;

            var tool1 = new ToolTip();
            tool1.Background = Brushes.Transparent;
            tool1.Foreground = Brushes.Transparent;
            tool1.BorderThickness = new Thickness(0);
            tool1.Content = "";
            NickBox.ToolTip = tool1;
            PasswordBox.ToolTip = tool1;
            RepeatPasswordBox.ToolTip = tool1;
        }

        private void RepeatPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            NickBoxBorder.Background = (Brush)Application.Current.FindResource("AccentI");
            NickBox.Background = Brushes.Transparent;
            PasswordBoxBorder.Background = (Brush)Application.Current.FindResource("AccentI");
            PasswordBox.Background = Brushes.Transparent;
            RepeatPasswordBoxBorder.Background = (Brush)Application.Current.FindResource("AccentI");
            RepeatPasswordBox.Background = Brushes.Transparent;

            var tool1 = new ToolTip();
            tool1.Background = Brushes.Transparent;
            tool1.Foreground = Brushes.Transparent;
            tool1.BorderThickness = new Thickness(0);
            tool1.Content = "";
            NickBox.ToolTip = tool1;
            PasswordBox.ToolTip = tool1;
            RepeatPasswordBox.ToolTip = tool1;
        }

        private void RegisterUser()
        {
            string Login = NickBox.Text.Trim();
            string Password = PasswordBox.Password.Trim();
            string RPassword = RepeatPasswordBox.Password.Trim();

            int CanRegister = 1;

            try
            {
                using (var context = new Unify_TasksEntities())
                {
                    var UserList = context.Users.Where(u => u.UserID == u.UserID).ToList();

                    if (UserList != null)
                    {
                        foreach (var everyUser in UserList)
                        {
                            if (everyUser.login == Login)
                            {
                                CanRegister--;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while trying to search for existing users.\r\n" +
                                    "Try to repeat the steps that led to the error. If the error still occurs,\r\n" +
                                    "please, contact the program developer");
            }


            if (CanRegister == 1)
            {
                if (Login.Length < 5)
                {
                    var tool1 = new ToolTip();
                    tool1.Background = (Brush)Application.Current.FindResource("BackI");
                    tool1.Content = "Nickname must contain 5 characters or more";
                    NickBox.ToolTip = tool1;

                    NickBox.Background = Brushes.DarkRed;
                    NickBoxBorder.Background = Brushes.DarkRed;
                }
                else if (Login.Length > 14)
                {
                    var tool1 = new ToolTip();
                    tool1.Background = (Brush)Application.Current.FindResource("BackI");
                    tool1.Content = "Nickname must contain 14 characters or less";
                    NickBox.ToolTip = tool1;

                    NickBox.Background = Brushes.DarkRed;
                    NickBoxBorder.Background = Brushes.DarkRed;
                }
                else if (!Regex.Match(Login, "^[A-Za-z0-9]+$").Success)
                {
                    var tool1 = new ToolTip();
                    tool1.Background = (Brush)Application.Current.FindResource("BackI");
                    tool1.Content = "Login must contains only english letters, numbers or symbols";
                    NickBox.ToolTip = tool1;

                    NickBox.Background = Brushes.DarkRed;
                    NickBoxBorder.Background = Brushes.DarkRed;
                }



                else if (Password.Length > 24)
                {
                    var tool1 = new ToolTip();
                    tool1.Background = (Brush)Application.Current.FindResource("BackI");
                    tool1.Content = "Password must contain 24 characters or less";
                    PasswordBox.ToolTip = tool1;
                    PasswordBox.Background = Brushes.DarkRed;
                    PasswordBoxBorder.Background = Brushes.DarkRed;

                }
                else if (Password.Length < 5)
                {
                    var tool1 = new ToolTip();
                    tool1.Background = (Brush)Application.Current.FindResource("BackI");
                    tool1.Content = "Password must contain 5 characters or more";
                    PasswordBox.ToolTip = tool1;

                    PasswordBox.Background = Brushes.DarkRed;
                    PasswordBoxBorder.Background = Brushes.DarkRed;
                }
                else if (!Regex.Match(Password, "^[A-Za-z0-9]+$").Success)
                {
                    var tool1 = new ToolTip();
                    tool1.Background = (Brush)Application.Current.FindResource("BackI");
                    tool1.Content = "Password must contains only english letters, numbers or symbols";
                    PasswordBox.ToolTip = tool1;

                    PasswordBox.Background = Brushes.DarkRed;
                    PasswordBoxBorder.Background = Brushes.DarkRed;
                }



                else if (Password != RPassword)
                {
                    var tool1 = new ToolTip();
                    tool1.Background = (Brush)Application.Current.FindResource("BackI");
                    tool1.Content = "Passwords do not match";
                    RepeatPasswordBox.ToolTip = tool1;

                    RepeatPasswordBox.Background = Brushes.DarkRed;
                    RepeatPasswordBoxBorder.Background = Brushes.DarkRed;
                }



                else
                {
                    try
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
                    catch (Exception)
                    {
                        MessageBox.Show("An error occurred while trying to register a new user.\r\n" +
                                        "Try to repeat the steps that led to the error. If the error still occurs,\r\n" +
                                        "please, contact the program developer");
                    }
                }
            }
            else
            {
                var tool1 = new ToolTip();
                tool1.Background = (Brush)Application.Current.FindResource("BackI");
                tool1.Content = "User with this nickname already exists, please choose another nickname";
                NickBox.ToolTip = tool1;

                NickBox.Background = Brushes.DarkRed;
                NickBoxBorder.Background = Brushes.DarkRed;
            }
        }

        private void Page_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                RegisterUser();
            }
        }
    }
}
