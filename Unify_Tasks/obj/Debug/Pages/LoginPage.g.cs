﻿#pragma checksum "..\..\..\Pages\LoginPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "50C4AD6B4DA68F332DEE6F9FF6AB4061470D17A97316D4002718257AE25A2E2E"
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
using Unify_Tasks;
using Unify_Tasks.Pages;


namespace Unify_Tasks.Pages {
    
    
    /// <summary>
    /// Login
    /// </summary>
    public partial class Login : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\Pages\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Unify_Tasks.Pages.Login LoginPage;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\..\Pages\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LoginBox;
        
        #line default
        #line hidden
        
        
        #line 175 "..\..\..\Pages\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PasswordBox;
        
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
            System.Uri resourceLocater = new System.Uri("/Unify_Tasks;component/pages/loginpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\LoginPage.xaml"
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
            this.LoginPage = ((Unify_Tasks.Pages.Login)(target));
            return;
            case 2:
            
            #line 105 "..\..\..\Pages\LoginPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NewAcc_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.LoginBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 143 "..\..\..\Pages\LoginPage.xaml"
            this.LoginBox.IsKeyboardFocusedChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.LoginBox_IsKeyboardFocusedChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.PasswordBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 182 "..\..\..\Pages\LoginPage.xaml"
            this.PasswordBox.IsKeyboardFocusedChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.PasswordBox_IsKeyboardFocusedChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 225 "..\..\..\Pages\LoginPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LogIn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

