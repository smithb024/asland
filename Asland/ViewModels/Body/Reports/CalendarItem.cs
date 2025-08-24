namespace Asland.ViewModels.Body.Reports
{
    using Asland.Common.Enums;
    using Asland.Interfaces.ViewModels.Body.Reports;
    using Asland.Interfaces.ViewModels.Icons;
    using Asland.ViewModels.Icons;
    using Asland.Views.Icons;
    using NynaeveLib.Commands;
    using System;
    using System.Windows.Input;

    /// <summary>
    /// A view model which supports a single calendar item on the reports tab.
    /// </summary>
    public class CalendarItem : ICalendarItem
    {
        /// <summary>
        /// Path to the event raw data.
        /// </summary>
        private readonly string path;

        /// <summary>
        /// Command which is used to open the event.
        /// </summary>
        private readonly Action<string> openEventData;

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
            ObservationIntensity intensity,
            string path,
            Action<string> openEventData)
        {
            this.Day = day;
            this.Name = name;
            this.Intensity = intensity;
            this.path = path;
            this.openEventData = openEventData;

            this.SelectNewEvent =
                new CommonCommand(
                    this.Select);
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

        /// <summary>
        /// Gets the view model which is used to draw the intensity icon on the calendar view.
        /// </summary>
        public IIntensityIconViewModel IntensityIcon 
        { 
            get
            {
                switch (this.Intensity)
                {
                    case ObservationIntensity.H:
                        return new HighIntensityIconViewModel();

                    case ObservationIntensity.M:
                        return new MediumIntensityIconViewModel();

                    case ObservationIntensity.L:
                        return new LowIntensityIconViewModel();

                    case ObservationIntensity.Snapshot:
                        return new SnapshotIconViewModel();

                    case ObservationIntensity.Commute:
                        return new CommuteIconViewModel();

                    case ObservationIntensity.Run:
                        return new RunIconViewModel();

                    case ObservationIntensity.Cycling:
                        return new CyclingIconViewModel();

                    case ObservationIntensity.Walk:
                        return new WalkIconViewModel();

                    case ObservationIntensity.RailJourney:
                        return new RailIconViewModel();

                    case ObservationIntensity.SeaJourney:
                        return new SeaIconViewModel();

                    default:
                        return null;
                }
            }
        }

        /// <summary>
        /// Gets the command used to select a new event.
        /// </summary>
        public ICommand SelectNewEvent { get; }

        /// <summary>
        /// Invoke the command.
        /// </summary>
        private void Select()
        {
            this.openEventData.Invoke(this.path);
        }
    }
}