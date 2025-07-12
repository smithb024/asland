namespace Asland.Views.Icons
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    /// <summary>
    /// Interaction logic for SeaIcon.xaml
    /// </summary>
    public partial class SeaIcon : UserControl
    {
        /// <summary>
        /// Used to paint this icon
        /// </summary>
        public static readonly DependencyProperty FillIconProperty =
            DependencyProperty.Register(
              nameof(FillIcon),
              typeof(Brush),
              typeof(SeaIcon),
              new PropertyMetadata(
                  new SolidColorBrush(Colors.HotPink),
                  OnSeaIconPropertyChanged));

        /// <summary>
        /// Initialises a new instance of the <see cref="SeaIcon"/> class.
        /// </summary>
        public SeaIcon()
        {
            InitializeComponent();
            this.SeaIconPath.Fill = this.FillIcon;
            this.SeaIconPath.Stroke = this.FillIcon;
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
        private static void OnSeaIconPropertyChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            if (d is SeaIcon mediumIntensity)
            {
                Brush newBrush = e.NewValue as Brush;
                mediumIntensity.SeaIconPath.Fill = newBrush;
                mediumIntensity.SeaIconPath.Stroke = newBrush;
            }
        }
    }
}
