namespace Asland.ViewModels.Body.Analysis.Beasties
{
    using Asland.Common.Enums;
    using Asland.Interfaces;
    using Asland.Interfaces.Factories;
    using Asland.Interfaces.ViewModels.Body.Analysis.Beasties;
    using Asland.Interfaces.ViewModels.Body.Analysis.Common;
    using Asland.Interfaces.ViewModels.Body.Common;
    using Asland.Model.IO;
    using Asland.ViewModels.Body.Analysis.Common;
    using Asland.ViewModels.Body.Common;
    using NynaeveLib.ViewModel;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    /// <summary>
    /// View model which supports the summary view on the beastie analysis.
    /// </summary>
    public class BeastieSummaryViewModel : ViewModelBase, IBeastieSummaryViewModel
    {
        /// <summary>
        /// The text to display for spring.
        /// </summary>
        private const string Spring = "Spring";

        /// <summary>
        /// The text to display for summer.
        /// </summary>
        private const string Summer = "Summer";

        /// <summary>
        /// The text to display for autumn.
        /// </summary>
        private const string Autumn = "Autumn";

        /// <summary>
        /// The text to display for winter.
        /// </summary>
        private const string Winter = "Winter";

        /// <summary>
        /// The instance of the search factory.
        /// </summary>
        private readonly IBeastieSearchFactory beastieSearchFactory;

        /// <summary>
        /// The instance of the path manager.
        /// </summary>
        private readonly IPathManager pathManager;

        /// <summary>
        /// The instance of the logger;
        /// </summary>
        private readonly IAsLogger logger;

        /// <summary>
        /// The name of the current beastie.
        /// </summary>
        private string name;

        /// <summary>
        /// The total number of time the current beastie has been counted.
        /// </summary>
        private int total;

        /// <summary>
        /// Dictionary which is used count the number of times each location is visited.
        /// </summary>
        private Dictionary<string, int> locationsDictionary;

        /// <summary>
        /// Initialises a new instance of the <see cref="BeastieSummaryViewModel"/> class.
        /// </summary>
        /// <param name="pathManager">The instance of the path manager.</param>
        /// <param name="beastieSearchFactory">The instance of the search factory</param>
        /// <param name="logger">the instance of the logger</param>
        public BeastieSummaryViewModel(
            IPathManager pathManager,
            IBeastieSearchFactory beastieSearchFactory,
            IAsLogger logger) 
        {
            this.beastieSearchFactory = beastieSearchFactory;
            this.pathManager = pathManager;
            this.logger = logger;

            this.name = string.Empty;
            this.total = 0;
            this.BeastieIcon =
                new BeastieIconBaseViewModel(
                    pathManager,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    Presence.Passing);
            this.Years = new ObservableCollection<IStringCounterViewModel>();
            this.Intensities = new ObservableCollection<IEnumCounterViewModel<ObservationIntensity>>();
            this.Habitats = new ObservableCollection<IEnumCounterViewModel<ObservationHabitat>>();
            this.Locations = new ObservableCollection<ILocationAnalysisIconViewModel>();

            IStringCounterViewModel spring = new StringCounterViewModel(Spring, 0);
            IStringCounterViewModel summer = new StringCounterViewModel(Summer, 0);
            IStringCounterViewModel autumn = new StringCounterViewModel(Autumn, 0);
            IStringCounterViewModel winter = new StringCounterViewModel(Winter, 0);
            this.MeteorologicalSeasons =
                new ObservableCollection<IStringCounterViewModel>
                {
                    spring,
                    summer,
                    autumn,
                    winter
                };

            this.locationsDictionary = new Dictionary<string, int>();
        }

        /// <summary>
        /// Gets the name of the current beastie.
        /// </summary>
        public string Name
        {
            get => this.name;
            private set
            {
                if (this.name == value)
                {
                    return;
                }

                this.name = value;
                this.OnPropertyChanged(nameof(this.Name));
            }
        }

