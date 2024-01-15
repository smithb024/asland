namespace Asland.ViewModels.Body.Analysis
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
            }
        }
    }
}