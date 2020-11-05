namespace Asland.ViewModels
{
    using Asland.Interfaces.ViewModels;
    using Asland.Interfaces.ViewModels.Body;
    using Asland.Interfaces.ViewModels.Ribbon;
    using Asland.ViewModels.Body;
    using Asland.ViewModels.Ribbon;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight.Ioc;

    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            //if (ViewModelBase.IsInDesignModeStatic)
            //{
            //    SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
            //}
            //else
            //{
            //    SimpleIoc.Default.Register<IDataService, DataService>();
            //}

            SimpleIoc.Default.Unregister<IMainWindowViewModel>();
            SimpleIoc.Default.Unregister<IRibbonViewModel>();
            SimpleIoc.Default.Unregister<IBodyViewModel>();

            SimpleIoc.Default.Register<IMainWindowViewModel, MainWindowViewModel>();
            SimpleIoc.Default.Register<IRibbonViewModel, RibbonViewModel>();
            SimpleIoc.Default.Register<IBodyViewModel, BodyViewModel>();
        }

        /// <summary>
        /// Main window view model
        /// </summary>
        public IMainWindowViewModel MainWindow =>
            SimpleIoc.Default.GetInstance<IMainWindowViewModel>();

        /// <summary>
        /// Ribbon view model
        /// </summary>
        public IRibbonViewModel Ribbon =>
            SimpleIoc.Default.GetInstance<IRibbonViewModel>();

        /// <summary>
        /// Body pane view model
        /// </summary>
        public IBodyViewModel Body =>
            SimpleIoc.Default.GetInstance<IBodyViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}