        /// <summary>
        /// Gets the total number of times current beastie has been counted.
        /// </summary>
        public int Total
        {
            get => this.total;
            private set
            {
                if (this.total == value)
                {
                    return;
                }

                this.total = value;
                this.OnPropertyChanged(nameof(this.Total));
            }
        }

        /// <summary>
        /// Gets the beastie icon.
        /// </summary>
        public IBeastieIconBaseViewModel BeastieIcon { get; private set; }

        /// <summary>
        /// Gets the years present in the analysis.
        /// </summary>
        public ObservableCollection<IStringCounterViewModel> Years { get; private set; }

        /// <summary>
        /// Gets the meteorological seasons present in the analysis.
        /// </summary>
        public ObservableCollection<IStringCounterViewModel> MeteorologicalSeasons { get; private set; }

        /// <summary>
        /// Gets the intensities present in the analysis.
        /// </summary>
        public ObservableCollection<IEnumCounterViewModel<ObservationIntensity>> Intensities { get; private set; }

        /// <summary>
        /// Gets the habitats present in the analysis.
        /// </summary>
        public ObservableCollection<IEnumCounterViewModel<ObservationHabitat>> Habitats { get; private set; }

        /// <summary>
        /// Gets all the locations present in the analysis.
        /// </summary>
        public ObservableCollection<ILocationAnalysisIconViewModel> Locations { get; private set; }

        /// <summary>
        /// Sets a new beastie for which to display a new set of summary data.
        /// </summary>
        /// <param name="name">The name of the new beastie</param>
        public void SetNewBeastie(string name)
        {
            this.Name = name;
            this.Clear();
            this.beastieSearchFactory.Find(
                this.ActionUpdate,
                this.ActionUpdate,
                this.Complete,
                this.Name);

            Model.IO.Data.Beastie beastie =
                this.beastieSearchFactory.Find(
                    this.Name);
            this.BeastieIcon =
                new BeastieIconBaseViewModel(
                    this.pathManager,
                    beastie.Name,
                    beastie.DisplayName,
                    beastie.LatinName,
                    beastie.Image,
                    beastie.Presence);
            this.OnPropertyChanged(nameof(this.BeastieIcon));
        }

