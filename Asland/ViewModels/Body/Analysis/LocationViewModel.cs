﻿namespace Asland.ViewModels.Body.Analysis
{
    using Asland.Factories.IO;
    using Asland.Interfaces.ViewModels.Body.Analysis;
    using Asland.Model.IO;
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
        public LocationViewModel()
        {
            this.locations = new ObservableCollection<string>();

            string basePath = DataPath.RawDataPath;
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
        /// Reset the locations list using the filters if required.
        /// </summary>
        private void ResetLocationsCollection()
        {
            ObservableCollection<string> filteredLocations =
                new ObservableCollection<string>();

            foreach(string location in this.locations)
            {
                if (this.IsNt)
                {
                    if (location.StartsWith("NT"))
                    {
                        filteredLocations.Add(location);
                    }
                }
                else if (this.IsRspb)
                {
                    if (location.StartsWith("RSPB"))
                    {
                        filteredLocations.Add(location);
                    }
                }
                else if (this.IsWt)
                {
                    if (location.StartsWith("WT"))
                    {
                        filteredLocations.Add(location);
                    }
                }
                else if (this.IsWwt)
                {
                    if (location.StartsWith("WWT"))
                    {
                        filteredLocations.Add(location);
                    }
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
    }
}