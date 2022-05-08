﻿using System;
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

namespace Unify_Tasks
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            this.Title = "Unify - Log In";
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NewAcc_Click(object sender, RoutedEventArgs e)
        {
            Window RegisterWindow1 = new RegisterWindow();
            RegisterWindow1.Title = "Unify - Register";
            RegisterWindow1.Show();
            this.Close();
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
    }
}