        /// <summary>
        /// Receive the contents of the next valid file.
        /// </summary>
        /// <param name="observation">
        /// The raw observations to be added to the view.
        /// </param>
        private void ActionUpdate(RawObservationsString observation)
        {
            // Count
            ++this.Total;

            // Handle years
            string year =
                observation.Date.Substring(
                    Math.Max(
                        0,
                        observation.Date.Length - 4));

            IStringCounterViewModel yearViewModel = this.FindYear(year);

            if (yearViewModel == null)
            {
                yearViewModel =
                    new StringCounterViewModel(
                        year);
                this.Years.Add(yearViewModel);

                // Sort the years icons.
                List<IStringCounterViewModel> yearSortable =
                    new List<IStringCounterViewModel>(
                        this.Years);
                yearSortable = yearSortable.OrderBy(a => a.Name).ToList();

                for (int i = 0; i < yearSortable.Count; i++)
                {
                    this.Years.Move(this.Years.IndexOf(yearSortable[i]), i);
                }

                this.OnPropertyChanged(nameof(this.Years));
            }
            else 
            {
                yearViewModel.CountOne();
            }

            // Handle meteorological seasons
            string month;

            try
            {
                month = observation.Date.Substring(3, 2);
            }
            catch (Exception ex)
            {
                this.logger.WriteLine($"Failed to read month from a date: EX: {ex}");
                month = string.Empty;
            }

            string meteorologicalSeason =
                this.DetermineSeason(
                    month);

            IStringCounterViewModel seasonViewModel = 
                this.FindSeason(
                    meteorologicalSeason);

            if (seasonViewModel == null)
            {
               // fault
            }
            else
            {
                seasonViewModel.CountOne();
            }

            // Handle Intensities
            bool intensitySuccess =
                Enum.TryParse(
                    observation.Intensity,
                    out ObservationIntensity intensity);

            if (intensitySuccess)
            {
                IEnumCounterViewModel<ObservationIntensity> intensityViewModel = this.Find(intensity);

                if (intensityViewModel == null)
                {
                    intensityViewModel =
                        new EnumCounterViewModel<ObservationIntensity>(
                            intensity);
                    this.Intensities.Add(intensityViewModel);

                    // Sort the intensity icons.
                    List<IEnumCounterViewModel<ObservationIntensity>> intensitySortable =
                        new List<IEnumCounterViewModel<ObservationIntensity>>(
                            this.Intensities);
                    intensitySortable = intensitySortable.OrderBy(a => a.Name).ToList();

                    for (int i = 0; i < intensitySortable.Count; i++)
                    {
                        this.Intensities.Move(this.Intensities.IndexOf(intensitySortable[i]), i);
                    }

                    this.OnPropertyChanged(nameof(this.Intensities));
                }
                else
                {
                    intensityViewModel.CountOne();
                }
            }

            // Handle Habitats
            foreach (string name in observation.Habitats.Habitat)
            {
                ObservationHabitat habitat;
                bool habitatSuccess = Enum.TryParse(name, out habitat);

                if (habitatSuccess)
                {
                    IEnumCounterViewModel<ObservationHabitat> habitatViewModel = this.Find(habitat);

                    if (habitatViewModel == null)
                    {
                        habitatViewModel =
                            new EnumCounterViewModel<ObservationHabitat>(
                                habitat);
                        this.Habitats.Add(habitatViewModel);

                        // Sort the habitats icons.
                        List<IEnumCounterViewModel<ObservationHabitat>> habitatSortable =
                            new List<IEnumCounterViewModel<ObservationHabitat>>(
                                this.Habitats);
                        habitatSortable = habitatSortable.OrderBy(a => a.Name).ToList();

                        for (int i = 0; i < habitatSortable.Count; i++)
                        {
                            this.Habitats.Move(this.Habitats.IndexOf(habitatSortable[i]), i);
                        }

                        this.OnPropertyChanged(nameof(this.Habitats));
                    }
                    else
                    {
                        habitatViewModel.CountOne();
                    }
                }
            }

            // Handle locations.
            ILocationAnalysisIconViewModel icon = this.Find(observation.Location);

            if (icon != null)
            {
                icon.CountLocation();
            }
            else
            {
                this.CreateNewLocation(observation.Location);
            }

            // Sort the location icons by name.
            List<ILocationAnalysisIconViewModel> sortableList = new List<ILocationAnalysisIconViewModel>(this.Locations);
            sortableList = sortableList.OrderBy(a => a.Name).ToList();

            for (int i = 0; i < sortableList.Count; i++)
            {
                this.Locations.Move(this.Locations.IndexOf(sortableList[i]), i);
            }

            this.OnPropertyChanged(nameof(this.Locations));
        }

        /// <summary>
        /// Receive the location from the next open file. Count it.
        /// </summary>
        /// <remarks>
        /// Rather than going back through all the files later, the location of each one is passed
        /// directly into this view model so that we can count how many times each location was 
        /// visited. This allows us to see how often the beastie was seen at each individual 
        /// location. 
        /// </remarks>
        /// <param name="location">The location to be counted.</param>
        private void ActionUpdate(string location)
        {
            if (this.locationsDictionary.ContainsKey(location)) 
            { 
                ++this.locationsDictionary[location];
            }
            else
            {
                this.locationsDictionary.Add(location, 1);
            }
        }

        /// <summary>
        /// The update has finished, set the location totals.
        /// </summary>
        private void Complete()
        {
            foreach (ILocationAnalysisIconViewModel location in this.Locations)
            {
                location.SetTotal(this.locationsDictionary[location.Name]);
            }
        }

        /// <summary>
        /// Find the view model for the year called <paramref name="year"/>.
        /// </summary>
        /// <param name="year">The year to find</param>
        /// <returns>
        /// The found year. Null if one can't be found.
        /// </returns>
        private IStringCounterViewModel FindYear(string year)
        {
            foreach (IStringCounterViewModel y in this.Years)
            {
                if (year == y.Name)
                {
                    return y;
                }
            }

            return null;
        }

