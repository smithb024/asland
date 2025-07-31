namespace Asland.Views.Icons
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    /// <summary>
    /// Interaction logic for SnapshotIcon.xaml
    /// </summary>
    public partial class SnapshotIcon : UserControl
    {
        /// <summary>
        /// Used to paint this icon
        /// </summary>
        public static readonly DependencyProperty FillIconProperty =
            DependencyProperty.Register(
              nameof(FillIcon),
              typeof(Brush),
              typeof(SnapshotIcon),
              new PropertyMetadata(
                  new SolidColorBrush(Colors.HotPink),
                  OnSnapshotIconPropertyChanged));

        /// <summary>
        /// Initialises a new instance of the <see cref="SnapshotIcon"/> class.
        /// </summary>
        public SnapshotIcon()
        {
            this.InitializeComponent();
            this.SnapshotIconPath.Fill = this.FillIcon;
            this.SnapshotIconPath.Stroke = this.FillIcon;
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
        private static void OnSnapshotIconPropertyChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            if (d is SnapshotIcon snapshot)
            {
                Brush newBrush = e.NewValue as Brush;
                snapshot.SnapshotIconPath.Fill = newBrush;
                snapshot.SnapshotIconPath.Stroke = newBrush;
            }
        }
    }
}
