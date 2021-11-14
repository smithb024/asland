namespace Asland.ViewModels.Body.Reports
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Asland.Interfaces.ViewModels.Body.Reports;
    using Asland.Interfaces.ViewModels.Common;
    using Asland.ViewModels.Common;
    using NynaeveLib.ViewModel;

    /// <summary>
    /// The calendar view model for the reports tab.
    /// </summary>
    public class CalendarViewModel : ViewModelBase, ICalendarViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="CalendarViewModel"/> class.
        /// </summary>
        public CalendarViewModel()
        {
            this.Years = new ObservableCollection<string>();
            this.MonthSelector = new ObservableCollection<IPageSelector>();
            this.Events = new ObservableCollection<ICalendarItem>();

            List<string> months =
                new List<string>()
                {
                    "Jan",
                    "Feb",
                    "Mar",
                    "Apr",
                    "May",
                    "Jun",
                    "Jul",
                    "Aug",
                    "Sept",
                    "Oct",
                    "Nov",
                    "Dec",
                };

            foreach (string month in months)
            {
                IPageSelector selector =
                    new PageSelector(
                        month,
                        this.NewPage);

                this.MonthSelector.Add(selector);
            }
        }

        /// <summary>
        /// Gets the years which the data covers.
        /// </summary>
        public ObservableCollection<string> Years { get; }

        /// <summary>
        /// Gets or sets the index for <see cref="Years"/> collection.
        /// </summary>
        public int YearsIndex { get; set; }

        /// <summary>
        /// Gets a selection of commands which are used to choose a month to display.
        /// </summary>
        public ObservableCollection<IPageSelector> MonthSelector { get; }

        /// <summary>
        /// Gets the selection of events in the currently selected month.
        /// </summary>
        public ObservableCollection<ICalendarItem> Events { get; }

        /// <summary>
        /// Select a new page for the view.
        /// </summary>
        /// <param name="newPageName">
        /// Name of the page to display.
        /// </param>
        private void NewPage(string newPageName)
        {
            //if (StringCompare.SimpleCompare(newPageName, EventDetails))
            //{
            //    this.CurrentWorkspace = this.detailsViewModel;
            //}
            //else
            //{
            //    this.beastieEntryViewModel.Clear();

            //    List<string> beasties =
            //        this.dataEntryModel.GetBeastiesOnAPage(
            //            newPageName);

            //    foreach (string beastie in beasties)
            //    {
            //        bool isIncluded =
            //            this.observations.GetIncluded(
            //                beastie,
            //                this.detailsViewModel.IsSeen);

            //        Beastie modelBeastie = this.getBeastie(beastie);

            //        this.beastieEntryViewModel.Add(
            //            beastie,
            //            modelBeastie?.LatinName ?? string.Empty,
            //            modelBeastie?.Image ?? string.Empty,
            //            modelBeastie?.Presence ?? (Presence)(-1),
            //            isIncluded);
            //    }

            //    this.CurrentWorkspace = this.beastieEntryViewModel;
            //    this.beastieEntryViewModel.Refresh();
            //}

            //this.ResetSelectedPage(newPageName);

            //this.RaisePropertyChangedEvent(nameof(this.CurrentWorkspace));
        }
    }
}