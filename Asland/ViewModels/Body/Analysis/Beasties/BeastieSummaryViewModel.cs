namespace Asland.ViewModels.Body.Analysis.Beasties
{
    using Asland.Common.Enums;
    using Asland.Interfaces.Factories;
    using Asland.Interfaces.ViewModels.Body.Analysis;
    using Asland.Interfaces.ViewModels.Body.Analysis.Beasties;
    using Asland.Interfaces.ViewModels.Body.Analysis.Common;
    using Asland.Model.IO;
    using Asland.ViewModels.Body.Analysis.Common;
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
        /// The instance of the search factory.
        /// </summary>
        private readonly IBeastieSearchFactory beastieSearchFactory;

        /// <summary>
        /// The name of the current beastie.
        /// </summary>
        private string name;

        /// <summary>
        /// Initialises a new instance of the <see cref="BeastieSummaryViewModel"/> class.
        /// </summary>
        /// <param name="beastieSearchFactory">The instance of the search factory</param>
        public BeastieSummaryViewModel(
            IBeastieSearchFactory beastieSearchFactory) 
        {
            this.beastieSearchFactory = beastieSearchFactory;

            this.name = string.Empty;
            this.Years = new ObservableCollection<IStringCounterViewModel>();
            this.Intensities = new ObservableCollection<IEnumCounterViewModel<ObservationIntensity>>();
            this.Habitats = new ObservableCollection<IEnumCounterViewModel<ObservationHabitat>>();
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
        /// Gets the years present in the analysis.
        /// </summary>
        public ObservableCollection<IStringCounterViewModel> Years { get; private set; }

        /// <summary>
        /// Gets the intensities present in the analysis.
        /// </summary>
        public ObservableCollection<IEnumCounterViewModel<ObservationIntensity>> Intensities { get; private set; }

        /// <summary>
        /// Gets the habitats present in the analysis.
        /// </summary>
        public ObservableCollection<IEnumCounterViewModel<ObservationHabitat>> Habitats { get; private set; }

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
        /// Clear all collections.
        /// </summary>
        private void Clear()
        {
            this.Years.Clear();
            this.Intensities.Clear();
            this.Habitats.Clear();
        }
    }
}
