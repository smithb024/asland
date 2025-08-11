namespace Asland.Views.Icons
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    /// <summary>
    /// Interaction logic for CommuteIcon.xaml
    /// </summary>
    public partial class CommuteIcon : UserControl
    {

        /// <summary>
        /// Used to paint this icon
        /// </summary>
        public static readonly DependencyProperty FillIconProperty =
            DependencyProperty.Register(
              nameof(FillIcon),
              typeof(Brush),
              typeof(CommuteIcon),
              new PropertyMetadata(
                  new SolidColorBrush(Colors.HotPink),
                  OnCommuteIconPropertyChanged));

        /// <summary>
        /// Initialises a new instance of the <see cref="CommuteIcon"/> class.
        /// </summary>
        public CommuteIcon()
        {
            this.InitializeComponent();
            this.CommuteIconPath.Fill = this.FillIcon;
            this.CommuteIconPath.Stroke = this.FillIcon;
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
        private static void OnCommuteIconPropertyChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            if (d is CommuteIcon snapshot)
            {
                Brush newBrush = e.NewValue as Brush;
                snapshot.CommuteIconPath.Fill = newBrush;
                snapshot.CommuteIconPath.Stroke = newBrush;
            }
        }
    }
}
