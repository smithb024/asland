namespace Asland.ViewModels.Body.Analysis
{
    using Asland.Factories.IO;
    using Asland.Interfaces.ViewModels.Body.Analysis;
    using Asland.Model.IO;
    using Asland.ViewModels.Common;
    using NynaeveLib.Logger;
    using NynaeveLib.ViewModel;
    using System;
    using System.Collections.ObjectModel;
    using System.IO;

    /// <summary>
    /// View Model which supports the location view on the analysis tab.
    /// </summary>
    public class LocationViewModel : ViewModelBase, ILocationViewModel
    {
        /// <summary>
        /// The collection of all known locations.
        /// </summary>
        private ObservableCollection<string> locations;

        /// <summary>
        /// The collection of all locations which are being presented.
        /// </summary>
        private ObservableCollection<string> displayedLocations;

        /// <summary>
        /// The index of the currently selected location.
        /// </summary>
        private int selectedLocationIndex;

        /// <summary>
        /// Initialises a new instance of the <see cref="LocationViewModel"/> class.
        /// </summary>
        /// Thrown if there is a problem 
        /// </exception>
        public LocationViewModel()
        {
            this.locations = new ObservableCollection<string>();

            string basePath = DataPath.RawDataPath;
            string[] subdirectoryEntries = Directory.GetDirectories(basePath);

            try
            {
                foreach (string directory in subdirectoryEntries)
                {
                    string[] files = Directory.GetFiles(directory);

                    foreach (string file in files)
                    {
                        RawObservationsString raw = XmlFileIo.ReadXml<RawObservationsString>(file);

                        if (!this.locations.Contains(raw.Location))
                        {
                            this.locations.Add(raw.Location);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog($"LocationViewModel: {ex}");
                Console.WriteLine(ex.ToString());
            }

            this.displayedLocations = this.locations;
            this.selectedLocationIndex = -1;
        }

        /// <summary>
        /// Gets a collection of locations.
        /// </summary>
        public ObservableCollection<string> Locations => this.displayedLocations;

        /// <summary>
        /// Gets or sets the index of the currently selected location.
        /// </summary>
        public int LocationIndex 
        { 
            get => this.selectedLocationIndex;
            set
            {
                if (this.selectedLocationIndex == value)
                {
                    return;
                }

                this.selectedLocationIndex = value;
                this.RaisePropertyChangedEvent(nameof(this.LocationIndex));
            }
        }
    }
}