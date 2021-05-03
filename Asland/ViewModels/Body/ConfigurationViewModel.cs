namespace Asland.ViewModels.Body
{
    using System.Collections.Generic;
    using Asland.Interfaces.ViewModels.Body;
    using Asland.ViewModels.Body.Configuration;
    using NynaeveLib.Commands;
    using NynaeveLib.Utils;
    using NynaeveLib.ViewModel;

    /// <summary>
    /// View model which suports the configuration view.
    /// This manages all aspects of the configuration process including the different sub views.
    /// </summary>
    public class ConfigurationViewModel : ViewModelBase, IConfigurationViewModel
    {
        /// <summary>
        /// String used for the event details button. This button is used to select the page where
        /// the user enters the general information about the event.
        /// </summary>
        private const string ConfigureBeastie = "Configure Beastie";

        /// <summary>
        /// Initialises a new instance of the <see cref="ConfigurationViewModel"/> class.
        /// </summary>
        public ConfigurationViewModel()
        {
            this.CurrentWorkspace =
                new BeastieConfigurationViewModel();

            this.PopulatePageSelector(ConfigureBeastie);
        }

        /// <summary>
        /// Gets the view model for the workspace which is displayed.
        /// </summary>
        public object CurrentWorkspace { get; private set; }

        /// <summary>
        /// Gets a selection of commands which are used to choose a page to display.
        /// </summary>
        public List<IIndexCommand<string>> PageSelector { get; private set; }

        /// <summary>
        /// Add a new command to the collection of page selector commands.
        /// </summary>
        /// <param name="pageName">
        /// Name of the page the new command represents.
        /// </param>
        private void PopulatePageSelector(string pageName)
        {
            if (this.PageSelector == null)
            {
                this.PageSelector = new List<IIndexCommand<string>>();
            }

            IIndexCommand<string> showEventDetails =
                new IndexCommand<string>(
                    pageName,
                    this.NewPage);

            this.PageSelector.Add(showEventDetails);
        }

        /// <summary>
        /// Select a new page for the view.
        /// </summary>
        /// <param name="newPageName">
        /// Name of the page to display.
        /// </param>
        private void NewPage(string newPageName)
        {
            if (StringCompare.SimpleCompare(newPageName, ConfigureBeastie))
            {
                if (this.CurrentWorkspace.GetType() != typeof(BeastieConfigurationViewModel))
                {

                    this.CurrentWorkspace = new BeastieConfigurationViewModel();
                    this.RaisePropertyChangedEvent(nameof(this.CurrentWorkspace));
                }
            }
        }
    }
}