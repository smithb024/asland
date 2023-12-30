namespace Asland.ViewModels.Body
{
    using Asland.Interfaces.ViewModels.Body;
    using Asland.Interfaces.ViewModels.Common;
    using Common;
    using NynaeveLib.Utils;
    using NynaeveLib.ViewModel;
    using System;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// View model which suports the analysis view.
    /// This manages all aspects of the analysis process including the different sub views.
    /// </summary>
    public class AnalysisViewModel : ViewModelBase, IAnalysisViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="AnalysisViewModel"/> class.
        /// </summary>
        public AnalysisViewModel()
        {
            this.PageSelector = new List<IPageSelector>();

            IPageSelector eventSelector =
                new PageSelector(
                    "To Fill In",
                    this.NewPage);

            this.PageSelector.Add(eventSelector);

            this.CurrentWorkspace = null;
        }

        /// <summary>
        /// Gets the view model for the workspace which is displayed.
        /// </summary>
        public object CurrentWorkspace { get; private set; }

        /// <summary>
        /// Gets a selection of commands which are used to choose a page to display.
        /// </summary>
        public List<IPageSelector> PageSelector { get; private set; }

        /// <summary>
        /// Select a new page for the view.
        /// </summary>
        /// <param name="newPageName">
        /// Name of the page to display.
        /// </param>
        private void NewPage(string newPageName)
        {
            //if (StringCompare.SimpleCompare(newPageName, "To Fill In"))
            //{
            //    this.CurrentWorkspace = null;
            //}

            //this.ResetSelectedPage(newPageName);

            //this.RaisePropertyChangedEvent(nameof(this.CurrentWorkspace));
        }

        /// <summary>
        /// Inform each of the components in the page selector collection of the name of the 
        /// currently selected page.
        /// </summary>
        /// <param name="pageName">page name</param>
        private void ResetSelectedPage(string pageName)
        {
            foreach (IPageSelector pageSelector in this.PageSelector)
            {
                pageSelector.SelectedButton(pageName);
            }
        }
    }
}