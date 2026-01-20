namespace Asland.ViewModels.Body.Reports
{
    using Asland.Common.Enums;
    using Asland.Interfaces.ViewModels.Body.Reports;
    using Asland.Interfaces.ViewModels.Icons;
    using Asland.Factories.IO;
    using Asland.Model.IO;
    using Asland.ViewModels.Icons;
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
        /// <param name="observations">the raw observations</param>
        /// <param name="path">the path to the raw event</param>
        /// <param name="openEventData">
        /// The command which is used to open and display the event.
        /// </param>
        public CalendarItem(
            RawObservations observations,
            string path,
            Action<string> openEventData)
        {
            this.path = path;
            this.Day = observations.Date.Substring(0, 2);
            this.Name = observations.Location;
            this.Intensity = observations.Intensity;
            this.openEventData = openEventData;
            this.BeastieCounter =
                observations.Species.Kind.Count +
                observations.Heard.Kind.Count;

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
        /// Gets the number of beasties present in the event. 
        /// </summary>
        public int BeastieCounter { get; }

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