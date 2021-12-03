namespace Asland.ViewModels.Body.Reports
{
    using System;
    using System.Collections.ObjectModel;
    using Asland.Common.Enums;
    using Asland.Factories.IO;
    using Asland.Interfaces.ViewModels.Body.Reports;
    using Asland.Model.IO;
    using NynaeveLib.ViewModel;

    /// <summary>
    /// A single event view model for the reports tab.
    /// </summary>
    public class EventReportViewModel : ViewModelBase, IEventReportViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="EventReportViewModel"/> class.
        /// </summary>
        public EventReportViewModel()
        {
            this.Location = string.Empty;
            this.Date = string.Empty;
            this.Notes = string.Empty;
            this.Length = string.Empty;
            this.Intensity = ObservationIntensity.NotRecorded;
            this.TimeOfDay = string.Empty;
            this.Weather = string.Empty;
            this.Habitats = new ObservableCollection<string>();
        }

        /// <summary>
        /// Gets or sets the location of the event.
        /// </summary>
        public string Location { get; private set; }

        /// <summary>
        /// Gets or sets the date of the event.
        /// </summary>
        public string Date { get; private set; }

        /// <summary>
        /// Gets or sets any notes pertaining to the event.
        /// </summary>
        public string Notes { get; private set; }

        /// <summary>
        /// Gets the length of the event.
        /// </summary>
        public string Length { get; private set; }

        /// <summary>
        /// Gets the intensity of the event.
        /// </summary>
        public ObservationIntensity Intensity { get; private set; }

        /// <summary>
        /// Gets the time of day.
        /// </summary>
        public string TimeOfDay { get; private set; }

        /// <summary>
        /// Gets the weather.
        /// </summary>
        public string Weather { get; private set; }

        /// <summary>
        /// Gets the habitats present in the event.
        /// </summary>
        public ObservableCollection<string> Habitats { get; private set; }

        /// <summary>
        /// Open the event specified by the path.
        /// </summary>
        /// <param name="path">
        /// The path to the raw data for the event to be opened.
        /// </param>
        public void OpenEvent(string path)
        {
            RawObservations observations =
                XmlFileIo.ReadXml<RawObservations>(
                    path);

            if (observations == null)
            {
                return;
            }

            this.Location = observations.Location;
            this.Date = observations.Date;
            this.Notes = observations.Notes;
            this.Length = observations.Length.ToString();
            this.Intensity = observations.Intensity;
            this.TimeOfDay = observations.TimeOfDay.ToString();
            this.Weather = observations.Weather.ToString();

            this.Habitats.Clear();

            foreach (ObservationHabitat habitat in observations.Habitats.Habitats)
            {
                this.Habitats.Add(habitat.ToString());
            }

            this.RaisePropertyChangedEvent(nameof(this.Location));
            this.RaisePropertyChangedEvent(nameof(this.Date));
            this.RaisePropertyChangedEvent(nameof(this.Notes));
            this.RaisePropertyChangedEvent(nameof(this.Length));
            this.RaisePropertyChangedEvent(nameof(this.Intensity));
            this.RaisePropertyChangedEvent(nameof(this.TimeOfDay));
            this.RaisePropertyChangedEvent(nameof(this.Weather));
            this.RaisePropertyChangedEvent(nameof(this.Habitats));
        }
    }
}