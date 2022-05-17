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
using System.Windows.Shapes;
using Unify_Tasks.Models;
using Unify_Tasks.UserControls;

namespace Unify_Tasks.DialogWindows
{
    /// <summary>
    /// Логика взаимодействия для TagControlWindow.xaml
    /// </summary>
    public partial class TagControlWindow : Window
    {
        static MainWindow w1 = (MainWindow)Application.Current.MainWindow;
        public int ThisTagColor = 0;
        public int SelectedTag = 0;
        public int SelectedTask = 0;

        public TagControlWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SelectedTask = w1.currTask;
            TagControlWindow win = (TagControlWindow)Window.GetWindow(this);

            win.MinWidth = 500;
            win.MinHeight = 480;
            win.MaxWidth = 500;
            win.MaxHeight = 480;
            UpdateTags();
        }

        private void UpdateTags()
        {
            TagsBoard.Children.Clear();
            using (var context = new Unify_TasksEntities())
            {
                var Tags = context.Tags.Where(t => t.TaskID == SelectedTask).OrderBy(t => t.TagID);

                if (Tags != null)
                {
                    foreach (var everyTag in Tags)
                    {
                        TagElement tag1 = new TagElement();
                        tag1.TagText = everyTag.TagHeader;

                        switch (Convert.ToInt32(everyTag.TagColor))
                        {
                            case 1:
                                tag1.Background = (Brush)Application.Current.FindResource("CustomRed");
                                break;
                            case 2:
                                tag1.Background = (Brush)Application.Current.FindResource("CustomGreen");
                                break;
                            case 3:
                                tag1.Background = (Brush)Application.Current.FindResource("CustomBlue");
                                break;
                            case 4:
                                tag1.Background = (Brush)Application.Current.FindResource("CustomBrown");
                                break;
                            case 5:
                                tag1.Background = (Brush)Application.Current.FindResource("CustomGray");
                                break;
                            case 6:
                                tag1.Background = (Brush)Application.Current.FindResource("CustomYellow");
                                break;
                            case 7:
                                tag1.Background = (Brush)Application.Current.FindResource("CustomPink");
                                break;
                            case 8:
                                tag1.Background = (Brush)Application.Current.FindResource("CustomPurple");
                                break;
                            default:
                                Random random = new Random();
                                int RInt = random.Next(1, 9);
                                switch (RInt)
                                {
                                    case 1:
                                        tag1.Background = (Brush)Application.Current.FindResource("CustomRed");
                                        break;
                                    case 2:
                                        tag1.Background = (Brush)Application.Current.FindResource("CustomGreen");
                                        break;
                                    case 3:
                                        tag1.Background = (Brush)Application.Current.FindResource("CustomBlue");
                                        break;
                                    case 4:
                                        tag1.Background = (Brush)Application.Current.FindResource("CustomBrown");
                                        break;
                                    case 5:
                                        tag1.Background = (Brush)Application.Current.FindResource("CustomGray");
                                        break;
                                    case 6:
                                        tag1.Background = (Brush)Application.Current.FindResource("CustomYellow");
                                        break;
                                    case 7:
                                        tag1.Background = (Brush)Application.Current.FindResource("CustomPink");
                                        break;
                                    case 8:
                                        tag1.Background = (Brush)Application.Current.FindResource("CustomPurple");
                                        break;
                                }
                                break;
                        }

                        tag1.MouseUp += (object s, MouseButtonEventArgs ev) =>
                        {
                            SelectedTag = everyTag.TagID;
                            tag1.TagBackgroud.BorderBrush = Brushes.Red;
                            foreach (TagElement eachTag in TagsBoard.Children)
                            {
                                if (eachTag != tag1)
                                {
                                    eachTag.TagBackgroud.BorderBrush = Brushes.White;
                                }
                            }
                        };

                        tag1.TagBackgroud.CornerRadius = new CornerRadius(5);
                        tag1.Margin = new Thickness(20, 20, 20, 20);
                        TagsBoard.Children.Add(tag1);
                    }
                }
            }
        }

