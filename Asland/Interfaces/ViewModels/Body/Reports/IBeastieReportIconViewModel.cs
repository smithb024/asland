﻿namespace Asland.Interfaces.ViewModels.Body.Reports
{
    using Asland.Common.Enums;

    /// <summary>
    /// Interface which supports a beastie icon which is displayed on a report pane.
    /// </summary>
    public interface IBeastieReportIconViewModel
    {
        /// <summary>
        /// Gets the name of the beastie.
        /// </summary>
        string CommonName { get; }

        /// <summary>
        /// Gets the (latin) name of the beastie.
        /// </summary>
        string LatinName { get; }

        /// <summary>
        /// Gets the path to an image of the beastie.
        /// </summary>
        string ImagePath { get; }

        /// <summary>
        /// Gets a value which indicates the residential status of the beastie.
        /// </summary>
        Presence Presence { get; }
    }
}
