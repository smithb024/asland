namespace Asland.ViewModels.Body
{
    using System.Collections.Generic;
    using Asland.Interfaces;
    using Asland.Interfaces.Common.Utils;
    using Asland.Interfaces.Model.IO.Data;
    using Asland.Interfaces.ViewModels.Body;
    using Asland.Interfaces.ViewModels.Body.Reports;
    using Asland.Interfaces.ViewModels.Common;
    using Asland.ViewModels.Body.Reports;
    using Asland.ViewModels.Common;
    using NynaeveLib.Utils;
    using NynaeveLib.ViewModel;

    /// <summary>
    /// View model which suports the data entry view.
    /// This manages all aspects of the data entry process including the different sub views.
    /// </summary>
    public class ReportsViewModel : ViewModelBase, IReportsViewModel
    {
        /// <summary>
        /// String used for the calendar button.
        /// </summary>
        private const string CalendarSelector = "Calendar";

        /// <summary>
        /// String used for the calendar button.
        /// </summary>
        private const string EventSelector = "Event";

        /// <summary>
        /// View model for the calendar.
        /// </summary>
        private ICalendarViewModel calendarViewModel;

        /// <summary>
        /// View model for the event report.
        /// </summary>
        private IEventReportViewModel eventReportViewModel;

        /// <summary>
        /// Initialises a new instance of the <see cref="ReportsViewModel"/> class.
        /// </summary>
        /// <param name="pathManager">the path manager</param>
        /// <param name="yearSearcher">the year searcher</param>
        /// <param name="dataModel">
        /// The model object containing data set. 
        /// </param>
        /// <param name="logger">the logger</param>
        public ReportsViewModel(
            IPathManager pathManager,
            IYearSearcher yearSearcher,
            IDataManager dataModel,
            IAsLogger logger)
        {
            this.PageSelector = new List<IPageSelector>();
            this.calendarViewModel = 
                new CalendarViewModel(
                    logger,
                    yearSearcher,
                    this.OpenEvent);
            this.eventReportViewModel =
                new EventReportViewModel(
                    pathManager,
                    dataModel.FindBeastie);

            this.CurrentWorkspace = this.calendarViewModel;

            IPageSelector calendarSelector =
                new PageSelector(
                    ReportsViewModel.CalendarSelector,
                    this.NewPage);
            IPageSelector eventSelector =
                new PageSelector(
                    ReportsViewModel.EventSelector,
                    this.NewPage);

            this.PageSelector.Add(calendarSelector);
            this.PageSelector.Add(eventSelector);

            this.NewPage(ReportsViewModel.CalendarSelector);
        }

        /// <summary>
        /// Gets the view model for the workspace which is displayed.
        /// </summary>
        public object CurrentWorkspace { get; private set; }

        /// <summary>
        /// Gets a selection of commands which are used to choose a page to display.
        /// </summary>
        public List<IPageSelector> PageSelector { get; private set; }

        /// <summary>
        /// Display the event page and open a new event.
        /// </summary>
        /// <param name="eventPath">path to the event raw data</param>
        private void OpenEvent(string eventPath)
        {
            this.CurrentWorkspace = this.eventReportViewModel;

            this.eventReportViewModel.OpenEvent(eventPath);

            this.ResetSelectedPage(ReportsViewModel.EventSelector);

            this.OnPropertyChanged(nameof(this.CurrentWorkspace));
        }

        /// <summary>
        /// Select a new page for the view.
        /// </summary>
        /// <param name="newPageName">
        /// Name of the page to display.
        /// </param>
        private void NewPage(string newPageName)
        {
            if (StringCompare.SimpleCompare(newPageName, ReportsViewModel.CalendarSelector))
            {
                this.CurrentWorkspace = this.calendarViewModel;
            }
            else if (StringCompare.SimpleCompare(newPageName, ReportsViewModel.EventSelector))
            {
                this.CurrentWorkspace = this.eventReportViewModel;
            }

            this.ResetSelectedPage(newPageName);

            this.OnPropertyChanged(nameof(this.CurrentWorkspace));
        }

        /// <summary>
        /// Inform each of the components in the page selector collection of the name of the 
        /// currently selected page.
        /// </summary>
        /// <param name="pageName">page name</param>
        private void ResetSelectedPage(string pageName)
        {
            foreach(IPageSelector pageSelector in this.PageSelector)
            {
                pageSelector.SelectedButton(pageName);
            }
        }
    }
}