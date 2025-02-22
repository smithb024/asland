namespace Asland.ViewModels.Body.Analysis.Year
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Asland.Common.Enums;
    using Asland.Interfaces;
    using Asland.Interfaces.Factories;
    using Asland.Interfaces.ViewModels.Body.Analysis.Common;
    using Asland.Interfaces.ViewModels.Body.Analysis.Year;
    using Asland.Model.IO;
    using Asland.Model.IO.Data;
    using Asland.ViewModels.Body.Analysis.Common;
    using NynaeveLib.ViewModel;

    /// <summary>
    /// View model which supports the summary view on the year analysis.
    /// </summary>
    public class YearSummaryViewModel: ViewModelBase, IYearSummaryViewModel
    {
        /// <summary>
        /// The instance of the <see cref="IPathManager"/>.
        /// </summary>
        private readonly IPathManager pathManager;

        /// <summary>
        /// The time search factory.
        /// </summary>
        private readonly ITimeSearchFactory timeSearchFactory;

        /// <summary>
        /// Function used to retrieve a specific beastie from the model.
        /// </summary>
        private readonly Func<string, Beastie> getBeastie;

        /// <summary>
        /// The number of events counted in the analysis.
        /// </summary>
        private int count;

        /// <summary>
        /// Initialises a new instance of the <see cref="YearSummaryViewModel"/> class.
        /// </summary>
        /// <param name="search">The search factory</param>
        /// <param name="pathManager">the path manager</param>
        /// <param name="getBeastie">Find a specific <see cref="Beastie"/>.</param>
        public YearSummaryViewModel(
            ITimeSearchFactory search,
            IPathManager pathManager,
            Func<string, Beastie> getBeastie) 
        {
            this.timeSearchFactory = search;
            this.pathManager = pathManager;
            this.getBeastie = getBeastie;

            this.count = 0;
            this.Beasties = new ObservableCollection<IBeastieAnalysisIconViewModel>();
            this.Locations = new ObservableCollection<IStringCounterViewModel>();
        }

        /// <summary>
        /// Gets the beasties present in the analysis.
        /// </summary>
        public ObservableCollection<IBeastieAnalysisIconViewModel> Beasties { get; private set; }

        /// <summary>
        /// Gets the locations present in the analysis.
        /// </summary>
        public ObservableCollection<IStringCounterViewModel> Locations { get; private set; }

        /// <summary>
        /// Gets the number events counted in the analysis.
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
        /// Sets a new year for which to display a new set of summary data.
        /// </summary>
        /// <param name="name">The name of the new year</param>
        public void SetNewYear(string name)
        {
            this.Count = 0;
            this.Beasties.Clear();
            this.timeSearchFactory.Find(
               this.ActionUpdate,
               name);
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

            this.OnPropertyChanged(nameof(this.Beasties));

            // Handle locations.
            IStringCounterViewModel locationViewModel = 
                this.FindLocation(
                    observation.Location);

            if (locationViewModel == null)
            {
                locationViewModel =
                    new StringCounterViewModel(
                        observation.Location);
                this.Locations.Add(locationViewModel);

                // Sort the habitats icons.
                List<IStringCounterViewModel> habitatSortable =
                    new List<IStringCounterViewModel>(
                        this.Locations);
                habitatSortable = habitatSortable.OrderBy(a => a.Name).ToList();

                for (int i = 0; i < habitatSortable.Count; i++)
                {
                    this.Locations.Move(this.Locations.IndexOf(habitatSortable[i]), i);
                }

                this.OnPropertyChanged(nameof(this.Locations));
            }
            else
            {
                locationViewModel.CountOne();
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
        /// Find the view model for the location called <paramref name="observation"/>.
        /// </summary>
        /// <param name="name">The location to find</param>
        /// <returns>
        /// The found location. Null if one can't be found.
        /// </returns>
        private IStringCounterViewModel FindLocation(string name)
        {
            foreach (IStringCounterViewModel location in this.Locations)
            {
                if (name == location.Name)
                {
                    return location;
                }
            }

            return null;
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
    }
}
