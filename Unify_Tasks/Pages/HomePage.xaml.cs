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
            UpdateProjects();
        }

        public void UpdateProjects()
        {
            stackProjects.Children.Clear();
            if (w1.currUser != 0)
            {
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
        }

        public void UpdateTasks()
        {
            TasksList.Children.Clear();
            if (w1.currProject != 0)
            {
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
                            task1.TasksID = (int)everyTask.TaskID;
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
                                w1.currTask = task1.TasksID;
                            };
                            task1.TrashRed.MouseUp += (object sender, MouseButtonEventArgs e) =>
                            {
                                int toDeleteID = w1.currTask;
                                MessageBoxResult result1 = MessageBox.Show("Are you sure you want to delete the task?", "Unify", MessageBoxButton.YesNo);
                                switch (result1)
                                {
                                    case MessageBoxResult.Yes:
                                        DeleteTask(toDeleteID);
                                        break;
                                    case MessageBoxResult.No:
                                        break;
                                }
                            };
                            task1.TaskHeader.TextChanged += (object sender, TextChangedEventArgs e) =>
                            {
                                int toRenameID = w1.currTask;
                                if (toRenameID != 0)
                                {
                                    Models.Task toRename = null;
                                    using (var context = new Unify_TasksEntities())
                                    {
                                        toRename = context.Tasks.Where(b => b.TaskID == toRenameID).FirstOrDefault();

                                        if (toRename != null)
                                        {
                                            toRename.Header = task1.TaskHeader.Text;
                                            context.SaveChanges();
                                        }
                                    }
                                }
                            };
                            task1.IsReady.Checked += (object sender, RoutedEventArgs e) =>
                            {
                                if(w1.currTask != 0)
                                {
                                    using (var context = new Unify_TasksEntities())
                                    {
                                        Models.Task ThisTask = context.Tasks.Where(b => b.TaskID == w1.currTask).FirstOrDefault();

                                        if (ThisTask != null)
                                        {
                                            ThisTask.Status = 1;
                                            context.SaveChanges();
                                        }
                                    }
                                }
                            };
                            task1.IsReady.Unchecked += (object sender, RoutedEventArgs e) =>
                            {
                                if (w1.currTask != 0)
                                {
                                    using (var context = new Unify_TasksEntities())
                                    {
                                        Models.Task ThisTask = context.Tasks.Where(b => b.TaskID == w1.currTask).FirstOrDefault();

                                        if (ThisTask != null)
                                        {
                                            ThisTask.Status = 0;
                                            context.SaveChanges();
                                        }
                                    }
                                }
                            };
                            task1.WatchBlue.MouseUp += (object sender, MouseButtonEventArgs e) =>
                            {
                                int ThisID = w1.currTask;
                                DateWindow date1 = new DateWindow();
                                date1.ShowDialog();
                                if (date1.DialogResult != null)
                                    if (date1.DialogResult==true)
                                    {
                                        if(ThisID != 0)
                                        {
                                            using (var context = new Unify_TasksEntities())
                                            {
                                                Models.Task ThisTask = context.Tasks.Where(b => b.TaskID == w1.currTask).FirstOrDefault();

                                                if(ThisTask != null)
                                                {
                                                    ThisTask.Planned = w1.currDate;
                                                    context.SaveChanges();
                                                }
                                            }
                                        }
                                    }
                            };
                            /*task1.OpenNote.MouseUp += (object sender, MouseButtonEventArgs e) =>
                            {
                                NoteEditor ed1 = new NoteEditor();
                                ed1.ShowDialog();
                            };*/



                            TasksList.Children.Add(task1);
                        }
                    }
                }
            }
            
        }

        private void IsReady_Checked(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void DeleteTask(int toDeleteID)
        {
            if (toDeleteID != 0)
            {
                Models.Task toDelete = null;
                using (var context = new Unify_TasksEntities())
                {
                    toDelete = context.Tasks.Where(b => b.TaskID == toDeleteID).FirstOrDefault();

                    if (toDelete != null)
                    {
                        context.Tasks.Remove(toDelete);
                        context.SaveChanges();
                        UpdateTasks();
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

        public void DeleteProject()
        {
            if(w1.currProject != 0 && w1.currUser != 0)
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
                        context.SaveChanges();
                        w1.currProject = 0;
                        ProjectName.Visibility = Visibility.Hidden;
                        NewTask.Visibility = Visibility.Hidden;
                        TasksViewer.Visibility = Visibility.Hidden;
                        Trash.Visibility = Visibility.Hidden;
                        TrashRed.Visibility = Visibility.Hidden;
                        UpdateProjects();
                    }
                    context.SaveChanges();
                }
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
            if(w1.currProject != 0)
            {
                using (var context = new Unify_TasksEntities())
                {
                    context.Tasks.Local.Add(new Models.Task()
                    {
                        ProjectID = w1.currProject,
                        Status = 0,
                        Header = "New Task",
                    });
                    context.SaveChanges();
                }
                UpdateTasks();
                MessageBox.Show("Task Created!");
            }
        }

        private void ProjectName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Project toRename = null;
            using (var context = new Unify_TasksEntities())
            {
                toRename = context.Projects.Where(p => p.ProjectID == w1.currProject).FirstOrDefault();

                if(toRename != null)
                {
                    toRename.ProjectHeader = ProjectName.Text;
                    context.SaveChanges();
                    UpdateProjects();
                }
            }
        }
    }
}
