﻿#pragma checksum "..\..\..\Pages\LoginPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "608637B7697C3171EA010DB10EF2C0437F19D287789A42EFAFA8648CDE744D8C"
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
        
        
        #line 74 "..\..\..\Pages\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Welcome;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\Pages\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border LoginBorder;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\Pages\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LoginBox;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\..\Pages\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border PasswordBorder;
        
        #line default
        #line hidden
        
        
        #line 155 "..\..\..\Pages\LoginPage.xaml"
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
            
            #line 11 "..\..\..\Pages\LoginPage.xaml"
            this.LoginPage.Loaded += new System.Windows.RoutedEventHandler(this.LoginPage_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Welcome = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.LoginBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 4:
            this.LoginBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 122 "..\..\..\Pages\LoginPage.xaml"
            this.LoginBox.IsKeyboardFocusedChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.LoginBox_IsKeyboardFocusedChanged);
            
            #line default
            #line hidden
            
            #line 123 "..\..\..\Pages\LoginPage.xaml"
            this.LoginBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.LoginBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.PasswordBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 6:
            this.PasswordBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 162 "..\..\..\Pages\LoginPage.xaml"
            this.PasswordBox.IsKeyboardFocusedChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.PasswordBox_IsKeyboardFocusedChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 204 "..\..\..\Pages\LoginPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LogIn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 230 "..\..\..\Pages\LoginPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NewAcc_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

