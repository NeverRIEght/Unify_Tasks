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

        public DateTime? Date1 { get; set; }

        public DateWindow()
        {
            InitializeComponent();
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = Calendar1.SelectedDate;
            Date1 = selectedDate;
        }
    }
}
