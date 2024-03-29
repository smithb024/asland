﻿namespace Asland.Interfaces.ViewModels.Ribbon
{
    using System.Collections.Generic;
    using Asland.Interfaces.ViewModels.Common;

    /// <summary>
    /// Interface which describes the ribbon view model.
    /// </summary>
    public interface IRibbonViewModel
    {
        /// <summary>
        /// Gets a selection of commands which are used to choose a page to display.
        /// </summary>
        List<IPageSelector> PageSelector { get; }
    }
}