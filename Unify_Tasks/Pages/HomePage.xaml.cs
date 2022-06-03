using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using Unify_Tasks.DialogWindows;
using Unify_Tasks.UserControls;
using Unify_Tasks.Code_First_Classes;

namespace Unify_Tasks.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        static MainWindow w1 = (MainWindow)Application.Current.MainWindow;
        public int SortType = 0;
        public int renID = 0;

        public HomePage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow win = (MainWindow)Window.GetWindow(this);
            win.MinWidth = 1240;
            UserNameBox.Text = w1.userNickname;
            if (w1.userNickname.Length > 12)
            {
                UserNameBox.Margin = new Thickness(0);
            }
            if (w1.userNickname.Length > 8)
            {
                UserNameBox.FontSize = 12;
            }
            if (w1.userNickname.Length > 6)
            {
                UserNameBox.FontSize = 18;
            }
            UpdateProjects();
        }

        public void UpdateProjects()
        {
            stackProjects.Children.Clear();
            try
            {
                if (w1.currUser != 0)
                {
                    using (var context = new Context1())
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
                                    Tools.Visibility = Visibility.Visible;
                                    NewTask.Visibility = Visibility.Visible;
                                    TasksViewer.Visibility = Visibility.Visible;
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
                    using (var context1 = new Context1())
                    {
                        var currTasks = from p in context1.Tasks
                                        where p.ProjectID == w1.currProject
                                        select p;
                        switch (SortType)
                        {
                            case 1: //Newest
                                currTasks = from p in context1.Tasks
                                            where p.ProjectID == w1.currProject
                                            orderby p.TaskID descending
                                            select p;
                                break;
                            case 2: //Oldest
                                currTasks = from p in context1.Tasks
                                            where p.ProjectID == w1.currProject
                                            orderby p.TaskID ascending
                                            select p;
                                break;
                            case 3: //Alphabet
                                currTasks = from p in context1.Tasks
                                            where p.ProjectID == w1.currProject
                                            orderby p.Header ascending
                                            select p;
                                break;
                            case 4: //Status
                                currTasks = from p in context1.Tasks
                                            where p.ProjectID == w1.currProject
                                            orderby p.Status descending
                                            select p;
                                break;
                            case 5: //Date
                                currTasks = from p in context1.Tasks
                                            where p.ProjectID == w1.currProject
                                            orderby p.Planned ascending
                                            select p;
                                break;
                        }


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
                                    w1.currDate = everyTask.Planned;
                                    task1.TasksID = everyTask.TaskID;
                                };
                                task1.TaskHeader.TextChanged += (object sender, TextChangedEventArgs e) =>
                                {
                                    renID = task1.TasksID;
                                    if (renID != 0)
                                    {
                                        Task toRename = null;
                                        using (var context = new Context1())
                                        {
                                            toRename = context.Tasks.Where(b => b.TaskID == renID).FirstOrDefault();

                                            if (toRename != null)
                                            {
                                                toRename.Header = task1.TaskHeader.Text;
                                                context.SaveChanges();
                                            }
                                        }
                                    }
                                };

                                var thisTags = context1.Tags.Where(t => t.TaskID == everyTask.TaskID);

                                if (thisTags != null)
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
                                            /*TagControlWindow tc1 = new TagControlWindow();
                                            tc1.Show();*/
                                            TaskWindow tw1 = new TaskWindow();
                                            tw1.ShowDialog();
                                        };

                                        tag1.Margin = new Thickness(5);

                                        task1.TagsList.Children.Add(tag1);
                                    }
                                }

                                switch (everyTask.Status)
                                {
                                    case "None":
                                        task1.Status.Text = everyTask.Status;
                                        task1.StatusBorder.Background = Brushes.Transparent;
                                        break;
                                    case "Queue":
                                        task1.Status.Text = everyTask.Status;
                                        task1.StatusBorder.Background = (Brush)Application.Current.FindResource("CustomRed");
                                        break;
                                    case "In Progress":
                                        task1.Status.Text = everyTask.Status;
                                        task1.StatusBorder.Background = (Brush)Application.Current.FindResource("CustomYellow");
                                        break;
                                    case "Done":
                                        task1.Status.Text = everyTask.Status;
                                        task1.StatusBorder.Background = (Brush)Application.Current.FindResource("CustomGreen");
                                        break;
                                    case "Frozen":
                                        task1.Status.Text = everyTask.Status;
                                        task1.StatusBorder.Background = (Brush)Application.Current.FindResource("CustomBlue");
                                        break;
                                }

                                switch (everyTask.Priority)
                                {
                                    case 0:
                                        task1.Priority.Text = "Pn";
                                        task1.PriorityBorder.Background = Brushes.Transparent;
                                        break;
                                    case 1:
                                        task1.Priority.Text = "P1";
                                        task1.PriorityBorder.Background = (Brush)Application.Current.FindResource("CustomRed");
                                        break;
                                    case 2:
                                        task1.Priority.Text = "P2";
                                        task1.PriorityBorder.Background = (Brush)Application.Current.FindResource("CustomYellow");
                                        break;
                                    case 3:
                                        task1.Priority.Text = "P3";
                                        task1.PriorityBorder.Background = (Brush)Application.Current.FindResource("CustomGreen");
                                        break;
                                    case 4:
                                        task1.Priority.Text = "P4";
                                        task1.PriorityBorder.Background = (Brush)Application.Current.FindResource("CustomBlue");
                                        break;
                                }

                                if (everyTask.Planned != null)
                                {
                                    DateTime datenow = DateTime.Now;
                                    DateTime thisDate = new DateTime();
                                    thisDate = (DateTime)everyTask.Planned;
                                    task1.Date.Text = thisDate.ToShortDateString();
                                    if(thisDate < datenow)
                                    {
                                        task1.Date.Foreground = (Brush)Application.Current.FindResource("CustomRed");
                                    }
                                    else
                                    {
                                        task1.Date.Foreground = (Brush)Application.Current.FindResource("MainI");
                                    }
                                }
                                else
                                {
                                    task1.Date.Text = "No date";
                                }

                                task1.StatusBorder.MouseUp += (object sender, MouseButtonEventArgs e) =>
                                {
                                    TaskWindow tw1 = new TaskWindow();
                                    tw1.ShowDialog();
                                    UpdateTasks();
                                };

                                task1.StatusBorder.MouseEnter += (object s, MouseEventArgs ev) =>
                                {
                                    task1.StatusBorder.BorderBrush = (Brush)Application.Current.FindResource("MainI");
                                };
                                task1.StatusBorder.MouseLeave += (object s, MouseEventArgs ev) =>
                                {
                                    task1.StatusBorder.BorderBrush = (Brush)Application.Current.FindResource("GrayI");
                                };

                                task1.PriorityBorder.MouseUp += (object sender, MouseButtonEventArgs e) =>
                                {
                                    TaskWindow tw1 = new TaskWindow();
                                    tw1.ShowDialog();
                                    UpdateTasks();
                                };

                                task1.PriorityBorder.MouseEnter += (object s, MouseEventArgs ev) =>
                                {
                                    task1.PriorityBorder.BorderBrush = (Brush)Application.Current.FindResource("MainI");
                                };
                                task1.PriorityBorder.MouseLeave += (object s, MouseEventArgs ev) =>
                                {
                                    task1.PriorityBorder.BorderBrush = (Brush)Application.Current.FindResource("GrayI");
                                };

                                task1.DateBorder.MouseUp += (object sender, MouseButtonEventArgs e) =>
                                {
                                    TaskWindow tw1 = new TaskWindow();
                                    tw1.ShowDialog();
                                    UpdateTasks();
                                };

                                task1.DateBorder.MouseEnter += (object s, MouseEventArgs ev) =>
                                {
                                    task1.DateBorder.BorderBrush = (Brush)Application.Current.FindResource("MainI");
                                };
                                task1.DateBorder.MouseLeave += (object s, MouseEventArgs ev) =>
                                {
                                    task1.DateBorder.BorderBrush = (Brush)Application.Current.FindResource("GrayI");
                                };

                                task1.OpenNoteWhite.MouseUp += (object sender, MouseButtonEventArgs e) =>
                                {
                                    TaskWindow tw1 = new TaskWindow();
                                    tw1.ShowDialog();
                                    UpdateTasks();
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
                using (var context = new Context1())
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
            if (ProjectName.LineCount <= 2)
            {
                ProjectName.FontSize = 40;
            }
            if (ProjectName.LineCount > 2)
            {
                ProjectName.FontSize = 30;
            }

            try
            {
                Project toRename = null;
                using (var context = new Context1())
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
                    using (var context = new Context1())
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
                            Tools.Visibility = Visibility.Hidden;
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
                    using (var context = new Context1())
                    {
                        context.Tasks.Local.Add(new Task()
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
                    using (var context = new Context1())
                    {
                        Note delNote = null;

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

                            if (delTags != null)
                            {
                                foreach (var everyTag in delTags)
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

        private void TrashProject_MouseUp(object sender, MouseButtonEventArgs e)
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

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void Tool1_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            NewTask.Background = (Brush)Application.Current.FindResource("CustomGreen");
        }
        private void Tool1_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            NewTask.Background = (Brush)Application.Current.FindResource("BackI");
        }

        private void Tool2_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            SortBorder.Background = (Brush)Application.Current.FindResource("CustomYellow");
        }
        private void Tool2_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            SortBorder.Background = (Brush)Application.Current.FindResource("BackI");
        }

        private void Tool3_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            EditBorder.Background = (Brush)Application.Current.FindResource("CustomBrown");
        }
        private void Tool3_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            EditBorder.Background = (Brush)Application.Current.FindResource("BackI");
        }

        private void Tool4_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            DeleteBorder.Background = (Brush)Application.Current.FindResource("CustomRed");
        }
        private void Tool4_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            DeleteBorder.Background = (Brush)Application.Current.FindResource("BackI");
        }

        private void RenameProject()
        {
            ProjectName.Focus();
            ProjectName.SelectionStart = ProjectName.Text.Length;
        }

        private void SortBorder_MouseUp(object sender, MouseButtonEventArgs e)
        {
            switch (SortType)
            {
                case 0:
                    Sort.Text = "Sort by: Newest";
                    SortType++;
                    UpdateTasks();
                    break;
                case 1:
                    Sort.Text = "Sort by: Oldest";
                    SortType++;
                    UpdateTasks();
                    break;
                case 2:
                    Sort.Text = "Sort by: Alphabet";
                    SortType++;
                    UpdateTasks();
                    break;
                case 3:
                    Sort.Text = "Sort by: Status";
                    SortType++;
                    UpdateTasks();
                    break;
                case 4:
                    Sort.Text = "Sort by: Date";
                    SortType++;
                    UpdateTasks();
                    break;
                case 5:
                    Sort.Text = "Sort by: Newest";
                    SortType = 1;
                    UpdateTasks();
                    break;
            }
        }

        private void EditBorder_MouseUp(object sender, MouseButtonEventArgs e)
        {
            RenameProject();
        }

        private void DeleteBorder_MouseUp(object sender, MouseButtonEventArgs e)
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
    }
}
