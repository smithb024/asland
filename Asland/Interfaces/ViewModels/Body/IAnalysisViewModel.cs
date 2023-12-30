namespace Asland.Interfaces.ViewModels.Body
{
    using Asland.Interfaces.ViewModels.Common;
    using System.Collections.Generic;

    /// <summary>
    /// Interface for a view model which supports the report view. This is the top level view
    /// for reports and should also support switching between the different sub views.
    /// </summary>
    public interface IAnalysisViewModel
    {
        /// <summary>
        /// Gets the view model for the workspace which is displayed.
        /// </summary>
        object CurrentWorkspace { get; }

        /// <summary>
        /// Gets a selection of commands which are used to choose a page to display.
        /// </summary>
        List<IPageSelector> PageSelector { get; }
    }
}