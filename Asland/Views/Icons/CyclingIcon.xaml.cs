namespace Asland.Views.Icons
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    /// <summary>
    /// Interaction logic for CyclingIcon.xaml
    /// </summary>
    public partial class CyclingIcon : UserControl
    {
        /// <summary>
        /// Used to paint this icon
        /// </summary>
        public static readonly DependencyProperty FillIconProperty =
            DependencyProperty.Register(
              nameof(FillIcon),
              typeof(Brush),
              typeof(CyclingIcon),
              new PropertyMetadata(
                  new SolidColorBrush(Colors.White),
                  OnCyclingIconPropertyChanged));

        /// <summary>
        /// Initialises a new instance of the <see cref="CyclingIcon"/> class.
        /// </summary>
        public CyclingIcon()
        {
            this.InitializeComponent();
            this.CyclingIconPath.Fill = this.FillIcon;
            this.CyclingIconPath.Stroke = this.FillIcon;
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
        private static void OnCyclingIconPropertyChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            if (d is CyclingIcon snapshot)
            {
                Brush newBrush = e.NewValue as Brush;
                snapshot.CyclingIconPath.Fill = newBrush;
                snapshot.CyclingIconPath.Stroke = newBrush;
            }
        }
    }
}
