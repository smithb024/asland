namespace Asland.Views.Icons
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    /// <summary>
    /// Interaction logic for HighIntensityIcon.xaml
    /// </summary>
    public partial class HighIntensityIcon : UserControl
    {
        /// <summary>
        /// Used to paint this icon
        /// </summary>
        public static readonly DependencyProperty HighIntensityBrushProperty =
            DependencyProperty.Register(
              nameof(HighIntensityBrush),
              typeof(Brush),
              typeof(HighIntensityIcon),
              new PropertyMetadata(new SolidColorBrush(Colors.HotPink)));

        /// <summary>
        /// Initialises a new instance of the <see cref="HighIntensityIcon"/> class.
        /// </summary>
        public HighIntensityIcon()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the brush used to paint the icon.
        /// </summary>
        public Brush HighIntensityBrush
        {
            get => (Brush)this.GetValue(HighIntensityBrushProperty);
            set => this.SetValue(HighIntensityBrushProperty, value);
        }
    }
}
