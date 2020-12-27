namespace Asland.ViewModels.Body.DataEntry
{
    using System;
    using Asland.Common.Enums;
    using Asland.Interfaces.ViewModels.Body.DataEntry;
    using Interfaces.ViewModels.Common;
    using NynaeveLib.ViewModel;

    /// <summary>
    /// View model which supports a view reposible for the entry of the event details.
    /// </summary>
    public class EventDetailsEntryViewModel : ViewModelBase, IEventDetailsEntry
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="EventDetailsEntryViewModel"/> class.
        /// </summary>
        public EventDetailsEntryViewModel()
        {

        }

        /// <summary>
        /// Gets or sets the location of the event.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the date of the event.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets any notes pertaining to the event.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the observations currently being marked have 
        /// been seen.
        /// </summary>
        public bool IsSeen { get; set; }

        /// <summary>
        /// Gets the length selector.
        /// </summary>
        public IEnumSelectorViewModel<ObservationLength> LengthSelector { get; }

        /// <summary>
        /// Gets the intensity selector.
        /// </summary>
        public IEnumSelectorViewModel<ObservationIntensity> IntensitySelector { get; }

        /// <summary>
        /// Gets the time of day selector.
        /// </summary>
        public IEnumSelectorViewModel<ObservationTimeOfDay> TimeOfDaySelector { get; }

        /// <summary>
        /// Gets the weather selector.
        /// </summary>
        public IEnumSelectorViewModel<ObservationWeather> WeatherSelector { get; }
    }
}