﻿#pragma checksum "..\..\..\Pages\RegisterPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5535C6B5DD2F6A1E683628FF6B21F3C9E7A408A4E25D493582DF6EB9B57AC4FB"
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
using Unify_Tasks.Pages;


namespace Unify_Tasks.Pages {
    
    
    /// <summary>
    /// Register
    /// </summary>
    public partial class Register : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 94 "..\..\..\Pages\RegisterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border NickBoxBorder;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\Pages\RegisterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NickBox;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\..\Pages\RegisterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border PasswordBoxBorder;
        
        #line default
        #line hidden
        
        
        #line 149 "..\..\..\Pages\RegisterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PasswordBox;
        
        #line default
        #line hidden
        
        
        #line 174 "..\..\..\Pages\RegisterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border RepeatPasswordBoxBorder;
        
        #line default
        #line hidden
        
        
        #line 189 "..\..\..\Pages\RegisterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RepeatPasswordBox;
        
        #line default
        #line hidden
        
        
        #line 202 "..\..\..\Pages\RegisterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border GoAheadBorder;
        
        #line default
        #line hidden
        
        
        #line 218 "..\..\..\Pages\RegisterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock CreateID;
        
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
            System.Uri resourceLocater = new System.Uri("/Unify_Tasks;component/pages/registerpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\RegisterPage.xaml"
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
            
            #line 10 "..\..\..\Pages\RegisterPage.xaml"
            ((Unify_Tasks.Pages.Register)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.NickBoxBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.NickBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 116 "..\..\..\Pages\RegisterPage.xaml"
            this.NickBox.IsKeyboardFocusedChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.NickBox_IsKeyboardFocusedChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.PasswordBoxBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 5:
            this.PasswordBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 156 "..\..\..\Pages\RegisterPage.xaml"
            this.PasswordBox.IsKeyboardFocusedChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.PasswordBox_IsKeyboardFocusedChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.RepeatPasswordBoxBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 7:
            this.RepeatPasswordBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 196 "..\..\..\Pages\RegisterPage.xaml"
            this.RepeatPasswordBox.IsKeyboardFocusedChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.RepeatPasswordBox_IsKeyboardFocusedChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.GoAheadBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 9:
            this.CreateID = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            
            #line 238 "..\..\..\Pages\RegisterPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Register_Click);
            
            #line default
            #line hidden
            
            #line 239 "..\..\..\Pages\RegisterPage.xaml"
            ((System.Windows.Controls.Button)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.CreateID_MouseEnter);
            
            #line default
            #line hidden
            
            #line 240 "..\..\..\Pages\RegisterPage.xaml"
            ((System.Windows.Controls.Button)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.CreateID_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 268 "..\..\..\Pages\RegisterPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BackLogin_Click);
            
            #line default
            #line hidden
            
            #line 269 "..\..\..\Pages\RegisterPage.xaml"
            ((System.Windows.Controls.Button)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.BackLogin_MouseEnter);
            
            #line default
            #line hidden
            
            #line 270 "..\..\..\Pages\RegisterPage.xaml"
            ((System.Windows.Controls.Button)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.BackLogin_MouseLeave);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

