namespace Asland.Interfaces.ViewModels.Body.Reports
{
    using System.Windows.Input;
    using Asland.Common.Enums;

    /// <summary>
    /// Interface for a view model which supports a single calendar item on the reports tab.
    /// </summary>
    public interface ICalendarItem
    {
        /// <summary>
        /// Gets the day in the month when the event was held.
        /// </summary>
        string Day { get; }

        /// <summary>
        /// Gets the name of the event represented by this item.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the intensity of the event.
        /// </summary>
        ObservationIntensity Intensity { get; }

        /// <summary>
        /// Gets the command used to select a new event.
        /// </summary>
        ICommand SelectNewEvent { get; }
    }
}