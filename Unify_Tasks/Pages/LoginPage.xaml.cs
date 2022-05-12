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

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text.Trim();
            string password = PasswordBox.Text.Trim();

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
            }
            else
            {
                LoginBorder.Background = Brushes.DarkRed;
                LoginBox.Background = Brushes.DarkRed;
                PasswordBorder.Background = Brushes.DarkRed;
                PasswordBox.Background = Brushes.DarkRed;

                LoginBox.ToolTip = "Login or password ";
                PasswordBox.ToolTip = "Check yours passwords";

                MessageBox.Show("Данные для входа неверны");
            }

            //NavigationService.Navigate(new HomePage());

        }

        private void NewAcc_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Register());
        }

        private void LoginBox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (LoginBox.Text == "Your Login")
            {
                LoginBox.Text = "";
                Style whiteText = new Style();

                whiteText.Setters.Add(new Setter { Property = Control.ForegroundProperty, Value = new SolidColorBrush(Colors.White) });
                whiteText.Setters.Add(new Setter { Property = Control.BackgroundProperty, Value = new SolidColorBrush(Color.FromRgb(100, 106, 116)) });
                whiteText.Setters.Add(new Setter { Property = Control.FontFamilyProperty, Value = new FontFamily("/Fonts/#Gilroy") });
                LoginBox.Width = 280;
                LoginBox.BorderThickness = new Thickness(0);
                LoginBox.Style = whiteText;
            }
        }

        private void PasswordBox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (PasswordBox.Text == "Your Password")
            {
                PasswordBox.Text = "";
                Style whiteText = new Style();

                whiteText.Setters.Add(new Setter { Property = Control.ForegroundProperty, Value = new SolidColorBrush(Colors.White) });
                whiteText.Setters.Add(new Setter { Property = Control.BackgroundProperty, Value = new SolidColorBrush(Color.FromRgb(100, 106, 116)) });
                whiteText.Setters.Add(new Setter { Property = Control.FontFamilyProperty, Value = new FontFamily("/Fonts/#Gilroy") });
                PasswordBox.Width = 280;
                PasswordBox.BorderThickness = new Thickness(0);
                PasswordBox.Style = whiteText;
            }
        }

        private void LoginBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string currLogin = LoginBox.Text;
            /*if(currLogin < 5)*/
        }

        private void LogIn_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void LogIn_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void NewAcc_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void NewAcc_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }
    }
}
