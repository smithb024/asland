﻿namespace Asland.Interfaces.ViewModels.Body
{
    using System.Collections.Generic;
    using System.Windows.Input;
    using Asland.Interfaces.ViewModels.Common;

    /// <summary>
    /// Interface for a view model which supports the data entry view. This is the top level view
    /// of data entry and should also support switching between the different sub views.
    /// </summary>
    public interface IReportsViewModel
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