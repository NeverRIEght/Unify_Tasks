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

namespace Unify_Tasks.UserControls
{
    /// <summary>
    /// Логика взаимодействия для Task.xaml
    /// </summary>
    public partial class TaskListElement : UserControl
    {
        public TaskListElement()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Trash_MouseEnter(object sender, MouseEventArgs e)
        {
            Trash.Opacity = 0;
            TrashRed.Opacity = 1;
        }

        private void Trash_MouseLeave(object sender, MouseEventArgs e)
        {
            Trash.Opacity = 1;
            TrashRed.Opacity = 0;
        }

        private void TrashRed_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Задача удалена!");
        }

        private void Watch_MouseEnter(object sender, MouseEventArgs e)
        {
            Watch.Opacity = 0;
            WatchBlue.Opacity = 1;
        }

        private void Watch_MouseLeave(object sender, MouseEventArgs e)
        {
            Watch.Opacity = 1;
            WatchBlue.Opacity = 0;
        }

        private void WatchBlue_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Задаем время!");
        }

        private void TagControl_MouseEnter(object sender, MouseEventArgs e)
        {
            TagControl.Opacity = 0;
            TagControlBrown.Opacity = 1;
        }

        private void TagControl_MouseLeave(object sender, MouseEventArgs e)
        {
            TagControl.Opacity = 1;
            TagControlBrown.Opacity = 0;
        }

        private void TagControlBrown_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Задаем теги!");
        }
    }
}
