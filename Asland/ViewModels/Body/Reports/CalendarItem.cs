namespace Asland.ViewModels.Body.Reports
{
    using Asland.Common.Enums;
    using Asland.Interfaces.ViewModels.Body.Reports;

    /// <summary>
    /// A view model which supports a single calendar item on the reports tab.
    /// </summary>
    public class CalendarItem : ICalendarItem
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="CalendarItem"/> calendar.
        /// </summary>
        /// <param name="day">the day of the event</param>
        /// <param name="name">the name of the event</param>
        /// <param name="intensity">
        /// The intensity of the event.
        /// </param>
        public CalendarItem(
            string day,
            string name,
            ObservationIntensity intensity)
        {
            this.Day = day;
            this.Name = name;
            this.Intensity = intensity;
        }

        /// <summary>
        /// Gets the day in the month when the event was held.
        /// </summary>
        public string Day { get; }

        /// <summary>
        /// Gets the name of the event represented by this item.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the intensity of the event.
        /// </summary>
        public ObservationIntensity Intensity { get; }
    }
}