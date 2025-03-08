namespace Asland
{
    using Asland.Common.Utils;
    using Asland.Interfaces.ViewModels;
    using Asland.Interfaces.Common.Utils;
    using Asland.ViewModels;
    using CommunityToolkit.Mvvm.DependencyInjection;
    using Factories;
    using Interfaces;
    using Interfaces.Factories;
    using Interfaces.Model.IO.Data;
    using Interfaces.Model.IO.DataEntry;
    using Interfaces.ViewModels.Body;
    using Interfaces.ViewModels.Ribbon;
    using Microsoft.Extensions.DependencyInjection;
    using Model.IO.Data;
    using Model.IO.DataEntry;
    using ViewModels.Body;
    using ViewModels.Ribbon;

    /// <summary>
    /// Factory class, used to set up dependency injection
    /// </summary>
    public static class IocFactory
    {
        /// <summary>
        /// Setup IOC.
        /// </summary>
        public static void Setup()
        {
            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                .AddSingleton<IAsLogger, AsLogger>()
                .AddSingleton<IYearSearcher, YearSearcher>()
                .AddSingleton<IPathManager, PathManager>()
                .AddSingleton<ILocationSearchFactory, LocationSearchFactory>()
                .AddSingleton<ITimeSearchFactory, TimeSearchFactory>()
                .AddSingleton<IDataManager, DataManager>()
                .AddSingleton<IBeastieSearchFactory, BeastieSearchFactory>()
                .AddSingleton<IBeastieDataFileFactory, BeastieDataFileFactory>()
                .AddSingleton<IEventEntry, EventEntry>()
                .AddSingleton<IMainWindowViewModel, MainWindowViewModel>()
                .AddSingleton<IRibbonViewModel, RibbonViewModel>()
                .AddSingleton<IBodyViewModel, BodyViewModel>()
                .AddSingleton<IStatusBarViewModel, StatusBarViewModel>()
                .BuildServiceProvider());
        }
    }
}
