namespace Asland.ViewModels.Body
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Windows.Input;
    using Asland.Common.Enums;
    using Asland.Interfaces.Model.IO.DataEntry;
    using Asland.Interfaces.ViewModels.Body;
    using Asland.Interfaces.ViewModels.Body.Reports;
    using Asland.Interfaces.ViewModels.Common;
    using Asland.Model.IO.Data;
    using Asland.ViewModels.Body.Reports;
    using Asland.ViewModels.Common;
    using NynaeveLib.Commands;
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
        /// Initialises a new instance of the <see cref="DataEntryViewModel"/> class.
        /// </summary>
        /// <param name="model">
        ///  The associated model object.
        /// </param>
        /// <param name="getBeastie">
        /// The function used to return a specific beastie from the data model.
        /// </param>
        public ReportsViewModel()
        {
            this.PageSelector = new List<IPageSelector>();
            this.calendarViewModel = new CalendarViewModel();
            this.eventReportViewModel = new EventReportViewModel();

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

            this.RaisePropertyChangedEvent(nameof(this.CurrentWorkspace));
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