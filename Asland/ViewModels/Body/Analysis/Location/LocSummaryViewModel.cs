namespace Asland.ViewModels.Body.Analysis.Location
{
    using Asland.Common.Enums;
    using Asland.Interfaces;
    using Asland.Interfaces.Factories;
    using Asland.Interfaces.ViewModels.Body.Analysis.Common;
    using Asland.Interfaces.ViewModels.Body.Analysis.Location;
    using Asland.Model.IO;
    using Asland.Model.IO.Data;
    using Asland.ViewModels.Body.Analysis.Common;
    using NynaeveLib.ViewModel;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    /// <summary>
    /// View model which supports the summary view on the location analysis.
    /// </summary>
    public class LocSummaryViewModel : ViewModelBase, ILocSummaryViewModel
    {
        /// <summary>
        /// The instance of the <see cref="IPathManager"/>.
        /// </summary>
        private readonly IPathManager pathManager;

        /// <summary>
        /// The location search factory.
        /// </summary>
        private readonly ILocationSearchFactory locationSearchFactory;

        /// <summary>
        /// Function used to retrieve a specific beastie from the model.
        /// </summary>
        private readonly Func<string, Beastie> getBeastie;

        /// <summary>
        /// The name of the current location.
        /// </summary>
        private string name;

        /// <summary>
        /// The number of times the location has been visited.
        /// </summary>
        private int count;

        /// <summary>
        /// Initialises a new instance of the <see cref="LocSummaryViewModel"/> class.
        /// </summary>
        /// <param name="search">the search factory</param>
        /// <param name="pathManager">the path manager</param>
        public LocSummaryViewModel(
            ILocationSearchFactory search,
            IPathManager pathManager,
            Func<string, Beastie> getBeastie)
        {
            this.locationSearchFactory = search;
            this.pathManager = pathManager;
            this.getBeastie = getBeastie;
            this.name = string.Empty;
            this.count = 0;
            this.Dates = new ObservableCollection<string>();

            this.Beasties = new ObservableCollection<IBeastieAnalysisIconViewModel>();
            this.Intensities = new ObservableCollection<IEnumCounterViewModel<ObservationIntensity>>();
            this.Habitats = new ObservableCollection<IEnumCounterViewModel<ObservationHabitat>>();
        }

        /// <summary>
        /// Gets the name of the current location.
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
        /// Gets the number of times the location has been visited.
        /// </summary>
        public int Count
        {
            get => this.count;
            private set
            {
                if (this.count == value)
                {
                    return;
                }

                this.count = value;
                this.OnPropertyChanged(nameof(this.Count));
            }
        }

        /// <summary>
        /// Gets the beasties present in the analysis.
        /// </summary>
        public ObservableCollection<IBeastieAnalysisIconViewModel> Beasties { get; private set; }

        /// <summary>
        /// Gets the intensities present in the analysis.
        /// </summary>
        public ObservableCollection<IEnumCounterViewModel<ObservationIntensity>> Intensities { get; private set; }

        /// <summary>
        /// Gets the habitats present in the analysis.
        /// </summary>
        public ObservableCollection<IEnumCounterViewModel<ObservationHabitat>> Habitats { get; private set; }

        /// <summary>
        /// Gets the dates of visits to the location.
        /// </summary>
        public ObservableCollection<string> Dates { get; }

        /// <summary>
        /// Sets a new location for which to display a new set of summary data.
        /// Request that the location search factory goes through and returns the contents of all
        /// relevant locations files. These are returned one at a time via the 
        /// <see cref="ActionUpdate(RawObservationsString)"/> method.
        /// </summary>
        /// <param name="name">The name of the new location</param>
        public void SetNewLocation(string name)
        {
            this.Name = name;
            this.Count = 0;
            this.Dates.Clear();
            this.Beasties.Clear();
            this.Intensities.Clear();
            this.Habitats.Clear();
            this.locationSearchFactory.Find(
                this.ActionUpdate,
                this.Name);
        }

        /// <summary>
        /// Receive the contents of the next valid file.
        /// </summary>
        /// <param name="observation">
        /// The raw observations to be added to the view.
        /// </param>
        private void ActionUpdate(RawObservationsString observation)
        {
            ++this.Count;
            this.Dates.Add(observation.Date);

            // Handle beasties.
            this.AssessAllBeasties();

            foreach (string name in observation.Species.Kind)
            {
                IBeastieAnalysisIconViewModel icon = this.Find(name);

                if (icon != null)
                {
                    icon.CountBeastie();
                    continue;
                }

                this.CreateNewBeastie(name);
            }

            // Sort the beasties icons by percentage.
            List<IBeastieAnalysisIconViewModel> sortableList = new List<IBeastieAnalysisIconViewModel>(this.Beasties);
            sortableList = sortableList.OrderByDescending(a => a.Percentage).ToList();

            for (int i = 0; i < sortableList.Count; i++)
            {
                this.Beasties.Move(this.Beasties.IndexOf(sortableList[i]), i);
            }

            this.OnPropertyChanged(nameof (this.Beasties));

            // Handle Intensities
            ObservationIntensity intensity;
            bool intensitySuccess = Enum.TryParse(observation.Intensity, out intensity);

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
        }

        /// <summary>
        /// Call assess on all of the current set of beasties.
        /// </summary>
        private void AssessAllBeasties()
        {
            foreach (IBeastieAnalysisIconViewModel icon in this.Beasties)
            {
                icon.AssessBeastie();
            }
        }

        /// <summary>
        /// Create a new beastie icon and bring the assessment count up to be consistent with the
        /// existing icons.
        /// </summary>
        /// <param name="name">The name of the beastie</param>
        private void CreateNewBeastie(string name)
        {
            Beastie beastie = this.getBeastie(name);
            IBeastieAnalysisIconViewModel beastieIcon =
                new BeastieAnalysisIconViewModel(
                    this.pathManager,
                    beastie.Name,
                    beastie.DisplayName,
                    beastie.LatinName,
                    beastie.Image,
                    beastie.Presence);

            for (int i = 0; i < this.Count; ++i)
            {
                beastieIcon.AssessBeastie();
            }

            beastieIcon.CountBeastie();
            this.Beasties.Add(beastieIcon);
        }

        /// <summary>
        /// Find the view model for the beastie called <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the beastie to find</param>
        /// <returns>
        /// The found beastie. Null if one can't be found.
        /// </returns>
        private IBeastieAnalysisIconViewModel Find(string name)
        {
            foreach (IBeastieAnalysisIconViewModel beastie in this.Beasties)
            {
                if (beastie.Name.Equals(name))
                {
                    return beastie;
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
    }
}