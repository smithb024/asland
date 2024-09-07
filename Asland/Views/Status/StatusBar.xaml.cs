namespace Asland.Views.Status
{
    using Asland.Interfaces.ViewModels.Ribbon;
    using CommunityToolkit.Mvvm.DependencyInjection;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for StatusBar.xaml
    /// </summary>
    public partial class StatusBar : UserControl
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="StatusBar"/> class.
        /// </summary>
        public StatusBar()
        {
            this.InitializeComponent();
            this.DataContext = Ioc.Default.GetService<IRibbonViewModel>();
        }
    }
}
