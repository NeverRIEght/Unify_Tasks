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
using Unify_Tasks.DialogWindows;
using Unify_Tasks.Models;
using Unify_Tasks.Pages;

namespace Unify_Tasks.UserControls
{
    /// <summary>
    /// Логика взаимодействия для Task.xaml
    /// </summary>
    public partial class TaskListElement : UserControl
    {
        static MainWindow w1 = (MainWindow)Application.Current.MainWindow;

        public TaskListElement()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Task_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void Task_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            MainWindow win = (MainWindow)Window.GetWindow(this);
            if (win.Width <= 1300)
            {
                TaskGrid.ColumnDefinitions[5].MinWidth = 10;
                TaskGrid.ColumnDefinitions[7].MinWidth = 0;
            }

            if (TaskHeader.Width > 520)
            {
                TaskHeader.FontSize = 21;
            }
            if (TaskHeader.Width <= 520)
            {
                TaskHeader.FontSize = 16;
            }
        }

        private void Task_MouseEnter(object sender, MouseEventArgs e)
        {
            OpenNote.Visibility = Visibility.Visible;
            Priority.BorderBrush = (Brush)Application.Current.FindResource("MainI");

            using (var context = new Unify_TasksEntities())
            {
                var thisTask = context.Tasks.Where(t => t.TaskID == w1.currTask).FirstOrDefault();

                if(thisTask != null)
                {
                    PriorityText.Text = Convert.ToString(thisTask.Priority);

                    switch (thisTask.Priority)
                    {
                        case 0:
                            PriorityText.Text = "";
                            Priority.Background = Brushes.Transparent;
                            Priority.BorderBrush = Brushes.Transparent;
                            break;
                        case 1:
                            PriorityText.Text = "1";
                            Priority.Background = (Brush)Application.Current.FindResource("CustomRed");
                            Priority.BorderBrush = (Brush)Application.Current.FindResource("MainI");
                            break;
                        case 2:
                            PriorityText.Text = "2";
                            Priority.Background = (Brush)Application.Current.FindResource("CustomYellow");
                            Priority.BorderBrush = (Brush)Application.Current.FindResource("MainI");
                            break;
                        case 3:
                            PriorityText.Text = "3";
                            Priority.Background = (Brush)Application.Current.FindResource("CustomGreen");
                            Priority.BorderBrush = (Brush)Application.Current.FindResource("MainI");
                            break;
                        case 4:
                            PriorityText.Text = "4";
                            Priority.Background = (Brush)Application.Current.FindResource("CustomBlue");
                            Priority.BorderBrush = (Brush)Application.Current.FindResource("MainI");
                            break;
                    }
                }
            }
        }
        private void Task_MouseLeave(object sender, MouseEventArgs e)
        {
            OpenNote.Visibility = Visibility.Hidden;
            Priority.BorderBrush = Brushes.Transparent;
            Priority.Background = Brushes.Transparent;
            PriorityText.Text = "";
        }

        private void TaskHeader_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (var context = new Unify_TasksEntities())
            {
                var thisTask = context.Tasks.Where(t => t.TaskID == w1.currTask).FirstOrDefault();

                if (thisTask != null)
                {
                    thisTask.Header = TaskHeader.Text;
                    context.SaveChanges();
                }
            }
        }

        private void OpenNote_MouseEnter(object sender, MouseEventArgs e)
        {
            OpenNote.Visibility = Visibility.Hidden;
            OpenNoteWhite.Visibility = Visibility.Visible;
            this.Cursor = Cursors.Hand;
        }
        private void OpenNote_MouseLeave(object sender, MouseEventArgs e)
        {
            OpenNote.Visibility = Visibility.Visible;
            OpenNoteWhite.Visibility = Visibility.Hidden;
            this.Cursor = Cursors.Arrow;
        }

        private void Trash_MouseEnter(object sender, MouseEventArgs e)
        {
            Trash.Visibility = Visibility.Hidden;
            TrashRed.Visibility = Visibility.Visible;
            this.Cursor = Cursors.Hand;
        }
        private void Trash_MouseLeave(object sender, MouseEventArgs e)
        {
            Trash.Visibility = Visibility.Visible;
            TrashRed.Visibility = Visibility.Hidden;
            this.Cursor = Cursors.Arrow;
        }


    }
}
