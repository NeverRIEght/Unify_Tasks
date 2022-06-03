using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Unify_Tasks.Models;
using Unify_Tasks.UserControls;

namespace Unify_Tasks.DialogWindows
{
    /// <summary>
    /// Логика взаимодействия для TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        static MainWindow w1 = (MainWindow)Application.Current.MainWindow;
        int currNote = 0;
        int CursorPos = 0;

        public TaskWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateHeader();
            UpdateTags();
            UpdateStatus();
            UpdatePriority();
            UpdateDate();

            OpenNote();

            TaskName.Focus();
            TaskName.SelectionStart = TaskName.Text.Length;
        }

        private void OpenNote()
        {
            try
            {
                using (var context = new Unify_TasksEntities())
                {
                    Models.Note currentNote = null;
                    currentNote = context.Notes.Where(n => n.TaskID == w1.currTask).FirstOrDefault();

                    if (currentNote != null)
                    {
                        currNote = currentNote.NoteID;

                        using (FileStream fs = File.OpenRead(w1.currPath + "/Notes/Note" + currNote + ".rtf"))
                        {
                            TextRange range1 = new TextRange(NoteText.Document.ContentStart, NoteText.Document.ContentEnd);
                            range1.Load(fs, DataFormats.Rtf);
                            CursorPos = new TextRange(NoteText.Document.ContentStart, NoteText.Document.ContentEnd).Text.Length;
                            GetSelectedText();
                        }
                    }
                    else if (currentNote == null)
                    {
                        currNote = 0;
                        CursorPos = 0;
                        GetSelectedText();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while trying to open note.\r\n" +

                                        "Try to repeat the steps that led to the error. If the error still occurs,\r\n" +
                                        "please, contact the program developer");
            }
        }

        private void SaveNote()
        {
            try
            {
                using (var context = new Unify_TasksEntities())
                {
                    if (currNote != 0)
                    {
                        using (FileStream fs = File.Create(w1.currPath + "/Notes/Note" + currNote + ".rtf"))
                        {
                            TextRange range1 = new TextRange(NoteText.Document.ContentStart, NoteText.Document.ContentEnd);
                            range1.Save(fs, DataFormats.Rtf);
                        }
                    }
                    if (currNote == 0)
                    {
                        currNote = Calculate_LastNote() + 1;
                        context.Notes.Local.Add(new Note()
                        {
                            Notepath = w1.currPath + "/Notes/Note" + currNote + ".rtf",
                            TaskID = w1.currTask,
                        });
                        context.SaveChanges();

                        var thisNote = context.Notes.Where(n => n.Notepath == w1.currPath + "/Notes/Note" + currNote + ".rtf").FirstOrDefault();

                        currNote = thisNote.NoteID;
                        thisNote.Notepath = w1.currPath + "/Notes/Note" + thisNote.NoteID + ".rtf";

                        using (FileStream fs = File.Create(w1.currPath + "/Notes/Note" + currNote + ".rtf"))
                        {
                            TextRange range1 = new TextRange(NoteText.Document.ContentStart, NoteText.Document.ContentEnd);
                            range1.Save(fs, DataFormats.Rtf);

                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while trying to save this note.\r\n" +

                                        "Try to repeat the steps that led to the error. If the error still occurs,\r\n" +
                                        "please, contact the program developer");
            }
        }

        private void UpdateHeader()
        {
            try
            {
                using (var context = new Unify_TasksEntities())
                {
                    var thisTask = context.Tasks.Where(t => t.TaskID == w1.currTask).FirstOrDefault();
                    if (thisTask != null)
                    {
                        TaskName.Text = thisTask.Header;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while trying to update header for this task.\r\n" +

                                        "Try to repeat the steps that led to the error. If the error still occurs,\r\n" +
                                        "please, contact the program developer");
            }
        }

        private void UpdateTags()
        {
            try
            {
                TagsList.Children.Clear();
                using (var context = new Unify_TasksEntities())
                {
                    var Tags = context.Tags.Where(t => t.TaskID == w1.currTask);

                    if (Tags != null)
                    {
                        foreach (var everyTag in Tags)
                        {
                            TagElement tag1 = new TagElement();
                            tag1.TagText = everyTag.TagHeader;

                            tag1.MouseEnter += (sender, e) =>
                            {
                                this.Cursor = Cursors.Hand;
                            };
                            tag1.MouseLeave += (sender, e) =>
                            {
                                this.Cursor = Cursors.Arrow;
                            };

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
                            tag1.Margin = new Thickness(5);
                            TagsList.Children.Add(tag1);
                        }
                    }
                    if (TagsList.Children.Count == 0)
                    {
                        Border newBorder = new Border();
                        newBorder.BorderBrush = Brushes.White;
                        newBorder.BorderThickness = new Thickness(1);
                        newBorder.CornerRadius = new CornerRadius(6);

                        StackPanel stack1 = new StackPanel();
                        stack1.Orientation = Orientation.Horizontal;
                        Image addTagImage = new Image();
                        TextBlock addTagText = new TextBlock();

                        addTagImage.Source = new BitmapImage(new Uri("/Images/NewTask.png", UriKind.Relative));
                        addTagImage.Margin = new Thickness(5, 0, 5, 0);
                        addTagImage.Height = 14;
                        stack1.Children.Add(addTagImage);

                        addTagText.Text = "New Tag";
                        addTagText.FontSize = 18;
                        addTagText.FontWeight = FontWeights.Medium;
                        addTagText.Margin = new Thickness(0, 0, 5, 2);
                        stack1.Children.Add(addTagText);

                        newBorder.Child = stack1;
                        newBorder.Margin = new Thickness(5);

                        newBorder.MouseEnter += (sender, e) =>
                        {
                            this.Cursor = Cursors.Hand;
                        };

                        newBorder.MouseLeave += (sender, e) =>
                        {
                            this.Cursor = Cursors.Arrow;
                        };

                        TagsList.Children.Add(newBorder);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while trying to update tags for this task.\r\n" +

                                        "Try to repeat the steps that led to the error. If the error still occurs,\r\n" +
                                        "please, contact the program developer");
            }
            

        }

        private void UpdateStatus()
        {
            try
            {
                StatusWrap.Children.Clear();
                using (var context = new Unify_TasksEntities())
                {
                    Models.Task thisTask = null;
                    thisTask = context.Tasks.Where(t => t.TaskID == w1.currTask).FirstOrDefault();

                    if (thisTask != null)
                    {
                        TagElement tag1 = new TagElement();
                        tag1.Margin = new Thickness(5);

                        tag1.MouseEnter += (sender, e) =>
                        {
                            this.Cursor = Cursors.Hand;
                        };

                        tag1.MouseLeave += (sender, e) =>
                        {
                            this.Cursor = Cursors.Arrow;
                        };

                        switch (thisTask.Status)
                        {
                            case "Queue":
                                tag1.TagText = thisTask.Status;
                                tag1.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomRed");
                                StatusWrap.Children.Add(tag1);
                                break;
                            case "In Progress":
                                tag1.TagText = thisTask.Status;
                                tag1.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomYellow");
                                StatusWrap.Children.Add(tag1);
                                break;
                            case "Done":
                                tag1.TagText = thisTask.Status;
                                tag1.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomGreen");
                                StatusWrap.Children.Add(tag1);
                                break;
                            case "Frozen":
                                tag1.TagText = thisTask.Status;
                                tag1.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomBlue");
                                StatusWrap.Children.Add(tag1);
                                break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while trying to update status for this task.\r\n" +

                                        "Try to repeat the steps that led to the error. If the error still occurs,\r\n" +
                                        "please, contact the program developer");
            }
            
        }

        private void UpdatePriority()
        {
            try
            {
                PriorityWrap.Children.Clear();
                using (var context = new Unify_TasksEntities())
                {
                    Models.Task thisTask = null;
                    thisTask = context.Tasks.Where(t => t.TaskID == w1.currTask).FirstOrDefault();

                    if (thisTask != null)
                    {
                        TagElement tag1 = new TagElement();
                        tag1.Margin = new Thickness(5);

                        tag1.MouseEnter += (sender, e) =>
                        {
                            this.Cursor = Cursors.Hand;
                        };

                        tag1.MouseLeave += (sender, e) =>
                        {
                            this.Cursor = Cursors.Arrow;
                        };

                        switch (thisTask.Priority)
                        {
                            case 4:
                                tag1.TagText = "P" + Convert.ToString(thisTask.Priority);
                                tag1.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomBlue");
                                PriorityWrap.Children.Add(tag1);
                                break;
                            case 3:
                                tag1.TagText = "P" + Convert.ToString(thisTask.Priority);
                                tag1.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomGreen");
                                PriorityWrap.Children.Add(tag1);
                                break;
                            case 2:
                                tag1.TagText = "P" + Convert.ToString(thisTask.Priority);
                                tag1.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomYellow");
                                PriorityWrap.Children.Add(tag1);
                                break;
                            case 1:
                                tag1.TagText = "P" + Convert.ToString(thisTask.Priority);
                                tag1.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomRed");
                                PriorityWrap.Children.Add(tag1);
                                break;
                            case 0:
                                tag1.TagText = "No priority";
                                tag1.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomGray");
                                PriorityWrap.Children.Add(tag1);
                                break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while trying to update priority for this task.\r\n" +

                                        "Try to repeat the steps that led to the error. If the error still occurs,\r\n" +
                                        "please, contact the program developer");
            }
            
        }

        private void UpdateDate()
        {
            try
            {
                DateWrap.Children.Clear();
                using (var context = new Unify_TasksEntities())
                {
                    Models.Task thisTask = null;
                    thisTask = context.Tasks.Where(t => t.TaskID == w1.currTask).FirstOrDefault();

                    if (thisTask != null)
                    {
                        if (thisTask.Planned != null)
                        {
                            TagElement tag1 = new TagElement();
                            DateTime thisDate = new DateTime();
                            DateTime datenow = DateTime.Now;
                            thisDate = (DateTime)thisTask.Planned;
                            tag1.TagText = thisDate.ToShortDateString();
                            tag1.Margin = new Thickness(5);

                            if (thisDate < datenow)
                            {
                                tag1.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomRed");
                                PlannedCalendar.DisplayDateStart = thisDate;
                            }
                            else
                            {
                                tag1.TagBackgroud.Background = Brushes.Transparent;
                                PlannedCalendar.DisplayDateStart = datenow;
                            }

                            DateWrap.Children.Add(tag1);
                        }
                        else
                        {
                            TagElement tag1 = new TagElement();
                            tag1.TagText = "No date";
                            tag1.Margin = new Thickness(5);
                            DateWrap.Children.Add(tag1);
                            PlannedCalendar.DisplayDateStart = DateTime.Now;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while trying to update date for this task.\r\n" +

                                        "Try to repeat the steps that led to the error. If the error still occurs,\r\n" +
                                        "please, contact the program developer");
            }
            
        }

        private void UpdateTaskTags()
        {
            UpdateTags();
            TaskTagsList.Children.Clear();
            try
            {
                using (var context = new Unify_TasksEntities())
                {
                    var thisTags = context.Tags.Where(t => t.TaskID == w1.currTask);

                    if (thisTags != null)
                    {
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

                            TagElement tag2 = new TagElement();

                            tag2.TagBackgroud.Background = tag1.TagBackgroud.Background;

                            tag1.MouseEnter += (s, ev) =>
                            {
                                tag1.TagBackgroud.Background = Brushes.Red;
                                InfoText.Text = "Click to delete this tag";
                            };

                            tag1.MouseLeave += (s, ev) =>
                            {
                                tag1.TagBackgroud.Background = tag2.TagBackgroud.Background;
                                InfoText.Text = "Choose from list or create new";
                            };

                            tag1.MouseUp += (object se, MouseButtonEventArgs ev) =>
                            {
                                using (var context1 = new Unify_TasksEntities())
                                {
                                    Models.Tag thisTag = null;
                                    thisTag = context1.Tags.Where(t => t.TagID == everyTag.TagID).FirstOrDefault();

                                    if (thisTag != null)
                                    {
                                        context1.Tags.Remove(thisTag);
                                        context1.SaveChanges();
                                        UpdateBothTags();
                                        NewTagText.Focus();
                                        NewTagText.SelectionStart = NewTagText.Text.Length;
                                    }
                                }
                            };

                            tag1.Margin = new Thickness(5);

                            TaskTagsList.Children.Add(tag1);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while trying to update tags for this task.\r\n" +

                                        "Try to repeat the steps that led to the error. If the error still occurs,\r\n" +
                                        "please, contact the program developer");
            }
            
        }

        private void UpdateProjectTags()
        {
            try
            {
                ProjectTagsList.Children.Clear();

                using (var context = new Unify_TasksEntities())
                {
                    var Tags = from t in context.Tags
                               where t.ProjectID == w1.currProject
                               orderby t.TagID descending
                               select t;

                    if (Tags != null)
                    {
                        foreach (var everyTag in Tags)
                        {
                            TagElement tag1 = new TagElement();
                            tag1.TagText = everyTag.TagHeader;
                            tag1.Margin = new Thickness(5);
                            tag1.MaxWidth = 200;
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
                            }

                            TagElement tag2 = new TagElement();

                            tag2.TagBackgroud.Background = tag1.TagBackgroud.Background;

                            tag1.MouseEnter += (s, ev) =>
                            {
                                tag1.TagBackgroud.Background = Brushes.Green;
                                InfoText.Text = "MouseLeft - apply tag, MouseRight - change color";
                            };
                            tag1.MouseLeave += (s, ev) =>
                            {
                                tag1.TagBackgroud.Background = tag2.TagBackgroud.Background;
                                InfoText.Text = "Choose from list or create new";
                            };

                            tag1.MouseLeftButtonUp += (object se, MouseButtonEventArgs ev) =>
                            {
                                using (var context1 = new Unify_TasksEntities())
                                {
                                    Models.Task thisTask = null;
                                    thisTask = context1.Tasks.Where(t => t.TaskID == w1.currTask).FirstOrDefault();

                                    if (thisTask != null)
                                    {
                                        var thisTaskTags = context1.Tags.Where(t => t.TaskID == w1.currTask);
                                        int Exists = 0;
                                        if (thisTaskTags != null)
                                        {

                                            foreach (var t in thisTaskTags)
                                            {
                                                if (t.TagHeader == everyTag.TagHeader)
                                                {
                                                    Exists = 1;
                                                }
                                            }
                                        }
                                        if (Exists == 0)
                                        {
                                            context1.Tags.Local.Add(new Tag()
                                            {
                                                TaskID = thisTask.TaskID,
                                                ProjectID = thisTask.ProjectID,
                                                TagHeader = everyTag.TagHeader,
                                                TagColor = everyTag.TagColor,
                                            });
                                            context1.SaveChanges();
                                            UpdateBothTags();
                                        }
                                    }
                                }

                            };

                            tag1.MouseRightButtonUp += (object se, MouseButtonEventArgs ev) =>
                            {
                                using (var context1 = new Unify_TasksEntities())
                                {
                                    Models.Tag thisTag = null;
                                    thisTag = context1.Tags.Where(t => t.TagID == everyTag.TagID).FirstOrDefault();

                                    try
                                    {
                                        int currColor = Convert.ToInt32(thisTag.TagColor);
                                        switch (currColor)
                                        {
                                            case 1:
                                                currColor++;
                                                break;
                                            case 2:
                                                currColor++;
                                                break;
                                            case 3:
                                                currColor++;
                                                break;
                                            case 4:
                                                currColor++;
                                                break;
                                            case 5:
                                                currColor++;
                                                break;
                                            case 6:
                                                currColor++;
                                                break;
                                            case 7:
                                                currColor++;
                                                break;
                                            case 8:
                                                currColor = 1;
                                                break;
                                        }

                                        thisTag.TagColor = Convert.ToString(currColor);
                                        context1.SaveChanges();
                                        UpdateBothTags();
                                    }
                                    catch (Exception)
                                    {
                                        MessageBox.Show("An error occurred while trying to change this tag`s color.\r\n" +
                                            "Try to repeat the steps that led to the error. If the error still occurs,\r\n" +
                                            "please, contact the program developer");
                                    }
                                }
                            };

                            ProjectTagsList.Children.Add(tag1);

                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while trying to update tags for this project.\r\n" +

                                        "Try to repeat the steps that led to the error. If the error still occurs,\r\n" +
                                        "please, contact the program developer");
            }
            
        }

        private void UpdateBothTags()
        {
            TextBox newtag = new TextBox();
            newtag = NewTagText;

            UpdateTaskTags();
            UpdateProjectTags();

            TaskTagsList.Children.Add(newtag);



            TagsPop.IsOpen = true;
            NewTagText.Focus();
            NewTagText.SelectionStart = NewTagText.Text.Length;
        }

        private void TagsList_MouseUp(object sender, MouseButtonEventArgs e)
        {
            UpdateBothTags();
        }

        private void StatusWrap_MouseUp(object sender, MouseButtonEventArgs e)
        {
            EditStatusStack.Children.Clear();
            TagElement tag1 = new TagElement();
            TagElement tag2 = new TagElement();
            TagElement tag3 = new TagElement();
            TagElement tag4 = new TagElement();

            tag1.Margin = new Thickness(5, 0, 5, 5);
            tag2.Margin = new Thickness(5, 0, 5, 5);
            tag3.Margin = new Thickness(5, 0, 5, 5);
            tag4.Margin = new Thickness(5, 0, 5, 5);

            tag1.MouseUp += (object se, MouseButtonEventArgs er) =>
            {
                using (var context = new Unify_TasksEntities())
                {
                    Models.Task thisTask = null;
                    thisTask = context.Tasks.Where(t => t.TaskID == w1.currTask).FirstOrDefault();

                    if (thisTask != null)
                    {
                        thisTask.Status = "Queue";
                        context.SaveChanges();
                    }
                }

                StatusPop.IsOpen = false;
                UpdateStatus();
            };
            tag2.MouseUp += (object se, MouseButtonEventArgs er) =>
            {
                using (var context = new Unify_TasksEntities())
                {
                    Models.Task thisTask = null;
                    thisTask = context.Tasks.Where(t => t.TaskID == w1.currTask).FirstOrDefault();

                    if (thisTask != null)
                    {
                        thisTask.Status = "In Progress";
                        context.SaveChanges();
                    }
                }

                StatusPop.IsOpen = false;
                UpdateStatus();
            };
            tag3.MouseUp += (object se, MouseButtonEventArgs er) =>
            {
                using (var context = new Unify_TasksEntities())
                {
                    Models.Task thisTask = null;
                    thisTask = context.Tasks.Where(t => t.TaskID == w1.currTask).FirstOrDefault();

                    if (thisTask != null)
                    {
                        thisTask.Status = "Done";
                        context.SaveChanges();
                    }
                }

                StatusPop.IsOpen = false;
                UpdateStatus();
            };
            tag4.MouseUp += (object se, MouseButtonEventArgs er) =>
            {
                using (var context = new Unify_TasksEntities())
                {
                    Models.Task thisTask = null;
                    thisTask = context.Tasks.Where(t => t.TaskID == w1.currTask).FirstOrDefault();

                    if (thisTask != null)
                    {
                        thisTask.Status = "Frozen";
                        context.SaveChanges();
                    }
                }

                StatusPop.IsOpen = false;
                UpdateStatus();
            };

            tag1.TagText = "Queue";
            tag1.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomRed");
            EditStatusStack.Children.Add(tag1);

            tag2.TagText = "In Progress";
            tag2.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomYellow");
            EditStatusStack.Children.Add(tag2);

            tag3.TagText = "Done";
            tag3.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomGreen");
            EditStatusStack.Children.Add(tag3);

            tag4.TagText = "Frozen";
            tag4.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomBlue");
            EditStatusStack.Children.Add(tag4);

            StatusPop.IsOpen = true;
        }

        private void PriorityWrap_MouseUp(object sender, MouseButtonEventArgs e)
        {
            EditPriorityStack.Children.Clear();
            TagElement tag1 = new TagElement();
            TagElement tag2 = new TagElement();
            TagElement tag3 = new TagElement();
            TagElement tag4 = new TagElement();
            TagElement tag5 = new TagElement();

            tag1.Margin = new Thickness(5, 0, 5, 5);
            tag2.Margin = new Thickness(5, 0, 5, 5);
            tag3.Margin = new Thickness(5, 0, 5, 5);
            tag4.Margin = new Thickness(5, 0, 5, 5);
            tag5.Margin = new Thickness(5, 0, 5, 5);

            tag1.MouseUp += (object se, MouseButtonEventArgs er) =>
            {
                using (var context = new Unify_TasksEntities())
                {
                    Models.Task thisTask = null;
                    thisTask = context.Tasks.Where(t => t.TaskID == w1.currTask).FirstOrDefault();

                    if (thisTask != null)
                    {
                        thisTask.Priority = 4;
                        context.SaveChanges();
                    }
                }

                PriorityPop.IsOpen = false;
                UpdatePriority();
            };
            tag2.MouseUp += (object se, MouseButtonEventArgs er) =>
            {
                using (var context = new Unify_TasksEntities())
                {
                    Models.Task thisTask = null;
                    thisTask = context.Tasks.Where(t => t.TaskID == w1.currTask).FirstOrDefault();

                    if (thisTask != null)
                    {
                        thisTask.Priority = 3;
                        context.SaveChanges();
                    }
                }

                PriorityPop.IsOpen = false;
                UpdatePriority();
            };
            tag3.MouseUp += (object se, MouseButtonEventArgs er) =>
            {
                using (var context = new Unify_TasksEntities())
                {
                    Models.Task thisTask = null;
                    thisTask = context.Tasks.Where(t => t.TaskID == w1.currTask).FirstOrDefault();

                    if (thisTask != null)
                    {
                        thisTask.Priority = 2;
                        context.SaveChanges();
                    }
                }

                PriorityPop.IsOpen = false;
                UpdatePriority();
            };
            tag4.MouseUp += (object se, MouseButtonEventArgs er) =>
            {
                using (var context = new Unify_TasksEntities())
                {
                    Models.Task thisTask = null;
                    thisTask = context.Tasks.Where(t => t.TaskID == w1.currTask).FirstOrDefault();

                    if (thisTask != null)
                    {
                        thisTask.Priority = 1;
                        context.SaveChanges();
                    }
                }

                PriorityPop.IsOpen = false;
                UpdatePriority();
            };
            tag5.MouseUp += (object se, MouseButtonEventArgs er) =>
            {
                using (var context = new Unify_TasksEntities())
                {
                    Models.Task thisTask = null;
                    thisTask = context.Tasks.Where(t => t.TaskID == w1.currTask).FirstOrDefault();

                    if (thisTask != null)
                    {
                        thisTask.Priority = 0;
                        context.SaveChanges();
                    }
                }

                PriorityPop.IsOpen = false;
                UpdatePriority();
            };

            tag1.TagText = "P4";
            tag1.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomBlue");
            EditPriorityStack.Children.Add(tag1);

            tag2.TagText = "P3";
            tag2.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomGreen");
            EditPriorityStack.Children.Add(tag2);

            tag3.TagText = "P2";
            tag3.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomYellow");
            EditPriorityStack.Children.Add(tag3);

            tag4.TagText = "P1";
            tag4.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomRed");
            EditPriorityStack.Children.Add(tag4);

            tag5.TagText = "No priority";
            tag5.TagBackgroud.Background = (Brush)Application.Current.FindResource("CustomGray");
            EditPriorityStack.Children.Add(tag5);

            PriorityPop.IsOpen = true;
        }

        private void DateWrap_MouseUp(object sender, MouseButtonEventArgs e)
        {
            using (var context = new Unify_TasksEntities())
            {
                Models.Task thisTask = null;
                thisTask = context.Tasks.Where(t => t.TaskID == w1.currTask).FirstOrDefault();

                if (thisTask != null)
                {
                    if (thisTask.Planned != null)
                    {
                        PlannedCalendar.SelectedDate = thisTask.Planned;
                    }
                }
            }
            DatePop.IsOpen = true;
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime datenow = DateTime.Now;

            using (var context = new Unify_TasksEntities())
            {
                Models.Task thisTask = null;
                thisTask = context.Tasks.Where(t => t.TaskID == w1.currTask).FirstOrDefault();

                if (thisTask != null)
                {
                    if(thisTask.Planned >= datenow)
                    {
                        PlannedCalendar.DisplayDateStart = datenow;
                        thisTask.Planned = PlannedCalendar.SelectedDate;
                    }
                    else
                    {
                        PlannedCalendar.DisplayDateStart = thisTask.Planned;
                        thisTask.Planned = PlannedCalendar.SelectedDate;
                    }
                    
                    context.SaveChanges();
                    UpdateDate();
                }
            }
        }

        private void TaskName_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (var context = new Unify_TasksEntities())
            {
                Models.Task thisTask = null;
                thisTask = context.Tasks.Where(t => t.TaskID == w1.currTask).FirstOrDefault();

                if (thisTask != null)
                {
                    thisTask.Header = TaskName.Text;
                    context.SaveChanges();
                }
            }
        }

        private void NewTagText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NewTagText.Text != "")
            {
                InfoText.Text = "Press Enter to add new tag";
            }
            else
            {
                InfoText.Text = "Choose from list or create new";
            }
        }

        private void NewTagText_KeyUp(object sender, KeyEventArgs e)
        {
            if (NewTagText.Text != "")
            {
                if (e.Key == Key.Enter)
                {
                    try
                    {
                        using (var context = new Unify_TasksEntities())
                        {
                            Random random = new Random();
                            int RInt = random.Next(1, 9);

                            context.Tags.Local.Add(new Tag()
                            {
                                TaskID = w1.currTask,
                                ProjectID = w1.currProject,
                                TagHeader = NewTagText.Text,
                                TagColor = Convert.ToString(RInt),
                            }); ;
                            context.SaveChanges();
                            NewTagText.Text = "";
                            InfoText.Text = "Choose from list or create new";
                            UpdateBothTags();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("An error occurred while trying to add new tag.\r\n" +

                                        "Try to repeat the steps that led to the error. If the error still occurs,\r\n" +
                                        "please, contact the program developer");
                    }
                    
                }
            }
        }

        private void TaskTagsList_MouseUp(object sender, MouseButtonEventArgs e)
        {
            UpdateBothTags();
        }

        private void ChangeSelectedText(DependencyProperty d, object value)
        {
            var selection = NoteText.Selection;
            if (!selection.IsEmpty)
                selection.ApplyPropertyValue(d, value);
        }

        private void GetSelectedText()
        {
            var selection = NoteText.Selection;
            var text = new TextRange(NoteText.Document.ContentStart, NoteText.Document.ContentEnd);
            CursorPos = new TextRange(NoteText.Document.ContentStart, NoteText.Document.ContentEnd).Text.Length;

            var header = selection.GetPropertyValue(TextElement.FontSizeProperty);


            try
            {
                switch (Convert.ToInt32(header))
                {
                    case 14:
                        FontStyle.SelectedIndex = 0;
                        break;
                    case 32:
                        FontStyle.SelectedIndex = 1;
                        break;
                    case 24:
                        FontStyle.SelectedIndex = 2;
                        break;
                    case 18:
                        FontStyle.SelectedIndex = 3;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {

            }

            var weight = selection.GetPropertyValue(TextElement.FontWeightProperty);


            try
            {
                switch (Convert.ToString(weight))
                {
                    case "Normal":
                        BoldButton.IsChecked = false;
                        break;
                    case "Bold":
                        BoldButton.IsChecked = true;
                        break;
                    case "{DependencyProperty.UnsetValue}":
                        BoldButton.IsChecked = true;
                        break;
                }
            }
            catch (Exception)
            {

            }


            var style = selection.GetPropertyValue(TextElement.FontStyleProperty);

            try
            {
                switch (Convert.ToString(style))
                {
                    case "Normal":
                        ItalicButton.IsChecked = false;
                        break;
                    case "Italic":
                        ItalicButton.IsChecked = true;
                        break;
                    case "{DependencyProperty.UnsetValue}":
                        ItalicButton.IsChecked = true;
                        break;
                }
            }
            catch (Exception)
            {

            }

        }

        private void FontStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedItem = FontStyle.SelectedItem.ToString().Trim();

            if (selectedItem == "System.Windows.Controls.ComboBoxItem: Main font")
            {
                ChangeSelectedText(TextElement.FontSizeProperty, Regex.Replace("14", @".*:\s+", ""));
            }
            if (selectedItem == "System.Windows.Controls.ComboBoxItem: Header 1")
            {
                ChangeSelectedText(TextElement.FontSizeProperty, Regex.Replace("32", @".*:\s+", ""));
            }
            if (selectedItem == "System.Windows.Controls.ComboBoxItem: Header 2")
            {
                ChangeSelectedText(TextElement.FontSizeProperty, Regex.Replace("24", @".*:\s+", ""));
            }
            if (selectedItem == "System.Windows.Controls.ComboBoxItem: Header 3")
            {
                ChangeSelectedText(TextElement.FontSizeProperty, Regex.Replace("18", @".*:\s+", ""));
            }
        }

        private void BoldButton_Checked(object sender, RoutedEventArgs e)
        {
            ChangeSelectedText(TextElement.FontWeightProperty, "Bold");
        }
        private void BoldButton_Unchecked(object sender, RoutedEventArgs e)
        {
            ChangeSelectedText(TextElement.FontWeightProperty, "Regular");
        }
        private void ItalicButton_Checked(object sender, RoutedEventArgs e)
        {
            ChangeSelectedText(TextElement.FontStyleProperty, "Italic");
        }
        private void ItalicButton_Unchecked(object sender, RoutedEventArgs e)
        {
            ChangeSelectedText(TextElement.FontStyleProperty, "Normal");
        }
        private void UnderlineButton_Checked(object sender, RoutedEventArgs e)
        {
            ChangeSelectedText(TextBox.TextDecorationsProperty, "Underline");
        }
        private void UnderlineButton_Unchecked(object sender, RoutedEventArgs e)
        {
            ChangeSelectedText(TextBox.TextDecorationsProperty, "None");
        }

        private int Calculate_LastNote()
        {
            using (var context = new Unify_TasksEntities())
            {
                var Notes = context.Notes.Where(n => n.NoteID == n.NoteID);

                if (Notes != null)
                {
                    int lastNote = 0;
                    foreach (var everyNote in Notes)
                    {
                        if (lastNote < everyNote.NoteID)
                        {
                            lastNote = everyNote.NoteID;
                        }
                    }

                    return lastNote;
                }
                else
                {
                    return 0;
                }
            }
        }

        private void NoteText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void NoteText_SelectionChanged(object sender, RoutedEventArgs e)
        {
            GetSelectedText();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SaveNote();
            SaveNoteBorder.Background = (Brush)Application.Current.FindResource("CustomGreen");
        }

        private void SaveNoteBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            SaveNoteBorder.Background = (Brush)Application.Current.FindResource("AccentI");
        }
    }
}
