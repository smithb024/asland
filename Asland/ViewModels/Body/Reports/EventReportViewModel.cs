namespace Asland.ViewModels.Body.Reports
{
    using System;
    using System.Collections.ObjectModel;
    using Asland.Common.Enums;
    using Asland.Factories.IO;
    using Asland.Interfaces;
    using Asland.Interfaces.ViewModels.Body.Reports;
    using Asland.Model.IO;
    using Asland.Model.IO.Data;
    using NynaeveLib.ViewModel;

    /// <summary>
    /// A single event view model for the reports tab.
    /// </summary>
    public class EventReportViewModel : ViewModelBase, IEventReportViewModel
    {
        /// <summary>
        /// The path manager.
        /// </summary>
        private readonly IPathManager pathManager;

        /// <summary>
        /// Function used to retrieve a specific beastie from the model.
        /// </summary>
        private readonly Func<string, Beastie> getBeastie;

        /// <summary>
        /// Initialises a new instance of the <see cref="EventReportViewModel"/> class.
        /// </summary>
        /// <param name="pathManager">the path manager</param>
        /// <param name="getBeastie">
        /// The function used to return a specific beastie from the data model.
        /// </param>
        public EventReportViewModel(
            IPathManager pathManager,
            Func<string, Beastie> getBeastie)
        {
            this.pathManager = pathManager;
            this.getBeastie = getBeastie;

            this.Location = string.Empty;
            this.Date = string.Empty;
            this.Notes = string.Empty;
            this.Length = string.Empty;
            this.Intensity = ObservationIntensity.NotRecorded;
            this.TimeOfDay = string.Empty;
            this.Weather = string.Empty;
            this.Habitats = new ObservableCollection<string>();

            this.Beasties = new ObservableCollection<IBeastieReportIconViewModel>();
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
        /// Gets the beasties present in the event.
        /// </summary>
        public ObservableCollection<IBeastieReportIconViewModel> Beasties { get; }

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

            this.Beasties.Clear();

            foreach (string beastie in observations.Species.Kind)
            {
                Beastie modelBeastie = this.getBeastie(beastie);

                IBeastieReportIconViewModel beastieIcon =
                    new BeastieReportIconViewModel(
                        this.pathManager,
                        modelBeastie.Name,
                        modelBeastie.DisplayName,
                        modelBeastie?.LatinName ?? string.Empty,
                        modelBeastie?.Image ?? string.Empty,
                        modelBeastie?.Presence ?? (Presence)(-1));

                this.Beasties.Add(beastieIcon);
            }

            foreach (string beastie in observations.Heard.Kind)
            {
                Beastie modelBeastie = this.getBeastie(beastie);

                IBeastieReportIconViewModel beastieIcon =
                    new BeastieReportIconViewModel(
                        this.pathManager,
                        modelBeastie.Name,
                        modelBeastie.DisplayName,
                        modelBeastie?.LatinName ?? string.Empty,
                        modelBeastie?.Image ?? string.Empty,
                        modelBeastie?.Presence ?? (Presence)(-1));

                this.Beasties.Add(beastieIcon);
            }

            this.RaisePropertyChangedEvent(nameof(this.Location));
            this.RaisePropertyChangedEvent(nameof(this.Date));
            this.RaisePropertyChangedEvent(nameof(this.Notes));
            this.RaisePropertyChangedEvent(nameof(this.Length));
            this.RaisePropertyChangedEvent(nameof(this.Intensity));
            this.RaisePropertyChangedEvent(nameof(this.TimeOfDay));
            this.RaisePropertyChangedEvent(nameof(this.Weather));
            this.RaisePropertyChangedEvent(nameof(this.Habitats));
            this.RaisePropertyChangedEvent(nameof(this.Beasties));
        }
    }
}