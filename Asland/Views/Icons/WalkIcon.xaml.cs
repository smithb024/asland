namespace Asland.Views.Icons
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    /// <summary>
    /// Interaction logic for WalkIcon.xaml
    /// </summary>
    public partial class WalkIcon : UserControl
    {
        /// <summary>
        /// Used to paint this icon
        /// </summary>
        public static readonly DependencyProperty FillIconProperty =
            DependencyProperty.Register(
              nameof(FillIcon),
              typeof(Brush),
              typeof(WalkIcon),
              new PropertyMetadata(
                  new SolidColorBrush(Colors.HotPink),
                  OnWalkIconPropertyChanged));

        /// <summary>
        /// Initialises a new instance of the <see cref="WalkIcon"/> class.
        /// </summary>
        public WalkIcon()
        {
            this.InitializeComponent();
            this.WalkIconPath.Fill = this.FillIcon;
            this.WalkIconPath.Stroke = this.FillIcon;
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
        private static void OnWalkIconPropertyChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            if (d is WalkIcon snapshot)
            {
                Brush newBrush = e.NewValue as Brush;
                snapshot.WalkIconPath.Fill = newBrush;
                snapshot.WalkIconPath.Stroke = newBrush;
            }
        }
    }
}
