﻿#pragma checksum "..\..\..\UserControls\TaskListElement.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AC1D6E48AFBBD2BADE136F9A1E10320FE4CCD7A786AA1FACCAD1BF8F015DFD82"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Unify_Tasks.UserControls;


namespace Unify_Tasks.UserControls {
    
    
    /// <summary>
    /// TaskListElement
    /// </summary>
    public partial class TaskListElement : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\UserControls\TaskListElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid TaskGrid;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\UserControls\TaskListElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox IsReady;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\UserControls\TaskListElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TaskHeader;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\UserControls\TaskListElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image OpenNote;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\UserControls\TaskListElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image TagControl;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\UserControls\TaskListElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image TagControlBrown;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\UserControls\TaskListElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Watch;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\UserControls\TaskListElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image WatchBlue;
        
        #line default
        #line hidden
        
        
        #line 146 "..\..\..\UserControls\TaskListElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Trash;
        
        #line default
        #line hidden
        
        
        #line 158 "..\..\..\UserControls\TaskListElement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image TrashRed;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Unify_Tasks;component/usercontrols/tasklistelement.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\TaskListElement.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\UserControls\TaskListElement.xaml"
            ((Unify_Tasks.UserControls.TaskListElement)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            
            #line 11 "..\..\..\UserControls\TaskListElement.xaml"
            ((Unify_Tasks.UserControls.TaskListElement)(target)).SizeChanged += new System.Windows.SizeChangedEventHandler(this.UserControl_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TaskGrid = ((System.Windows.Controls.Grid)(target));
            
            #line 15 "..\..\..\UserControls\TaskListElement.xaml"
            this.TaskGrid.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Task_MouseEnter);
            
            #line default
            #line hidden
            
            #line 16 "..\..\..\UserControls\TaskListElement.xaml"
            this.TaskGrid.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Task_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 3:
            this.IsReady = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 4:
            this.TaskHeader = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.OpenNote = ((System.Windows.Controls.Image)(target));
            
            #line 88 "..\..\..\UserControls\TaskListElement.xaml"
            this.OpenNote.MouseEnter += new System.Windows.Input.MouseEventHandler(this.OpenNote_MouseEnter);
            
            #line default
            #line hidden
            
            #line 89 "..\..\..\UserControls\TaskListElement.xaml"
            this.OpenNote.MouseLeave += new System.Windows.Input.MouseEventHandler(this.OpenNote_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TagControl = ((System.Windows.Controls.Image)(target));
            
            #line 101 "..\..\..\UserControls\TaskListElement.xaml"
            this.TagControl.MouseEnter += new System.Windows.Input.MouseEventHandler(this.TagControl_MouseEnter);
            
            #line default
            #line hidden
            
            #line 102 "..\..\..\UserControls\TaskListElement.xaml"
            this.TagControl.MouseLeave += new System.Windows.Input.MouseEventHandler(this.TagControl_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 7:
            this.TagControlBrown = ((System.Windows.Controls.Image)(target));
            
            #line 114 "..\..\..\UserControls\TaskListElement.xaml"
            this.TagControlBrown.MouseEnter += new System.Windows.Input.MouseEventHandler(this.TagControl_MouseEnter);
            
            #line default
            #line hidden
            
            #line 115 "..\..\..\UserControls\TaskListElement.xaml"
            this.TagControlBrown.MouseLeave += new System.Windows.Input.MouseEventHandler(this.TagControl_MouseLeave);
            
            #line default
            #line hidden
            
            #line 116 "..\..\..\UserControls\TaskListElement.xaml"
            this.TagControlBrown.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.TagControlBrown_MouseUp);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Watch = ((System.Windows.Controls.Image)(target));
            
            #line 128 "..\..\..\UserControls\TaskListElement.xaml"
            this.Watch.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Watch_MouseEnter);
            
            #line default
            #line hidden
            
            #line 129 "..\..\..\UserControls\TaskListElement.xaml"
            this.Watch.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Watch_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 9:
            this.WatchBlue = ((System.Windows.Controls.Image)(target));
            
            #line 141 "..\..\..\UserControls\TaskListElement.xaml"
            this.WatchBlue.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Watch_MouseEnter);
            
            #line default
            #line hidden
            
            #line 142 "..\..\..\UserControls\TaskListElement.xaml"
            this.WatchBlue.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Watch_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Trash = ((System.Windows.Controls.Image)(target));
            
            #line 153 "..\..\..\UserControls\TaskListElement.xaml"
            this.Trash.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Trash_MouseEnter);
            
            #line default
            #line hidden
            
            #line 154 "..\..\..\UserControls\TaskListElement.xaml"
            this.Trash.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Trash_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 11:
            this.TrashRed = ((System.Windows.Controls.Image)(target));
            
            #line 166 "..\..\..\UserControls\TaskListElement.xaml"
            this.TrashRed.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Trash_MouseEnter);
            
            #line default
            #line hidden
            
            #line 167 "..\..\..\UserControls\TaskListElement.xaml"
            this.TrashRed.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Trash_MouseLeave);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

