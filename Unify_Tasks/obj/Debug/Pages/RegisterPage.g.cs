#pragma checksum "..\..\..\Pages\RegisterPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "111D9C6291EBC33DE600A9C038A2A41157C9020018E01624FAF7E553E2127129"
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
        
        
        #line 113 "..\..\..\Pages\RegisterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border NickBoxBorder;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\Pages\RegisterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NickBox;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\..\Pages\RegisterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border PasswordBoxBorder;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\..\Pages\RegisterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordBox;
        
        #line default
        #line hidden
        
        
        #line 169 "..\..\..\Pages\RegisterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border RepeatPasswordBoxBorder;
        
        #line default
        #line hidden
        
        
        #line 176 "..\..\..\Pages\RegisterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox RepeatPasswordBox;
        
        #line default
        #line hidden
        
        
        #line 185 "..\..\..\Pages\RegisterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border GoAheadBorder;
        
        #line default
        #line hidden
        
        
        #line 197 "..\..\..\Pages\RegisterPage.xaml"
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
            
            #line 11 "..\..\..\Pages\RegisterPage.xaml"
            ((Unify_Tasks.Pages.Register)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 44 "..\..\..\Pages\RegisterPage.xaml"
            ((System.Windows.Controls.Grid)(target)).KeyUp += new System.Windows.Input.KeyEventHandler(this.Page_KeyUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.NickBoxBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 4:
            this.NickBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 123 "..\..\..\Pages\RegisterPage.xaml"
            this.NickBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.NickBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.PasswordBoxBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 6:
            this.PasswordBox = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 151 "..\..\..\Pages\RegisterPage.xaml"
            this.PasswordBox.PasswordChanged += new System.Windows.RoutedEventHandler(this.PasswordBox_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.RepeatPasswordBoxBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 8:
            this.RepeatPasswordBox = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 179 "..\..\..\Pages\RegisterPage.xaml"
            this.RepeatPasswordBox.PasswordChanged += new System.Windows.RoutedEventHandler(this.RepeatPasswordBox_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.GoAheadBorder = ((System.Windows.Controls.Border)(target));
            
            #line 192 "..\..\..\Pages\RegisterPage.xaml"
            this.GoAheadBorder.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Button_MouseEnter);
            
            #line default
            #line hidden
            
            #line 193 "..\..\..\Pages\RegisterPage.xaml"
            this.GoAheadBorder.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Button_MouseLeave);
            
            #line default
            #line hidden
            
            #line 194 "..\..\..\Pages\RegisterPage.xaml"
            this.GoAheadBorder.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Register_MouseUp);
            
            #line default
            #line hidden
            return;
            case 10:
            this.CreateID = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            
            #line 221 "..\..\..\Pages\RegisterPage.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.Button_MouseEnter);
            
            #line default
            #line hidden
            
            #line 222 "..\..\..\Pages\RegisterPage.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.Button_MouseLeave);
            
            #line default
            #line hidden
            
            #line 223 "..\..\..\Pages\RegisterPage.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.BackLogin_MouseUp);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

