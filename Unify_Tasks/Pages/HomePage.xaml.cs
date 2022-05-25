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
using System.IO;

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
            MainWindow win = (MainWindow)Window.GetWindow(this);
            win.MinWidth = 1060;
            UserNameBox.Text = w1.userNickname;
            UpdateProjects();
        }

        public void UpdateProjects()
        {
            stackProjects.Children.Clear();
            try
            {
                if (w1.currUser != 0)
                {
                    using (var context = new Unify_TasksEntities())
                    {
                        var currProjects = from p in context.Projects
                                           where p.UserID == w1.currUser
                                           orderby p.ProjectID descending
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
                                    TrashProject.Visibility = Visibility.Visible;
                                    TrashRedProject.Visibility = Visibility.Visible;
                                    UpdateTasks();
                                };

                                stackProjects.Children.Add(project1);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while trying to update projects list.\r\n" +
                                        
                                        "Try to repeat the steps that led to the error. If the error still occurs,\r\n" +
                                        "please, contact the program developer");
            }
        }

        public void UpdateTasks()
        {
            try
            {
                TasksList.Children.Clear();
                if (w1.currProject != 0)
                {
                    using (var context1 = new Unify_TasksEntities())
                    {
                        var currTasks = from p in context1.Tasks
                                        where p.ProjectID == w1.currProject
                                        orderby p.TaskID descending
                                        select p;

                        if (currTasks != null)
                        {
                            foreach (var everyTask in currTasks)
                            {
                                TaskListElement task1 = new TaskListElement();
                                task1.TaskHeader.Text = everyTask.Header;
                                task1.Margin = new Thickness(5, 5, 0, 0);

                                task1.MouseEnter += (object s, MouseEventArgs ev) =>
                                {
                                    w1.currTask = everyTask.TaskID;
                                    task1.TasksID = everyTask.TaskID;
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

                                var thisTags = context1.Tags.Where(t => t.TaskID == everyTask.TaskID);

                                if(thisTags != null)
                                {
                                    task1.TagsList.Children.Clear();
                                    foreach (var everyTag in thisTags)
                                    {
                                        TagElement tag1 = new TagElement();
                                        tag1.TagText = everyTag.TagHeader;
                                        switch (Convert.ToInt32(everyTag.TagColor))
                                        {
                                            case 1:
                                                tag1.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomRed");
                                                break;
                                            case 2:
                                                tag1.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomGreen");
                                                break;
                                            case 3:
                                                tag1.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomBlue");
                                                break;
                                            case 4:
                                                tag1.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomBrown");
                                                break;
                                            case 5:
                                                tag1.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomGray");
                                                break;
                                            case 6:
                                                tag1.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomYellow");
                                                break;
                                            case 7:
                                                tag1.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomPink");
                                                break;
                                            case 8:
                                                tag1.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomPurple");
                                                break;
                                            default:
                                                Random random = new Random();
                                                int RInt = random.Next(1, 9);
                                                switch (RInt)
                                                {
                                                    case 1:
                                                        tag1.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomRed");
                                                        break;
                                                    case 2:
                                                        tag1.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomGreen");
                                                        break;
                                                    case 3:
                                                        tag1.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomBlue");
                                                        break;
                                                    case 4:
                                                        tag1.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomBrown");
                                                        break;
                                                    case 5:
                                                        tag1.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomGray");
                                                        break;
                                                    case 6:
                                                        tag1.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomYellow");
                                                        break;
                                                    case 7:
                                                        tag1.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomPink");
                                                        break;
                                                    case 8:
                                                        tag1.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomPurple");
                                                        break;
                                                }
                                                break;
                                        }

                                        tag1.MouseUp += (object sender, MouseButtonEventArgs e) =>
                                        {
                                            TagControlWindow tc1 = new TagControlWindow();
                                            tc1.Show();
                                        };

                                        tag1.Margin = new Thickness(5);

                                        task1.TagsList.Children.Add(tag1);
                                    }
                                }
                                

                                switch(everyTask.Status)
                                {
                                    case "Queue":
                                        task1.Status.Text = everyTask.Status;
                                        task1.Status.Foreground = (Brush)Application.Current.FindResource("CustomRed");
                                        break;
                                    case "In Progress":
                                        task1.Status.Text = everyTask.Status;
                                        task1.Status.Foreground = (Brush)Application.Current.FindResource("CustomYellow");
                                        break;
                                    case "Done":
                                        task1.Status.Text = everyTask.Status;
                                        task1.Status.Foreground = (Brush)Application.Current.FindResource("CustomGreen");
                                        break;
                                    case "Frozen":
                                        task1.Status.Text = everyTask.Status;
                                        task1.Status.Foreground = (Brush)Application.Current.FindResource("CustomBlue");
                                        break;
                                }

                                task1.StatusBorder.MouseUp += (object sender, MouseButtonEventArgs e) =>
                                {
                                    NoteEditor ed1 = new NoteEditor();
                                    ed1.Show();
                                };

                                task1.OpenNoteWhite.MouseUp += (object sender, MouseButtonEventArgs e) =>
                                {
                                    NoteEditor ed1 = new NoteEditor();
                                    ed1.Show();
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
                                
                                



                                TasksList.Children.Add(task1);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while trying to update task list.\r\n" +
                                        
                                        "Try to repeat the steps that led to the error. If the error still occurs,\r\n" +
                                        "please, contact the program developer");
            }
        }

        private void NewProject_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new Unify_TasksEntities())
                {
                    context.Projects.Local.Add(new Project()
                    {
                        ProjectHeader = "Untitled Project",
                        UserID = w1.currUser,
                    });
                    context.SaveChanges();
                }
                UpdateProjects();
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while trying to create new project.\r\n" +
                                        
                                        "Try to repeat the steps that led to the error. If the error still occurs,\r\n" +
                                        "please, contact the program developer");
            }
        }

        private void ProjectName_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Project toRename = null;
                using (var context = new Unify_TasksEntities())
                {
                    toRename = context.Projects.Where(p => p.ProjectID == w1.currProject).FirstOrDefault();

                    if (toRename != null)
                    {
                        toRename.ProjectHeader = ProjectName.Text;
                        context.SaveChanges();
                        UpdateProjects();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while trying to rename this project.\r\n" +
                                        
                                        "Try to repeat the steps that led to the error. If the error still occurs,\r\n" +
                                        "please, contact the program developer");
            }
        }

        public void DeleteProject()
        {
            try
            {
                if (w1.currProject != 0 && w1.currUser != 0)
                {
                    using (var context = new Unify_TasksEntities())
                    {
                        Project toDelete = null;
                        toDelete = context.Projects.Where(b => b.ProjectID == w1.currProject).FirstOrDefault();

                        if (toDelete != null)
                        {
                            var delTasks = from p in context.Tasks
                                           where p.ProjectID == w1.currProject
                                           select p;
                            if (delTasks != null)
                            {
                                foreach (var everyTask in delTasks)
                                {
                                    var delNotes = from h in context.Notes
                                                   where h.TaskID == everyTask.TaskID
                                                   select h;

                                    if (delNotes != null)
                                    {
                                        foreach (Note everyNote in delNotes)
                                        {
                                            try
                                            {
                                                File.Delete(w1.currPath + "/Notes/Note" + everyNote.NoteID + ".rtf");
                                            }
                                            catch (Exception)
                                            {
                                                MessageBox.Show("An error occurred while trying to delete this note rtf file.\r\n" +
                                                                "Try to repeat the steps that led to the error. If the error still occurs,\r\n" +
                                                                "please, contact the program developer");
                                            }

                                            context.Notes.Remove(everyNote);
                                        }
                                    }

                                    var delTags = from t in context.Tags
                                                  where t.TaskID == everyTask.TaskID
                                                  select t;

                                    if (delTags != null)
                                    {
                                        foreach (var everyTag in delTags)
                                        {
                                            context.Tags.Remove(everyTag);
                                        }
                                    }

                                    context.Tasks.Remove(everyTask);
                                }
                            }

                            context.Projects.Remove(toDelete);
                            context.SaveChanges();
                            w1.currProject = 0;
                            ProjectName.Visibility = Visibility.Hidden;
                            NewTask.Visibility = Visibility.Hidden;
                            TasksViewer.Visibility = Visibility.Hidden;
                            TrashProject.Visibility = Visibility.Hidden;
                            TrashRedProject.Visibility = Visibility.Hidden;
                            UpdateProjects();
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while trying to delete this project.\r\n" +
                                        "Try to repeat the steps that led to the error. If the error still occurs,\r\n" +
                                        "please, contact the program developer");
            }
        }

        private void NewTask_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (w1.currProject != 0)
                {
                    using (var context = new Unify_TasksEntities())
                    {
                        context.Tasks.Local.Add(new Models.Task()
                        {
                            ProjectID = w1.currProject,
                            Status = "Queue",
                            Header = "Untitled Task",
                            Priority = 0,
                        });
                        context.SaveChanges();
                    }
                    UpdateTasks();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while trying to create new task.\r\n" +
                                        
                                        "Try to repeat the steps that led to the error. If the error still occurs,\r\n" +
                                        "please, contact the program developer");
            }
        }

        public void DeleteTask(int toDeleteID)
        {
            try
            {
                if (toDeleteID != 0)
                {
                    using (var context = new Unify_TasksEntities())
                    {
                        Models.Note delNote = null;

                        var toDelete = context.Tasks.Where(b => b.TaskID == toDeleteID).FirstOrDefault();

                        if (toDelete != null)
                        {
                            delNote = context.Notes.Where(n => n.TaskID == toDelete.TaskID).FirstOrDefault();

                            if (delNote != null)
                            {
                                try
                                {
                                    File.Delete(w1.currPath + "/Notes/Note" + delNote.NoteID + ".rtf");
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("An error occurred while trying to delete this note rtf file.\r\n" +
                                                    "Try to repeat the steps that led to the error. If the error still occurs,\r\n" +
                                                    "please, contact the program developer");
                                }

                                context.Notes.Remove(delNote);
                            }


                            var delTags = context.Tags.Where(t => t.TaskID == toDeleteID);

                            if(delTags != null)
                            {
                                foreach(var everyTag in delTags)
                                {
                                    context.Tags.Remove(everyTag);
                                }
                            }

                            context.Tasks.Remove(toDelete);
                            context.SaveChanges();
                            UpdateTasks();
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while trying to delete this task.\r\n" +
                                        
                                        "Try to repeat the steps that led to the error. If the error still occurs,\r\n" +
                                        "please, contact the program developer");
            }
            
        }

        private void TrashRedProject_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result1 = MessageBox.Show("Are you sure you want to delete the project?", "Unify", MessageBoxButton.YesNo);
            switch (result1)
            {
                case MessageBoxResult.Yes:
                    DeleteProject();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void LogOf_MouseUp(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }

        private void TrashProject_MouseEnter(object sender, MouseEventArgs e)
        {
            TrashProject.Opacity = 0;
            TrashRedProject.Opacity = 1;
        }

        private void TrashProject_MouseLeave(object sender, MouseEventArgs e)
        {
            TrashProject.Opacity = 1;
            TrashRedProject.Opacity = 0;
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            

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
