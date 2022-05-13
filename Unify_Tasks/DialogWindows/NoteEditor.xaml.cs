using System;
using System.Collections.Generic;
using System.IO;
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
            using (var context = new Unify_TasksEntities())
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            using (var context = new Unify_TasksEntities())
            {
                var thisNote = context.Tasks.Where(n => n.TaskID == w1.currTask).FirstOrDefault();

                if (thisNote != null)
                {
                    //using (FileStream fs = File.Create(currPath + "/Notes"))
                }
            }
        }
    }
}
