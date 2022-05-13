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
using Unify_Tasks.Models;

namespace Unify_Tasks.DialogWindows
{
    /// <summary>
    /// Логика взаимодействия для Date.xaml
    /// </summary>
    public partial class DateWindow : Window
    {
        public DateTime? selectedDate = null;
        public DateWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DateWindow win = (DateWindow)Window.GetWindow(this);

            win.MinWidth = 200;
            win.MinHeight = 250;
            win.MaxWidth = 200;
            win.MaxHeight = 250;

            using (var context = new Unify_TasksEntities())
            {
                Models.Task thisTask = context.Tasks.Where(b => b.TaskID == w1.currTask).FirstOrDefault();

                if (thisTask != null)
                {
                    Calendar1.SelectedDate = thisTask.Planned;
                }
            }
        }

        static MainWindow w1 = (MainWindow)Application.Current.MainWindow;

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedDate = Calendar1.SelectedDate;
            
        }

        private void TextBlock_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (selectedDate != null)
            {
                w1.currDate = selectedDate;
            }
            this.DialogResult = true;
            this.Close();
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }
    }
}
