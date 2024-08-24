namespace Asland
{
    using Asland.Interfaces.ViewModels;
    using CommunityToolkit.Mvvm.DependencyInjection;
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = Ioc.Default.GetService<IMainWindowViewModel>();
        }
    }
}
