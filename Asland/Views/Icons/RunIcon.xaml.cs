namespace Asland.Views.Icons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for RunIcon.xaml
    /// </summary>
    public partial class RunIcon : UserControl
    {
        /// <summary>
        /// Used to paint this icon
        /// </summary>
        public static readonly DependencyProperty FillIconProperty =
            DependencyProperty.Register(
              nameof(FillIcon),
              typeof(Brush),
              typeof(RunIcon),
              new PropertyMetadata(
                  new SolidColorBrush(Colors.HotPink),
                  OnRunIconPropertyChanged));

        /// <summary>
        /// Initialises a new instance of the <see cref="RunIcon"/> class.
        /// </summary>
        public RunIcon()
        {
            this.InitializeComponent();
            this.RunIconPath.Fill = this.FillIcon;
            this.RunIconPath.Stroke = this.FillIcon;
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
        private static void OnRunIconPropertyChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            if (d is RunIcon snapshot)
            {
                Brush newBrush = e.NewValue as Brush;
                snapshot.RunIconPath.Fill = newBrush;
                snapshot.RunIconPath.Stroke = newBrush;
            }
        }
    }
}
