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
        public static readonly DependencyProperty FillIconProperty =
            DependencyProperty.Register(
              nameof(FillIcon),
              typeof(Brush),
              typeof(LowIntensityIcon),
              new PropertyMetadata(
                  new SolidColorBrush(Colors.HotPink),
                  OnLowIntensityPropertyChanged));

        /// <summary>
        /// Initialises a new instance of the <see cref="LowIntensityIcon"/> class.
        /// </summary>
        public LowIntensityIcon()
        {
            this.InitializeComponent();
            this.LowIntensityPath.Fill = this.FillIcon;
            this.LowIntensityPath.Stroke = this.FillIcon;
        }

        /// <summary>
        /// Gets or sets the brush used to paint the icon.
        /// </summary>
        public Brush FillIcon
        {
            get => (Brush)this.GetValue(FillIconProperty);
            set => this.SetValue(FillIconProperty, value);
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
