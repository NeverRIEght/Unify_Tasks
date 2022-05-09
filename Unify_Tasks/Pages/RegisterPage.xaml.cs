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

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }

        private void PasswordBox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (NickBox.Text == "Your Password")
            {
                NickBox.Text = "";
                Style whiteText = new Style();

                whiteText.Setters.Add(new Setter { Property = Control.ForegroundProperty, Value = new SolidColorBrush(Colors.White) });
                whiteText.Setters.Add(new Setter { Property = Control.BackgroundProperty, Value = new SolidColorBrush(Color.FromRgb(100, 106, 116)) });
                whiteText.Setters.Add(new Setter { Property = Control.FontFamilyProperty, Value = new FontFamily("/Fonts/#Gilroy") });
                PasswordBox.Width = 280;
                PasswordBox.BorderThickness = new Thickness(0);
                PasswordBox.Style = whiteText;
            }
        }

        private void NickBox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (NickBox.Text == "Your Nick")
            {
                NickBox.Text = "";
                Style whiteText = new Style();

                whiteText.Setters.Add(new Setter { Property = Control.ForegroundProperty, Value = new SolidColorBrush(Colors.White) });
                whiteText.Setters.Add(new Setter { Property = Control.BackgroundProperty, Value = new SolidColorBrush(Color.FromRgb(100, 106, 116)) });
                whiteText.Setters.Add(new Setter { Property = Control.FontFamilyProperty, Value = new FontFamily("/Fonts/#Gilroy") });
                NickBox.Width = 280;
                NickBox.BorderThickness = new Thickness(0);
                NickBox.Style = whiteText;
            }
        }
    }
}
