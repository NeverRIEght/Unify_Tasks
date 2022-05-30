using System;
using System.Windows;
using Unify_Tasks.Pages;

namespace Unify_Tasks
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public DateTime? currDate { get; set; }
        public int currUser { get; set; }
        public string userNickname { get; set; }
        public int currProject { get; set; }
        public int currTask { get; set; }
        public int lastNote { get; set; }
        public string currPath = Environment.CurrentDirectory;


        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new Login();
        }

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            MainFrame.NavigationService.RemoveBackEntry();
        }
    }
}
