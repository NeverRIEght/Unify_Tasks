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

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text.Trim();
            string password = PasswordBox.Password.Trim();

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
                LoginBox.Foreground = Brushes.DarkRed;
                PasswordBox.Foreground = Brushes.DarkRed;

                LoginBox.ToolTip = "Login or password incorrect";
                PasswordBox.ToolTip = "Login or password incorrect";
            }

        }

        private void NewAcc_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Register());
        }

        
    }
}
