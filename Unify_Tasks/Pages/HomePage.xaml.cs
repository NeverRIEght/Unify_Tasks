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
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Unify_Tasks.UserControls;
using Unify_Tasks.Models;
using Unify_Tasks.DialogWindows;

namespace Unify_Tasks.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        static MainWindow w1 = (MainWindow)Application.Current.MainWindow;
        public int AvatarColor = 1;

        public HomePage()
        {
            InitializeComponent();
            appendProjects(5);
            appendTasks(5);

            /*DoubleAnimation buttonAnimation = new DoubleAnimation();
            buttonAnimation.From = helloButton.ActualWidth;
            buttonAnimation.To = 150;
            buttonAnimation.Duration = TimeSpan.FromSeconds(3);
            helloButton.BeginAnimation(Button.WidthProperty, buttonAnimation);*/
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void appendProjects(int length)
        {
            for (int i = 0; i < length; i++)
            {
                ProjectListElement project1 = new ProjectListElement();
                if (i == length - 1)
                {
                    project1.underline.Visibility = Visibility.Hidden;
                }
                project1.ProjectsText = "12345678901234567890";
                project1.Name = "project" + i.ToString();
                project1.Margin = new Thickness(0, 5, 0, 0);
                project1.MouseDown += new MouseButtonEventHandler(recentClick);


                /*using (var context = new Unify_TasksEntities())
                {
                    context.Projects.Local.Add(new Project()
                    {
                        ProjectHeader = "Project" + i.ToString(),
                        UserID = 1,
                    });
                    context.SaveChanges();
                }
                MessageBox.Show("Project created!");*/


                stackProjects.Children.Add(project1);
            }
        }

        private void recentClick(object sender, EventArgs e)
        {
            MessageBox.Show("Hello, world!");
        }

        private void appendTasks(int length)
        {
            for (int i = 0; i < length; i++)
            {
                TaskListElement task1 = new TaskListElement();
                task1.Margin = new Thickness(5, 0, 5, 0);
                /*appendTag(task1, "TextTagTextTagTextTagTextTagTextTag", "Red");
                appendTag(task1, "TextTag", "Green");
                appendTag(task1, "TextTag", "Blue");
                appendTag(task1, "TextTag", "Green");
                appendTag(task1, "TextTag", "Red");*/

                Separator sep1 = new Separator();
                sep1.Opacity = 0;
                sep1.Height = 0.2 * task1.Height;

                if (i == 0)
                {
                    TasksList.Children.Add(sep1);
                }

                TasksList.Children.Add(task1);
                
                if (i != length - 1)
                {
                    Separator sep2 = new Separator();
                    sep2.Opacity = 0;
                    sep2.Height = 0.2 * task1.Height;
                    TasksList.Children.Add(sep2);
                }
                
            }
        }

        /*private void appendTag(TaskListElement task1, string text, string color)
        {
            if (task1.TagsList.Children.Count % 2 == 1)
            {
                ////////////////////////////////////////////////////////////////////////////////////////////////////
            }
            TagElement tag1 = new TagElement();
            tag1.TagText = text;
            switch (color)
            {
                case "Red":
                    tag1.TagBackgroud.Background = Brushes.Red;
                    break;
                case "Green":
                    tag1.TagBackgroud.Background = Brushes.Green;
                    break;
                case "Blue":
                    tag1.TagBackgroud.Background = Brushes.Blue;
                    break;
            }
            task1.TagsList.Children.Add(tag1);
        }*/

        private void NewProject_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Project created!");
        }

        private void Settings_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Settings!");
        }

        private void LogOf_MouseUp(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Login());
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
            MessageBoxResult result1 = MessageBox.Show("Are you sure you want to delete the project?", "Unify", MessageBoxButton.YesNo);
            switch(result1)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Project deleted successfully");
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            MainWindow win = (MainWindow)Window.GetWindow(this);

            win.MinWidth = 1060;

        }

        private void AvatarRect_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if(AvatarColor == 8)
            {
                AvatarColor = 1;
            }
            else
            {
                AvatarColor += 1;
            }
            switch(AvatarColor)
            {
                case 1:
                    AvatarRect.Fill = (Brush)Application.Current.FindResource("CustomGreen");
                    break;
                case 2:
                    AvatarRect.Fill = (Brush)Application.Current.FindResource("CustomBlue");
                    break;
                case 3:
                    AvatarRect.Fill = (Brush)Application.Current.FindResource("CustomBrown");
                    break;
                case 4:
                    AvatarRect.Fill = (Brush)Application.Current.FindResource("CustomRed");
                    break;
                case 5:
                    AvatarRect.Fill = (Brush)Application.Current.FindResource("CustomGray");
                    break;
                case 6:
                    AvatarRect.Fill = (Brush)Application.Current.FindResource("CustomYellow");
                    break;
                case 7:
                    AvatarRect.Fill = (Brush)Application.Current.FindResource("CustomPink");
                    break;
                case 8:
                    AvatarRect.Fill = (Brush)Application.Current.FindResource("CustomPurple");
                    break;
            }
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
