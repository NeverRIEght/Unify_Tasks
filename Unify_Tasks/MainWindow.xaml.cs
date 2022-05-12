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
        public int currProject { get; set; }
        public int currTask { get; set; }
        public int lastNote { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new Login();
        }
    }
}
