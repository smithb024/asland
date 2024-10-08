﻿namespace Asland.Interfaces.ViewModels.Body.Analysis.Common
{
    using Asland.Common.Enums;

    /// <summary>
    /// This interface counts a single intensity.
    /// </summary>
    public interface IIntensityCounterViewModel
    {
        /// <summary>
        /// Gets the <see cref="ObservationIntensity"/> which is the subject of this view model.
        /// </summary>
        ObservationIntensity Name { get; }

        /// <summary>
        /// Gets the <see cref="Name"/> as a string.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the total number of occurances of <see cref="Name"/>.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Add one to the <see cref="Count"/>.
        /// </summary>
        void CountIntensity();
    }
}