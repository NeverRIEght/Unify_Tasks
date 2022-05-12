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
using Unify_Tasks;

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
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var context = new Unify_TasksEntities())
            {
                var LastNote = context.Notes.Where(p => p.NoteID == p.NoteID).LastOrDefault();
                w1.lastNote = LastNote.NoteID;
            }
            UpdateProjects();
        }

        private void UpdateProjects()
        {
            stackProjects.Children.Clear();
            using (var context = new Unify_TasksEntities())
            {
                var currProjects = from p in context.Projects
                                   where p.UserID == w1.currUser
                                   orderby p.ProjectID
                                   select p;
                if (currProjects != null)
                {
                    stackProjects.Children.Clear();
                    foreach (var everyProject in currProjects)
                    {
                        ProjectListElement project1 = new ProjectListElement();
                        project1.ProjectsText = everyProject.ProjectHeader;
                        project1.Margin = new Thickness(0, 5, 0, 0);
                        project1.ProjectsID = everyProject.ProjectID;

                        project1.MouseUp += (object s, MouseButtonEventArgs ev) =>
                        {
                            w1.currProject = project1.ProjectsID;
                            ProjectName.Text = project1.ProjectsText;
                            ProjectName.Visibility = Visibility.Visible;
                            NewTask.Visibility = Visibility.Visible;
                            TasksViewer.Visibility = Visibility.Visible;
                            Trash.Visibility = Visibility.Visible;
                            TrashRed.Visibility = Visibility.Visible;
                            UpdateTasks();
                        };

                        stackProjects.Children.Add(project1);
                    }
                }
            }
        }

        private void UpdateTasks()
        {
            TasksList.Children.Clear();
            using (var context1 = new Unify_TasksEntities())
            {
                var currTasks = from p in context1.Tasks
                                where p.ProjectID == w1.currProject
                                orderby p.TaskID
                                select p;

                if (currTasks != null)
                {
                    foreach (var everyTask in currTasks)
                    {
                        TaskListElement task1 = new TaskListElement();
                        task1.TaskHeader.Text = everyTask.Header;
                        task1.ProjectsID = (int)everyTask.ProjectID;
                        task1.Margin = new Thickness(5, 5, 0, 0);
                        if (everyTask.Status == 1)
                        {
                            task1.IsReady.IsChecked = true;
                        }
                        else
                        {
                            task1.IsReady.IsChecked = false;
                        }

                        task1.MouseEnter += (object s, MouseEventArgs ev) =>
                        {
                            w1.currTask = task1.ProjectsID;
                        };

                        TasksList.Children.Add(task1);
                    }
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

            using (var context = new Unify_TasksEntities())
            {
                context.Projects.Local.Add(new Project()
                {
                    ProjectHeader = "New Project",
                    UserID = w1.currUser,
                });
                context.SaveChanges();
            }
            UpdateProjects();
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
                    DeleteProject();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void DeleteProject()
        {
            Project toDelete = null;
            using (var context = new Unify_TasksEntities())
            {
                toDelete = context.Projects.Where(b => b.ProjectID == w1.currProject).FirstOrDefault();

                var delTasks = from p in context.Tasks
                               where p.ProjectID == w1.currProject
                               orderby p.ProjectID
                               select p;

                if (delTasks != null)
                {
                    foreach (var everyTask in delTasks)
                    {
                        var delNotes = from h in context.Notes
                                       where h.NoteID == everyTask.NoteID
                                       select h;

                        if (delNotes != null)
                        {
                            foreach (Note everyNote in delNotes)
                            {
                                context.Notes.Remove(everyNote);
                            }
                        }

                        context.Tasks.Remove(everyTask);
                    }
                }

                if (toDelete != null)
                {
                    context.Projects.Remove(toDelete);
                    UpdateProjects();
                    UpdateTasks();
                    MessageBox.Show("Project deleted!");
                }
                context.SaveChanges();
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

        private void NewTask_MouseUp(object sender, MouseButtonEventArgs e)
        {
            using (var context = new Unify_TasksEntities())
            {
                string path = Environment.CurrentDirectory + "\\Notes\\Note_" + w1.lastNote + 1 + ".rtf";
                context.Notes.Local.Add(new Note()
                {
                    Notepath = path,
                });
                context.SaveChanges();
                
                w1.lastNote += 1;

                context.Tasks.Local.Add(new Models.Task()
                {
                    ProjectID = w1.currProject,
                    Status = 0,
                    Header = "New Task",
                    NoteID = w1.lastNote,
                });
                context.SaveChanges();
            }
            UpdateTasks();
            MessageBox.Show("Task Created!");
        }
    }
}
