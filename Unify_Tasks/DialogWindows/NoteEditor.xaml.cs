using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Unify_Tasks.DialogWindows
{
    /// <summary>
    /// Логика взаимодействия для NoteEditor.xaml
    /// </summary>
    public partial class NoteEditor : Window
    {
        static MainWindow w1 = (MainWindow)Application.Current.MainWindow;
        string currPath = Environment.CurrentDirectory;


        public NoteEditor()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NoteEditor win = (NoteEditor)Window.GetWindow(this);

            win.MinWidth = 800;
            win.MinHeight = 450;
            win.MaxWidth = 800;
            win.MaxHeight = 450;

            //Loading prev file
            using (var context = new Unify_TasksEntities())
            {
                var thisNote = context.Tasks.Where(n => n.TaskID == w1.currTask).FirstOrDefault();

                if (File.Exists(currPath + "/Notes/Note" + w1.currTask + ".rtf"))
                {
                    using (FileStream fs = File.OpenRead(currPath + "/Notes/Note" + w1.currTask + ".rtf"))
                    {
                        TextRange range1 = new TextRange(NoteText.Document.ContentStart, NoteText.Document.ContentEnd);

                        range1.Load(fs, DataFormats.Rtf);
                    }
                }
            }
        }

        private void ChangeSelectedText(DependencyProperty d, object value)
        {
            var selection = NoteText.Selection;
            if (!selection.IsEmpty)
                selection.ApplyPropertyValue(d, value);
        }

        private void FontColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NoteText != null)
            {
                string selectedItem = FontColor.SelectedItem.ToString();
                ChangeSelectedText(TextElement.ForegroundProperty, Regex.Replace(selectedItem.Trim(), @".*:\s+", ""));
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

        private void Save_MouseUp(object sender, MouseButtonEventArgs e)
        {
            using (var context = new Unify_TasksEntities())
            {
                var thisNote = context.Tasks.Where(n => n.TaskID == w1.currTask).FirstOrDefault();

                if (thisNote != null)
                {
                    using (FileStream fs = File.Create(currPath + "/Notes/Note" + w1.currTask + ".rtf"))
                    {
                        TextRange range1 = new TextRange(NoteText.Document.ContentStart, NoteText.Document.ContentEnd);
                        thisNote.NoteID = thisNote.TaskID;
                        context.SaveChanges();
                        range1.Save(fs, DataFormats.Rtf);
                        this.DialogResult = true;
                        this.Close();
                    }
                }
            }
        }
    }
}
