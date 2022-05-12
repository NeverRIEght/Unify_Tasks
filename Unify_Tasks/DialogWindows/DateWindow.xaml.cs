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

namespace Unify_Tasks.DialogWindows
{
    /// <summary>
    /// Логика взаимодействия для Date.xaml
    /// </summary>
    public partial class DateWindow : Window
    {
        public DateWindow()
        {
            InitializeComponent();
        }

        static MainWindow w1 = (MainWindow)Application.Current.MainWindow;

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = null;
            selectedDate = Calendar1.SelectedDate;
            if(selectedDate != null)
            {
                w1.currDate = selectedDate;
            }
        }
    }
}
