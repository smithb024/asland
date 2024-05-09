namespace Asland.ViewModels.Body.Analysis.Location
{
    using Asland.Interfaces;
    using Asland.Interfaces.Factories;
    using Asland.Interfaces.ViewModels.Body.Analysis.Common;
    using Asland.Interfaces.ViewModels.Body.Analysis.Location;
    using Asland.Interfaces.ViewModels.Body.Reports;
    using Asland.Model.IO;
    using Asland.ViewModels.Body.Analysis.Common;
    using Asland.ViewModels.Body.Reports;
    using NynaeveLib.Logger;
    using NynaeveLib.ViewModel;
    using System.Collections.ObjectModel;
    using System.Threading;

    /// <summary>
    /// View model which supports the summary view on the location analysis.
    /// </summary>
    public class LocSummaryViewModel : ViewModelBase, ILocSummaryViewModel
    {
        /// <summary>
        /// The location search factory.
        /// </summary>
        private ILocationSearchFactory locationSearchFactory;

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
            IPathManager pathManager)
        {
            this.locationSearchFactory = search;
            this.name = string.Empty;
            this.count = 0;
            this.Dates = new ObservableCollection<string>();

            IBeastieAnalysisIconViewModel beastie1 =
                new BeastieAnalysisIconViewModel(
                    pathManager,
                    "Beastie1",
                    "BeastieI1",
                    "",
                    Asland.Common.Enums.Presence.Breeding);
            IBeastieAnalysisIconViewModel beastie2 =
                new BeastieAnalysisIconViewModel(
                    pathManager,
                    "Beastie2",
                    "BeastieI2",
                    "",
                    Asland.Common.Enums.Presence.Hibernates);
            IBeastieAnalysisIconViewModel beastie3 =
                new BeastieAnalysisIconViewModel(
                    pathManager,
                    "Beastie3",
                    "BeastieI3",
                    "",
                    Asland.Common.Enums.Presence.NonBreeding);

            beastie2.AssessBeastie();
            beastie2.AssessBeastie();
            beastie2.CountBeastie();
            beastie2.AssessBeastie();
            beastie2.CountBeastie();
            beastie3.AssessBeastie();
            beastie3.CountBeastie();

            this.Beasties =
                new ObservableCollection<IBeastieAnalysisIconViewModel>
                {
                    beastie1,
                    beastie2,
                    beastie3
                };
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
        /// </summary>
        /// <param name="name">The name of the new location</param>
        public void SetNewLocation(string name)
        {
            this.Name = name;
            this.Count = 0;
            this.Dates.Clear();
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
        }
    }
}