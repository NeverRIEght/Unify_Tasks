using System.Windows;
using System.Windows.Controls;

namespace Unify_Tasks.UserControls
{
    /// <summary>
    /// Логика взаимодействия для TagElement.xaml
    /// </summary>
    public partial class TagElement : UserControl
    {
        public TagElement()
        {
            InitializeComponent();
            DataContext = this;
        }

        public static readonly DependencyProperty TagTextProperty =
        DependencyProperty.Register(
        name: "TagText",
        propertyType: typeof(string),
        ownerType: typeof(TagElement),
        typeMetadata: new FrameworkPropertyMetadata(
        defaultValue: "Tag",
        flags: FrameworkPropertyMetadataOptions.AffectsMeasure));

        public string TagText
        {
            get => (string)GetValue(TagTextProperty);
            set => SetValue(TagTextProperty, value);
        }
    }
}