        private void SaveTag_MouseUp(object sender, MouseButtonEventArgs e)
        {
            using (var context = new Unify_TasksEntities())
            {
                var Tags = context.Tags.Where(t => t.TaskID == SelectedTask);

                if(Tags.Count() < 2)
                {
                    context.Tags.Local.Add(new Tag()
                    {
                        TagHeader = TagNameBox.Text,
                        TaskID = SelectedTask,
                        TagColor = Convert.ToString(ThisTagColor),
                    });
                    context.SaveChanges();
                    UpdateTags();
                }
                else
                {
                    MessageBox.Show("You can`t add more than 2 tags");
                }


            }

            /*
            TagElement tag1 = new TagElement();
            tag1.TagText = TagNameBox.Text;
            tag1.TagBackgroud.CornerRadius = new CornerRadius(5);
            tag1.Margin = new Thickness(20, 20, 20, 20);

            switch(ThisTagColor)
            {
                case 1:
                    tag1.Background = (Brush)Application.Current.FindResource("CustomRed");
                    break;
                case 2:
                    tag1.Background = (Brush)Application.Current.FindResource("CustomGreen");
                    break;
                case 3:
                    tag1.Background = (Brush)Application.Current.FindResource("CustomBlue");
                    break;
                case 4:
                    tag1.Background = (Brush)Application.Current.FindResource("CustomBrown");
                    break;
                case 5:
                    tag1.Background = (Brush)Application.Current.FindResource("CustomGray");
                    break;
                case 6:
                    tag1.Background = (Brush)Application.Current.FindResource("CustomYellow");
                    break;
                case 7:
                    tag1.Background = (Brush)Application.Current.FindResource("CustomPink");
                    break;
                case 8:
                    tag1.Background = (Brush)Application.Current.FindResource("CustomPurple");
                    break;
                default:
                    Random random = new Random();
                    int RInt = random.Next(1, 9);
                    switch (RInt)
                    {
                        case 1:
                            tag1.Background = (Brush)Application.Current.FindResource("CustomRed");
                            break;
                        case 2:
                            tag1.Background = (Brush)Application.Current.FindResource("CustomGreen");
                            break;
                        case 3:
                            tag1.Background = (Brush)Application.Current.FindResource("CustomBlue");
                            break;
                        case 4:
                            tag1.Background = (Brush)Application.Current.FindResource("CustomBrown");
                            break;
                        case 5:
                            tag1.Background = (Brush)Application.Current.FindResource("CustomGray");
                            break;
                        case 6:
                            tag1.Background = (Brush)Application.Current.FindResource("CustomYellow");
                            break;
                        case 7:
                            tag1.Background = (Brush)Application.Current.FindResource("CustomPink");
                            break;
                        case 8:
                            tag1.Background = (Brush)Application.Current.FindResource("CustomPurple");
                            break;
                    }
                    break;
            }*/
            /*foreach(TagElement everyTag in TagsBoard.Children)
            {
                everyTag.MouseUp += (object s, MouseButtonEventArgs ev) =>
                {
                    SelectedTag = TagsBoard.Children.IndexOf(everyTag) + 1;
                    everyTag.TagBackgroud.BorderBrush = Brushes.Red;
                    foreach(TagElement eachTag in TagsBoard.Children)
                    {
                        if(eachTag != everyTag)
                        {
                            eachTag.TagBackgroud.BorderBrush = Brushes.White;
                        }
                    }
                };
            }*/
        }