        /// <summary>
        /// Find the view model for the meteorological season called <paramref name="season"/>.
        /// </summary>
        /// <param name="season">The meteorological season to find</param>
        /// <returns>
        /// The found meteorological season. Null if one can't be found.
        /// </returns>
        private IStringCounterViewModel FindSeason(string season)
        {
            foreach (IStringCounterViewModel y in this.MeteorologicalSeasons)
            {
                if (season == y.Name)
                {
                    return y;
                }
            }

            return null;
        }

        /// <summary>
        /// Find the view model for the intensity called <paramref name="observation"/>.
        /// </summary>
        /// <param name="name">The intensity to find</param>
        /// <returns>
        /// The found intensity. Null if one can't be found.
        /// </returns>
        private IEnumCounterViewModel<ObservationIntensity> Find(ObservationIntensity observation)
        {
            foreach (IEnumCounterViewModel<ObservationIntensity> intensity in this.Intensities)
            {
                if (observation == intensity.Name)
                {
                    return intensity;
                }
            }

            return null;
        }

        /// <summary>
        /// Find the view model for the habitat called <paramref name="observation"/>.
        /// </summary>
        /// <param name="name">The habitat to find</param>
        /// <returns>
        /// The found habitat. Null if one can't be found.
        /// </returns>
        private IEnumCounterViewModel<ObservationHabitat> Find(ObservationHabitat observation)
        {
            foreach (IEnumCounterViewModel<ObservationHabitat> habitat in this.Habitats)
            {
                if (observation == habitat.Name)
                {
                    return habitat;
                }
            }

            return null;
        }

        /// <summary>
        /// Determine which meteorological season, the record is from.
        /// </summary>
        /// <param name="month">the month to check.</param>
        /// <returns>The meteorological season</returns>
        private string DetermineSeason(string month)
        {
            switch (month)
            {
                case "03":
                case "04":
                case "05":
                    return Spring;

                case "06":
                case "07":
                case "08":
                    return Summer;

                case "09":
                case "10":
                case "11":
                    return Autumn;

                case "12":
                case "01":
                case "02":
                    return Winter;

                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Create a new location icon and bring the assessment count up to be consistent with the
        /// existing icons.
        /// </summary>
        /// <param name="name">The name of the location</param>
        private void CreateNewLocation(string name)
        {
            ILocationAnalysisIconViewModel locationIcon =
                new LocationAnalysisIconViewModel(
                    name);

            locationIcon.CountLocation();
            this.Locations.Add(locationIcon);
        }

        /// <summary>
        /// Find the view model for the beastie called <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the beastie to find</param>
        /// <returns>
        /// The found beastie. Null if one can't be found.
        /// </returns>
        private ILocationAnalysisIconViewModel Find(string name)
        {
            foreach (ILocationAnalysisIconViewModel locations in this.Locations)
            {
                if (locations.Name.Equals(name))
                {
                    return locations;
                }
            }

            return null;
        }

        /// <summary>
        /// Clear all collections.
        /// </summary>
        private void Clear()
        {
            this.Total = 0;
            this.Years.Clear();
            this.MeteorologicalSeasons.Clear();
            this.Intensities.Clear();
            this.Habitats.Clear();
            this.Locations.Clear();

            this.locationsDictionary.Clear();

            IStringCounterViewModel spring = new StringCounterViewModel(Spring, 0);
            IStringCounterViewModel summer = new StringCounterViewModel(Summer, 0);
            IStringCounterViewModel autumn = new StringCounterViewModel(Autumn, 0);
            IStringCounterViewModel winter = new StringCounterViewModel(Winter, 0);
            this.MeteorologicalSeasons.Add(spring);
            this.MeteorologicalSeasons.Add(summer);
            this.MeteorologicalSeasons.Add(autumn);
            this.MeteorologicalSeasons.Add(winter);
        }
    }
}
