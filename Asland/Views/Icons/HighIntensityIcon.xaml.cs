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
              new PropertyMetadata(
                  new SolidColorBrush(Colors.HotPink),
                  OnHighIntensityPropertyChanged));

        /// <summary>
        /// Initialises a new instance of the <see cref="HighIntensityIcon"/> class.
        /// </summary>
        public HighIntensityIcon()
        {
            this.InitializeComponent();
            this.HighIntensityPath.Fill = this.HighIntensityBrush;
            this.HighIntensityPath.Stroke = this.HighIntensityBrush;
        }

        /// <summary>
        /// Gets or sets the brush used to paint the icon.
        /// </summary>
        public Brush HighIntensityBrush
        {
            get => (Brush)this.GetValue(HighIntensityBrushProperty);
            set => this.SetValue(HighIntensityBrushProperty, value);
        }

        /// <summary>
        /// The brush changed event
        /// </summary>
        /// <param name="d">The sender</param>
        /// <param name="e">The event argument</param>
        private static void OnHighIntensityPropertyChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            if (d is HighIntensityIcon highIntensity) 
            {
                Brush newBrush = e.NewValue as Brush;
                highIntensity.HighIntensityPath.Fill = newBrush;
                highIntensity.HighIntensityPath.Stroke = newBrush;
            }
        }
    }
}
