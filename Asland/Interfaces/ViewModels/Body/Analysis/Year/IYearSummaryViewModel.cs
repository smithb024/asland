﻿namespace Asland.Interfaces.ViewModels.Body.Analysis.Year
{
    using Asland.Common.Enums;
    using Asland.Interfaces.ViewModels.Body.Analysis.Common;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Interface which supports the summary view on the year analysis page.
    /// </summary>
    public interface IYearSummaryViewModel
    {
        /// <summary>
        /// Gets the number events counted in the analysis.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Gets the name of the currently selected year.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the beasties present in the analysis.
        /// </summary>
        ObservableCollection<IBeastieAnalysisIconViewModel> Beasties { get; }

        /// <summary>
        /// Gets the locations present in the analysis.
        /// </summary>
        ObservableCollection<IStringCounterViewModel> Locations { get; }

        /// <summary>
        /// Sets a new year for which to display a new set of summary data.
        /// </summary>
        /// <param name="name">The name of the new year</param>
        void SetNewYear(string name);
    }
}
