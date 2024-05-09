namespace Asland.ViewModels.Body.Analysis
{
    using Asland.Factories.IO;
    using Asland.Interfaces;
    using Asland.Interfaces.Factories;
    using Asland.Interfaces.ViewModels.Body.Analysis;
    using Asland.Interfaces.ViewModels.Body.Analysis.Location;
    using Asland.Model.IO;
    using Asland.ViewModels.Body.Analysis.Location;
    using NynaeveLib.Logger;
    using NynaeveLib.ViewModel;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;

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
        /// Show the NT locations.
        /// </summary>
        private bool isNt;

        /// <summary>
        /// Show the WT locations.
        /// </summary>
        private bool isWt;

        /// <summary>
        /// Show the WWT locations.
        /// </summary>
        private bool isWwt;

        /// <summary>
        /// Show the RSPB locations.
        /// </summary>
        private bool isRspb;

        /// <summary>
        /// Initialises a new instance of the <see cref="LocationViewModel"/> class.
        /// </summary>
        /// <param name="search">The search factory.</param>
        /// <param name="pathManager">the path manager</param>
        public LocationViewModel(
            ILocationSearchFactory search,
            IPathManager pathManager)
        {
            this.locations = new ObservableCollection<string>();

            string basePath = pathManager.RawDataPath;
            string[] subdirectoryEntries = Directory.GetDirectories(basePath);

            try
            {
                List<string> rawLocations = new List<string>();

                foreach (string directory in subdirectoryEntries)
                {
                    string[] files = Directory.GetFiles(directory);

                    foreach (string file in files)
                    {
                        RawObservationsString raw = XmlFileIo.ReadXml<RawObservationsString>(file);

                        if (!rawLocations.Contains(raw.Location))
                        {
                            rawLocations.Add(raw.Location);
                        }
                    }
                }

                rawLocations = rawLocations.OrderBy(x => x).ToList();

                foreach(string rawLocation in rawLocations)
                {
                    this.locations.Add(rawLocation);
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog($"LocationViewModel: {ex}");
                Console.WriteLine(ex.ToString());
            }

            this.Summary = 
                new LocSummaryViewModel(
                    search,
                    pathManager);
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
                this.Summary.SetNewLocation(
                    this.Locations[this.LocationIndex]);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to just show NT locations.
        /// </summary>
        public bool IsNt
        {
            get => this.isNt;
            set
            {
                if (this.isNt == value)
                {
                    return;
                }

                this.isNt = value;

                if (this.isNt == true)
                {
                    this.isWt = false;
                    this.isWwt = false;
                    this.isRspb = false;

                    this.RaisePropertyChangedEvent(nameof(this.IsWt));
                    this.RaisePropertyChangedEvent(nameof(this.IsWwt));
                    this.RaisePropertyChangedEvent(nameof(this.IsRspb));
                }

                this.RaisePropertyChangedEvent(nameof(this.IsNt));
                this.ResetLocationsCollection();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to just show WT locations.
        /// </summary>
        public bool IsWt
        {
            get => this.isWt;
            set
            {
                if (this.isWt == value)
                {
                    return;
                }

                this.isWt = value;

                if (this.isWt == true)
                {
                    this.isNt = false;
                    this.isWwt = false;
                    this.isRspb = false;

                    this.RaisePropertyChangedEvent(nameof(this.IsNt));
                    this.RaisePropertyChangedEvent(nameof(this.IsWwt));
                    this.RaisePropertyChangedEvent(nameof(this.IsRspb));
                }

                this.RaisePropertyChangedEvent(nameof(this.IsWt));
                this.ResetLocationsCollection();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to just show WWT locations.
        /// </summary>
        public bool IsWwt
        {
            get => this.isWwt;
            set
            {
                if (this.isWwt == value)
                {
                    return;
                }

                this.isWwt = value;

                if (this.isWwt == true)
                {
                    this.isWt = false;
                    this.isNt = false;
                    this.isRspb = false;

                    this.RaisePropertyChangedEvent(nameof(this.IsWt));
                    this.RaisePropertyChangedEvent(nameof(this.IsNt));
                    this.RaisePropertyChangedEvent(nameof(this.IsRspb));
                }

                this.RaisePropertyChangedEvent(nameof(this.IsWwt));
                this.ResetLocationsCollection();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to just show RSPB locations.
        /// </summary>
        public bool IsRspb
        {
            get => this.isRspb;
            set
            {
                if (this.isRspb == value)
                {
                    return;
                }

                this.isRspb = value;

                if (this.isRspb == true)
                {
                    this.isWt = false;
                    this.isWwt = false;
                    this.isNt = false;

                    this.RaisePropertyChangedEvent(nameof(this.IsWt));
                    this.RaisePropertyChangedEvent(nameof(this.IsWwt));
                    this.RaisePropertyChangedEvent(nameof(this.IsNt));
                }

                this.RaisePropertyChangedEvent(nameof(this.IsRspb));
                this.ResetLocationsCollection();
            }
        }

        /// <summary>
        /// Gets the summary for the selected location.
        /// </summary>
        public ILocSummaryViewModel Summary { get; }

        /// <summary>
        /// Reset the locations list using the filters if required.
        /// </summary>
        private void ResetLocationsCollection()
        {
            ObservableCollection<string> filteredLocations =
                new ObservableCollection<string>();

            foreach (string location in this.locations)
            {
                if (this.CheckFilter(
                    this.isNt,
                    "NT",
                    location,
                    ref filteredLocations))
                {
                    continue;
                }
                else if (this.CheckFilter(
                    this.IsRspb,
                    "RSPB",
                    location,
                    ref filteredLocations))
                {
                    continue;
                }
                else if (this.CheckFilter(
                    this.isWt,
                    "WT",
                    location,
                    ref filteredLocations))
                {
                    continue;
                }
                else if (this.CheckFilter(
                    this.isWwt,
                    "WWT",
                    location,
                    ref filteredLocations))
                {
                    continue;
                }
                else
                {
                    filteredLocations.Add(location);
                }
            }

            this.displayedLocations = filteredLocations;
            this.selectedLocationIndex = -1;

            this.RaisePropertyChangedEvent(nameof(this.Locations));
            this.RaisePropertyChangedEvent(nameof(this.LocationIndex));
        }

        /// <summary>
        /// Check to see if the <paramref name="isFilterSet"/> filter is set. If it is, check to 
        /// see if the <paramref name="location"/> matches the <paramref name="filterString"/>.
        /// Always check the start of the <paramref name="location"/> string.
        /// If it passes, add it to the <paramref name="filteredLocations"/>.
        /// </summary>
        /// <param name="isFilterSet">The filter set flag</param>
        /// <param name="filterString">
        /// The string to filter the <paramref name="location"/> on.
        /// </param>
        /// <param name="location">The location to check.</param>
        /// <param name="filteredLocations">
        /// The collection of locations which have passed the filter so far.
        /// </param>
        /// <returns>
        /// Return true if the filter is in play.
        /// </returns>
        private bool CheckFilter(
            bool isFilterSet,
            string filterString,
            string location,
            ref ObservableCollection<string> filteredLocations)
        {
            if (isFilterSet)
            {
                if (location.StartsWith(filterString))
                {
                    filteredLocations.Add(location);
                }
                return true;
            }

            return false;
        }
    }
}