namespace Asland.Views.Ribbon
{
    using Asland.Interfaces.ViewModels.Ribbon;
    using CommunityToolkit.Mvvm.DependencyInjection;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for Ribbon.xaml
    /// </summary>
    public partial class Ribbon : UserControl
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="Ribbon"/> class.
        /// </summary>
        public Ribbon()
        {
            this.InitializeComponent();
            this.DataContext = Ioc.Default.GetService<IRibbonViewModel>();
        }
    }
}
