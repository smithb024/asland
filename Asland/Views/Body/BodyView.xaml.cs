namespace Asland.Views.Body
{
    using Asland.Interfaces.ViewModels.Body;
    using CommunityToolkit.Mvvm.DependencyInjection;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for BodyView.xaml
    /// </summary>
    public partial class BodyView : UserControl
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="BodyView"/> class
        /// </summary>
        public BodyView()
        {
            this.InitializeComponent();
            this.DataContext = Ioc.Default.GetService<IBodyViewModel>();
        }
    }
}
