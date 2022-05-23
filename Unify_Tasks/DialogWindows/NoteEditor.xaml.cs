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
        int currNote = 0;


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
            try
            {
                using (var context = new Unify_TasksEntities())
                {
                    Models.Note currentNote = null;
                    currentNote = context.Notes.Where(n => n.TaskID == w1.currTask).FirstOrDefault();

                    if(currentNote != null)
                    {
                        currNote = currentNote.NoteID;

                        using (FileStream fs = File.OpenRead(w1.currPath + "/Notes/Note" + currNote + ".rtf"))
                        {
                            TextRange range1 = new TextRange(NoteText.Document.ContentStart, NoteText.Document.ContentEnd);
                            range1.Load(fs, DataFormats.Rtf);
                        }
                    }
                    else if(currentNote == null)
                    {
                        currNote = 0;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while trying to open this note.\r\n" +
                                        
                                        "Try to repeat the steps that led to the error. If the error still occurs,\r\n" +
                                        "please, contact the program developer");
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
            try
            {
                using (var context = new Unify_TasksEntities())
                {
                    if(currNote != 0)
                    {
                        using (FileStream fs = File.Create(w1.currPath + "/Notes/Note" + currNote + ".rtf"))
                        {
                            TextRange range1 = new TextRange(NoteText.Document.ContentStart, NoteText.Document.ContentEnd);
                            range1.Save(fs, DataFormats.Rtf);
                            this.Close();
                            
                        }
                    }
                    if(currNote == 0)
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
                            this.Close();

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

        private int Calculate_LastNote()
        {
            using (var context = new Unify_TasksEntities())
            {
                var Notes = context.Notes.Where(n => n.NoteID == n.NoteID);

                if(Notes != null)
                {
                    int lastNote = 0;
                    foreach (var everyNote in Notes)
                    {
                        if(lastNote < everyNote.NoteID)
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
    }
}
