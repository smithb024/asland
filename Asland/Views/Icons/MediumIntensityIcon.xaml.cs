namespace Asland.Views.Icons
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    /// <summary>
    /// Interaction logic for MediumIntensityIcon.xaml
    /// </summary>
    public partial class MediumIntensityIcon : UserControl
    {
        /// <summary>
        /// Used to paint this icon
        /// </summary>
        public static readonly DependencyProperty FillIconProperty =
            DependencyProperty.Register(
              nameof(FillIcon),
              typeof(Brush),
              typeof(MediumIntensityIcon),
              new PropertyMetadata(
                  new SolidColorBrush(Colors.HotPink),
                  OnMediumIntensityPropertyChanged)); 

        /// <summary>
        /// Initialises a new instance of the <see cref="MediumIntensityIcon"/> class.
        /// </summary>
        public MediumIntensityIcon()
        {
            this.InitializeComponent();
            this.MediumIntensityPath.Fill = this.FillIcon;
            this.MediumIntensityPath.Stroke = this.FillIcon;
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
        private static void OnMediumIntensityPropertyChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            if (d is MediumIntensityIcon mediumIntensity)
            {
                Brush newBrush = e.NewValue as Brush;
                mediumIntensity.MediumIntensityPath.Fill = newBrush;
                mediumIntensity.MediumIntensityPath.Stroke = newBrush;
            }
        }
    }
}
