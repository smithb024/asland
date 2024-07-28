﻿namespace Asland.ViewModels.Body.Analysis.Location
{
    using Asland.Interfaces;
    using Asland.Interfaces.Factories;
    using Asland.Interfaces.ViewModels.Body.Analysis.Common;
    using Asland.Interfaces.ViewModels.Body.Analysis.Location;
    using Asland.Model.IO;
    using Asland.Model.IO.Data;
    using Asland.ViewModels.Body.Analysis.Common;
    using NynaeveLib.ViewModel;
    using System;
    using System.Collections.ObjectModel;

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

            //IBeastieAnalysisIconViewModel beastie1 =
            //    new BeastieAnalysisIconViewModel(
            //        pathManager,
            //        "Beastie1",
            //        "BeastieI1",
            //        "",
            //        Asland.Common.Enums.Presence.Breeding);
            //IBeastieAnalysisIconViewModel beastie2 =
            //    new BeastieAnalysisIconViewModel(
            //        pathManager,
            //        "Beastie2",
            //        "BeastieI2",
            //        "",
            //        Asland.Common.Enums.Presence.Hibernates);
            //IBeastieAnalysisIconViewModel beastie3 =
            //    new BeastieAnalysisIconViewModel(
            //        pathManager,
            //        "Beastie3",
            //        "BeastieI3",
            //        "",
            //        Asland.Common.Enums.Presence.NonBreeding);

            //beastie2.AssessBeastie();
            //beastie2.AssessBeastie();
            //beastie2.CountBeastie();
            //beastie2.AssessBeastie();
            //beastie2.CountBeastie();
            //beastie3.AssessBeastie();
            //beastie3.CountBeastie();

            //this.Beasties =
            //    new ObservableCollection<IBeastieAnalysisIconViewModel>
            //    {
            //        beastie1,
            //        beastie2,
            //        beastie3
            //    };

            this.Beasties = new ObservableCollection<IBeastieAnalysisIconViewModel>();
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
                this.RaisePropertyChangedEvent(nameof(this.Name));
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
                this.RaisePropertyChangedEvent(nameof(this.Count));
            }
        }

        /// <summary>
        /// Gets the beasties present in the analysis.
        /// </summary>
        public ObservableCollection<IBeastieAnalysisIconViewModel> Beasties { get; }

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
            this.AssessAllBeasties();

            foreach (string kind in observation.Species.Kind)
            {
                IBeastieAnalysisIconViewModel icon = this.Find(kind);

                if (icon != null)
                {
                    icon.CountBeastie();
                    continue;
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

        
        private void CreateNewBeastie()
        {
            IBeastieAnalysisIconViewModel beastie1 =
                new BeastieAnalysisIconViewModel(
                    this.pathManager,
                    ,
                    "BeastieI1",
                    "",
                    Asland.Common.Enums.Presence.Breeding);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private IBeastieAnalysisIconViewModel Find(string name)
        {
            foreach (IBeastieAnalysisIconViewModel beastie in this.Beasties)
            {
                if (beastie.CommonName.Equals(name))
                {
                    return beastie;
                }
            }

            return null;
        }
    }
}