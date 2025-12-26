namespace Asland.ViewModels.Body.Analysis
{
    using Asland.Factories.IO;
    using Asland.Interfaces;
    using Asland.Interfaces.Factories;
    using Asland.Interfaces.Model.IO.Data;
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
        /// Show the NNR locations.
        /// </summary>
        private bool isNnr;

        /// <summary>
        /// The collection of years.
        /// </summary>
        private ObservableCollection<string> years;

        /// <summary>
        /// The index of the currently selected year.
        /// </summary>
        private int selectedYearsIndex;

        /// <summary>
        /// Indicates whether <see cref="Years"/> should be enabled.
        /// </summary>
        private bool isYearEnabled;

        /// <summary>
        /// Initialises a new instance of the <see cref="LocationViewModel"/> class.
        /// </summary>
        /// <param name="search">The search factory.</param>
        /// <param name="pathManager">the path manager</param>
        /// <param name="dataModel">The data model</param>
        public LocationViewModel(
            ILocationSearchFactory search,
            IPathManager pathManager,
            IDataManager dataModel)
        {
            this.locations = new ObservableCollection<string>();
            this.years = new ObservableCollection<string>();
            this.isYearEnabled = false;

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
                    pathManager,
                    dataModel.FindBeastie);
            this.displayedLocations = this.locations;
            this.selectedLocationIndex = -1;
            this.selectedYearsIndex = -1;
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
                this.OnPropertyChanged(nameof(this.LocationIndex));
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

                    this.OnPropertyChanged(nameof(this.IsWt));
                    this.OnPropertyChanged(nameof(this.IsWwt));
                    this.OnPropertyChanged(nameof(this.IsRspb));
                    this.OnPropertyChanged(nameof(this.IsNnr));
                }

                this.OnPropertyChanged(nameof(this.IsNt));
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
                    this.isNnr = false;

                    this.OnPropertyChanged(nameof(this.IsNt));
                    this.OnPropertyChanged(nameof(this.IsWwt));
                    this.OnPropertyChanged(nameof(this.IsRspb));
                    this.OnPropertyChanged(nameof(this.IsNnr));
                }

                this.OnPropertyChanged(nameof(this.IsWt));
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
                    this.isNnr = false;

                    this.OnPropertyChanged(nameof(this.IsWt));
                    this.OnPropertyChanged(nameof(this.IsNt));
                    this.OnPropertyChanged(nameof(this.IsRspb));
                    this.OnPropertyChanged(nameof(this.IsNnr));
                }

                this.OnPropertyChanged(nameof(this.IsWwt));
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
                    this.isNnr = false;

                    this.OnPropertyChanged(nameof(this.IsWt));
                    this.OnPropertyChanged(nameof(this.IsWwt));
                    this.OnPropertyChanged(nameof(this.IsNt));
                    this.OnPropertyChanged(nameof(this.IsNnr));
                }

                this.OnPropertyChanged(nameof(this.IsRspb));
                this.ResetLocationsCollection();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to just show NNR locations.
        /// </summary>
        public bool IsNnr
        {
            get => this.isNnr;
            set
            {
                if (this.isNnr == value)
                {
                    return;
                }

                this.isNnr = value;

                if (this.isNnr == true)
                {
                    this.isWt = false;
                    this.isWwt = false;
                    this.isNt = false;
                    this.isRspb = false;

                    this.OnPropertyChanged(nameof(this.IsWt));
                    this.OnPropertyChanged(nameof(this.IsWwt));
                    this.OnPropertyChanged(nameof(this.IsNt));
                    this.OnPropertyChanged(nameof(this.IsRspb));
                }

                this.OnPropertyChanged(nameof(this.IsNnr));
                this.ResetLocationsCollection();
            }
        }

        /// <summary>
        /// Gets the summary for the selected location.
        /// </summary>
        public ILocSummaryViewModel Summary { get; }

        /// <summary>
        /// Gets a collection of years assocated with the currently selected location.
        /// </summary>
        public ObservableCollection<string> Years => this.years;

        /// <summary>
        /// Gets or sets the index of the currently selected year.
        /// </summary>
        public int YearsIndex
        {
            get => this.selectedYearsIndex;
            set
            {
                if (this.selectedYearsIndex == value)
                {
                    return;
                }

                this.selectedYearsIndex = value;
                this.OnPropertyChanged(nameof(this.YearsIndex));
            }
        }

        /// <summary>
        /// Gets or sets a value indicated whether the <see cref="Years"/> control is enabled.
        /// </summary>
        /// <remarks>
        /// It will be enabled if there are multiple years available to choose.
        /// </remarks>
        public bool IsYearEnabled 
        {
            get => this.isYearEnabled;
            set
            {
                if (this.isYearEnabled == value)
                {
                    return;
                }

                this.isYearEnabled = value;
                this.OnPropertyChanged(nameof(this.IsYearEnabled));
            }
        }

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
                else if (this.CheckFilter(
                    this.isNnr,
                    "NNR",
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

            this.OnPropertyChanged(nameof(this.Locations));
            this.OnPropertyChanged(nameof(this.LocationIndex));
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