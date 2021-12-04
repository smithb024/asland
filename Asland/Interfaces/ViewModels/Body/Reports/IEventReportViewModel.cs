namespace Asland.Interfaces.ViewModels.Body.Reports
{
    using System;
    using System.Collections.ObjectModel;
    using Asland.Common.Enums;

    /// <summary>
    /// Interface which supports a single event on the reports tab.
    /// </summary>
    public interface IEventReportViewModel
    {
        /// <summary>
        /// Gets or sets the location of the event.
        /// </summary>
        string Location { get; }

        /// <summary>
        /// Gets or sets the date of the event.
        /// </summary>
        string Date { get; }

        /// <summary>
        /// Gets or sets any notes pertaining to the event.
        /// </summary>
        string Notes { get; }

        /// <summary>
        /// Gets the length of the event.
        /// </summary>
        string Length { get; }

        /// <summary>
        /// Gets the intensity of the event.
        /// </summary>
        ObservationIntensity Intensity { get; }

        /// <summary>
        /// Gets the time of day.
        /// </summary>
        string TimeOfDay { get; }

        /// <summary>
        /// Gets the weather.
        /// </summary>
        string Weather { get; }

        /// <summary>
        /// Gets the habitats present in the event.
        /// </summary>
        ObservableCollection<string> Habitats { get; }

        /// <summary>
        /// Gets the beasties present in the event.
        /// </summary>
        ObservableCollection<IBeastieReportIconViewModel> Beasties { get; }

        /// <summary>
        /// Open the event specified by the path.
        /// </summary>
        /// <param name="path">
        /// The path to the raw data for the event to be opened.
        /// </param>
        void OpenEvent(string path);
    }
}