        private void TagNameBox_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (TagNameBox.Text == "Tag Name")
            {
                TagNameBox.Text = "";
            }
        }

        private void Border1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ThisTagColor = 1;
            Border1.Background = (Brush)Application.Current.FindResource("LightI");
            Border2.Background = (Brush)Application.Current.FindResource("DarkI");
            Border3.Background = (Brush)Application.Current.FindResource("DarkI");
            Border4.Background = (Brush)Application.Current.FindResource("DarkI");
            Border5.Background = (Brush)Application.Current.FindResource("DarkI");
            Border6.Background = (Brush)Application.Current.FindResource("DarkI");
            Border7.Background = (Brush)Application.Current.FindResource("DarkI");
            Border8.Background = (Brush)Application.Current.FindResource("DarkI");
        }

        private void Border2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ThisTagColor = 2;
            Border1.Background = (Brush)Application.Current.FindResource("DarkI");
            Border2.Background = (Brush)Application.Current.FindResource("LightI");
            Border3.Background = (Brush)Application.Current.FindResource("DarkI");
            Border4.Background = (Brush)Application.Current.FindResource("DarkI");
            Border5.Background = (Brush)Application.Current.FindResource("DarkI");
            Border6.Background = (Brush)Application.Current.FindResource("DarkI");
            Border7.Background = (Brush)Application.Current.FindResource("DarkI");
            Border8.Background = (Brush)Application.Current.FindResource("DarkI");
        }

        private void Border3_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ThisTagColor = 3;
            Border1.Background = (Brush)Application.Current.FindResource("DarkI");
            Border2.Background = (Brush)Application.Current.FindResource("DarkI");
            Border3.Background = (Brush)Application.Current.FindResource("LightI");
            Border4.Background = (Brush)Application.Current.FindResource("DarkI");
            Border5.Background = (Brush)Application.Current.FindResource("DarkI");
            Border6.Background = (Brush)Application.Current.FindResource("DarkI");
            Border7.Background = (Brush)Application.Current.FindResource("DarkI");
            Border8.Background = (Brush)Application.Current.FindResource("DarkI");
        }

        private void Border4_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ThisTagColor = 4;
            Border1.Background = (Brush)Application.Current.FindResource("DarkI");
            Border2.Background = (Brush)Application.Current.FindResource("DarkI");
            Border3.Background = (Brush)Application.Current.FindResource("DarkI");
            Border4.Background = (Brush)Application.Current.FindResource("LightI");
            Border5.Background = (Brush)Application.Current.FindResource("DarkI");
            Border6.Background = (Brush)Application.Current.FindResource("DarkI");
            Border7.Background = (Brush)Application.Current.FindResource("DarkI");
            Border8.Background = (Brush)Application.Current.FindResource("DarkI");
        }

        private void Border5_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ThisTagColor = 5;
            Border1.Background = (Brush)Application.Current.FindResource("DarkI");
            Border2.Background = (Brush)Application.Current.FindResource("DarkI");
            Border3.Background = (Brush)Application.Current.FindResource("DarkI");
            Border4.Background = (Brush)Application.Current.FindResource("DarkI");
            Border5.Background = (Brush)Application.Current.FindResource("LightI");
            Border6.Background = (Brush)Application.Current.FindResource("DarkI");
            Border7.Background = (Brush)Application.Current.FindResource("DarkI");
            Border8.Background = (Brush)Application.Current.FindResource("DarkI");
        }

        private void Border6_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ThisTagColor = 6;
            Border1.Background = (Brush)Application.Current.FindResource("DarkI");
            Border2.Background = (Brush)Application.Current.FindResource("DarkI");
            Border3.Background = (Brush)Application.Current.FindResource("DarkI");
            Border4.Background = (Brush)Application.Current.FindResource("DarkI");
            Border5.Background = (Brush)Application.Current.FindResource("DarkI");
            Border6.Background = (Brush)Application.Current.FindResource("LightI");
            Border7.Background = (Brush)Application.Current.FindResource("DarkI");
            Border8.Background = (Brush)Application.Current.FindResource("DarkI");
        }

        private void Border7_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ThisTagColor = 7;
            Border1.Background = (Brush)Application.Current.FindResource("DarkI");
            Border2.Background = (Brush)Application.Current.FindResource("DarkI");
            Border3.Background = (Brush)Application.Current.FindResource("DarkI");
            Border4.Background = (Brush)Application.Current.FindResource("DarkI");
            Border5.Background = (Brush)Application.Current.FindResource("DarkI");
            Border6.Background = (Brush)Application.Current.FindResource("DarkI");
            Border7.Background = (Brush)Application.Current.FindResource("LightI");
            Border8.Background = (Brush)Application.Current.FindResource("DarkI");
        }

        private void Border8_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ThisTagColor = 8;
            Border1.Background = (Brush)Application.Current.FindResource("DarkI");
            Border2.Background = (Brush)Application.Current.FindResource("DarkI");
            Border3.Background = (Brush)Application.Current.FindResource("DarkI");
            Border4.Background = (Brush)Application.Current.FindResource("DarkI");
            Border5.Background = (Brush)Application.Current.FindResource("DarkI");
            Border6.Background = (Brush)Application.Current.FindResource("DarkI");
            Border7.Background = (Brush)Application.Current.FindResource("DarkI");
            Border8.Background = (Brush)Application.Current.FindResource("LightI");
        }

        private void DelTag_MouseUp(object sender, MouseButtonEventArgs e)
        {

            using (var context = new Unify_TasksEntities())
            {
                var toDelete = context.Tags.Where(t => t.TagID == SelectedTag).FirstOrDefault();

                if (toDelete != null)
                {
                    context.Tags.Remove(toDelete);
                    context.SaveChanges();
                    UpdateTags();
                }
            }
        }
    }
}
