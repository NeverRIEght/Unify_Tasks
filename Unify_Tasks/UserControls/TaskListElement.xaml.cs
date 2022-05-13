﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Unify_Tasks.DialogWindows;
using Unify_Tasks.Models;
using Unify_Tasks.Pages;

namespace Unify_Tasks.UserControls
{
    /// <summary>
    /// Логика взаимодействия для Task.xaml
    /// </summary>
    public partial class TaskListElement : UserControl
    {
        static MainWindow w1 = (MainWindow)Application.Current.MainWindow;

        public TaskListElement()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Trash_MouseEnter(object sender, MouseEventArgs e)
        {
            Trash.Opacity = 0;
            TrashRed.Opacity = 1;
            this.Cursor = Cursors.Hand;
        }

        private void Trash_MouseLeave(object sender, MouseEventArgs e)
        {
            Trash.Opacity = 1;
            TrashRed.Opacity = 0;
            this.Cursor = Cursors.Arrow;
        }

        

        private void Watch_MouseEnter(object sender, MouseEventArgs e)
        {
            Watch.Opacity = 0;
            WatchBlue.Opacity = 1;
            this.Cursor = Cursors.Hand;
        }
        private void Watch_MouseLeave(object sender, MouseEventArgs e)
        {
            Watch.Opacity = 1;
            WatchBlue.Opacity = 0;
            this.Cursor = Cursors.Arrow;
        }

        private void TagControl_MouseEnter(object sender, MouseEventArgs e)
        {
            TagControl.Opacity = 0;
            TagControlBrown.Opacity = 1;
            this.Cursor = Cursors.Hand;
        }
        private void TagControl_MouseLeave(object sender, MouseEventArgs e)
        {
            TagControl.Opacity = 1;
            TagControlBrown.Opacity = 0;
            this.Cursor = Cursors.Arrow;
        }

        private void TagControlBrown_MouseUp(object sender, MouseButtonEventArgs e)
        {
            TagControlWindow win1 = new TagControlWindow();
            win1.Show();
        }

        private void Task_MouseEnter(object sender, MouseEventArgs e)
        {
            OpenNote.Visibility = Visibility.Visible;
            TagControl.Visibility = Visibility.Visible;
            Watch.Visibility = Visibility.Visible;
        }
        private void Task_MouseLeave(object sender, MouseEventArgs e)
        {
            OpenNote.Visibility = Visibility.Hidden;
            TagControl.Visibility = Visibility.Hidden;
            Watch.Visibility = Visibility.Hidden;
        }

        private void OpenNote_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
        private void OpenNote_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            MainWindow win = (MainWindow)Window.GetWindow(this);
            if (win.Width <= 1300)
            {
                TaskGrid.ColumnDefinitions[5].MinWidth = 10;
                TaskGrid.ColumnDefinitions[7].MinWidth = 0;
            }

            if (TaskHeader.Width > 520)
            {
                TaskHeader.FontSize = 21;
            }
            if (TaskHeader.Width <= 520)
            {
                TaskHeader.FontSize = 16;
            }
        }

        public static readonly DependencyProperty TasksIDProperty =
        DependencyProperty.Register(
        name: "TasksID",
        propertyType: typeof(int),
        ownerType: typeof(TaskListElement),
        typeMetadata: new FrameworkPropertyMetadata(
        defaultValue: 1,
        flags: FrameworkPropertyMetadataOptions.AffectsMeasure));

        public int TasksID
        {
            get => (int)GetValue(TasksIDProperty);
            set => SetValue(TasksIDProperty, value);
        }
    }
}
