namespace Asland.Interfaces.ViewModels.Body.DataEntry
{
    using System;
    using Asland.Common.Enums;
    using Interfaces.ViewModels.Common;

    /// <summary>
    /// Interface for a view model which supports a view reposible for the entry of the event 
    /// details.
    /// </summary>
    public interface IEventDetailsEntry
    {
        /// <summary>
        /// Gets or sets the location of the event.
        /// </summary>
        string Location { get; set; }

        /// <summary>
        /// Gets or sets the date of the event.
        /// </summary>
        DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets any notes pertaining to the event.
        /// </summary>
        string Notes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the observations currently being marked have 
        /// been seen.
        /// </summary>
        bool IsSeen { get; set; }

        /// <summary>
        /// Gets the length selector.
        /// </summary>
        IEnumSelectorViewModel<ObservationLength> LengthSelector { get; }

        /// <summary>
        /// Gets the intensity selector.
        /// </summary>
        IEnumSelectorViewModel<ObservationIntensity> IntensitySelector { get; }

        /// <summary>
        /// Gets the time of day selector.
        /// </summary>
        IEnumSelectorViewModel<ObservationTimeOfDay> TimeOfDaySelector { get; }

        /// <summary>
        /// Gets the weather selector.
        /// </summary>
        IEnumSelectorViewModel<ObservationWeather> WeatherSelector { get; }

        /// <summary>
        /// Gets the habitats selector.
        /// </summary>
        IEnumSelectorCompoundViewModel<ObservationHabitat> HabitatSelector { get; }
    }
}