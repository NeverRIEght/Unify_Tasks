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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Unify_Tasks
{
    /// <summary>
    /// Логика взаимодействия для ProjectListElement.xaml
    /// </summary>
    public partial class ProjectListElement : UserControl
    {
        public ProjectListElement()
        {
            InitializeComponent();
            DataContext = this;
        }
        public static readonly DependencyProperty ProjectsTextProperty =
        DependencyProperty.Register(
        name: "ProjectsText",
        propertyType: typeof(string),
        ownerType: typeof(ProjectListElement),
        typeMetadata: new FrameworkPropertyMetadata(
        defaultValue: "ProjectTitle",
        flags: FrameworkPropertyMetadataOptions.AffectsMeasure));

        public string ProjectsText
        {
            get => (string)GetValue(ProjectsTextProperty);
            set => SetValue(ProjectsTextProperty, value);
        }
    }
}
