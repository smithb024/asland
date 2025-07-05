namespace Asland.Views.Icons
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    /// <summary>
    /// Interaction logic for LowIntensityIcon.xaml
    /// </summary>
    public partial class LowIntensityIcon : UserControl
    {
        /// <summary>
        /// Used to paint this icon
        /// </summary>
        public static readonly DependencyProperty LowIntensityBrushProperty =
            DependencyProperty.Register(
              nameof(LowIntensityBrush),
              typeof(Brush),
              typeof(MediumIntensityIcon),
              new PropertyMetadata(
                  new SolidColorBrush(Colors.HotPink),
                  OnLowIntensityPropertyChanged));

        /// <summary>
        /// Initialises a new instance of the <see cref="LowIntensityIcon"/> class.
        /// </summary>
        public LowIntensityIcon()
        {
            this.InitializeComponent();
            this.LowIntensityPath.Fill = this.LowIntensityBrush;
            this.LowIntensityPath.Stroke = this.LowIntensityBrush;
        }

        /// <summary>
        /// Gets or sets the brush used to paint the icon.
        /// </summary>
        public Brush LowIntensityBrush
        {
            get => (Brush)this.GetValue(LowIntensityBrushProperty);
            set => this.SetValue(LowIntensityBrushProperty, value);
        }

        /// <summary>
        /// The brush changed event
        /// </summary>
        /// <param name="d">The sender</param>
        /// <param name="e">The event argument</param>
        private static void OnLowIntensityPropertyChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            if (d is LowIntensityIcon lowIntensity)
            {
                Brush newBrush = e.NewValue as Brush;
                lowIntensity.LowIntensityPath.Fill = newBrush;
                lowIntensity.LowIntensityPath.Stroke = newBrush;
            }
        }
    }
}
