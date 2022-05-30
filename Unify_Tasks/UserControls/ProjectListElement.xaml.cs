using System.Windows;
using System.Windows.Controls;

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

        public static readonly DependencyProperty ProjectsIDProperty =
        DependencyProperty.Register(
        name: "ProjectsID",
        propertyType: typeof(int),
        ownerType: typeof(ProjectListElement),
        typeMetadata: new FrameworkPropertyMetadata(
        defaultValue: 1,
        flags: FrameworkPropertyMetadataOptions.AffectsMeasure));

        public int ProjectsID
        {
            get => (int)GetValue(ProjectsIDProperty);
            set => SetValue(ProjectsIDProperty, value);
        }

    }
}
