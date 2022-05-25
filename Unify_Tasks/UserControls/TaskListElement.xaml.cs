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
            
        }

        private void Task_MouseEnter(object sender, MouseEventArgs e)
        {
            OpenNote.Visibility = Visibility.Visible;
        }
        private void Task_MouseLeave(object sender, MouseEventArgs e)
        {
            OpenNote.Visibility = Visibility.Hidden;
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

        public static readonly DependencyProperty TasksIDProperty =
        DependencyProperty.Register(
        name: "TasksID",
        propertyType: typeof(int),
        ownerType: typeof(TaskListElement),
        typeMetadata: new FrameworkPropertyMetadata(
        defaultValue: 1,
        flags: FrameworkPropertyMetadataOptions.AffectsMeasure));

        public int TasksID
        {
            get => (int)GetValue(TasksIDProperty);
            set => SetValue(TasksIDProperty, value);
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }
    }
}
