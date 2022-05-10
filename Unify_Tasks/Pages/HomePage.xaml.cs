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

namespace Unify_Tasks.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            appendProjects(1);
            appendTasks(1);

            /*DoubleAnimation buttonAnimation = new DoubleAnimation();
            buttonAnimation.From = helloButton.ActualWidth;
            buttonAnimation.To = 150;
            buttonAnimation.Duration = TimeSpan.FromSeconds(3);
            helloButton.BeginAnimation(Button.WidthProperty, buttonAnimation);*/
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
                project1.ProjectsText = "Project 1";
                project1.Name = "project" + i.ToString();
                project1.MouseDown += new MouseButtonEventHandler(recentClick);

                Separator sep1 = new Separator();
                sep1.Opacity = 0;
                sep1.Height = 0.2 * project1.Height;


                using (var context = new Unify_TasksEntities())
                {
                    context.Projects.Local.Add(new Project()
                    {
                        ProjectHeader = "Project" + i.ToString(),
                        UserID = 1,
                    });
                    context.SaveChanges();
                }
                MessageBox.Show("Project created!");


                stackProjects.Children.Add(sep1);
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
                appendTag(task1, "TextTagTextTagTextTagTextTagTextTag", "Red");
                appendTag(task1, "TextTag", "Green");
                appendTag(task1, "TextTag", "Blue");
                appendTag(task1, "TextTag", "Green");
                appendTag(task1, "TextTag", "Red");

                TasksList.Children.Add(task1);
            }
        }

        private void appendTag(TaskListElement task1, string text, string color)
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
        }
    }
}
