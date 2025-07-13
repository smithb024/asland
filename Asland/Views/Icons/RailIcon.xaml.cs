namespace Asland.Views.Icons
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    /// <summary>
    /// Interaction logic for RailIcon.xaml
    /// </summary>
    public partial class RailIcon : UserControl
    {
        /// <summary>
        /// Used to paint this icon
        /// </summary>
        public static readonly DependencyProperty FillIconProperty =
            DependencyProperty.Register(
                nameof(FillIcon),
                typeof(Brush),
                typeof(RailIcon),
                new PropertyMetadata(
                    new SolidColorBrush(Colors.HotPink),
                    OnRailIconPropertyChanged));

        /// <summary>
        /// Initialises a new instance of the <see cref="RailIcon"/> class.
        /// </summary>
        public RailIcon()
        {
            this.InitializeComponent();
            this.RailIconPath.Fill = this.FillIcon;
            this.RailIconPath.Stroke = this.FillIcon;
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
        private static void OnRailIconPropertyChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            if (d is RailIcon railIcon)
            {
                Brush newBrush = e.NewValue as Brush;
                railIcon.RailIconPath.Fill = newBrush;
                railIcon.RailIconPath.Stroke = newBrush;
            }
        }
    }
}
