namespace Asland.ViewModels.Body.Reports
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Asland.Common.Messages;
    using Asland.Factories.IO;
    using Asland.Interfaces;
    using Asland.Interfaces.Common.Utils;
    using Asland.Interfaces.ViewModels.Body.Reports;
    using Asland.Interfaces.ViewModels.Common;
    using Asland.Model.IO;
    using Asland.ViewModels.Common;
    using GalaSoft.MvvmLight.Messaging;
    using NynaeveLib.ViewModel;

    /// <summary>
    /// The calendar view model for the reports tab.
    /// </summary>
    public class CalendarViewModel : ViewModelBase, ICalendarViewModel
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private readonly IAsLogger logger;

        /// <summary>
        /// The year searcher.
        /// </summary>
        private readonly IYearSearcher yearSearcher;

        /// <summary>
        /// Command used to open a new event.
        /// </summary>
        private readonly Action<string> openEventCommand;

        /// <summary>
        /// The index of the currently selected year.
        /// </summary>
        private int yearsIndex;

        /// <summary>
        /// The last selected month.
        /// </summary>
        private string currentMonth;

        /// <summary>
        /// Lookup to get the name to month integer.
        /// </summary>
        private Dictionary<string, int> monthDictionary = new Dictionary<string, int>();

        /// <summary>
        /// Initialises a new instance of the <see cref="CalendarViewModel"/> class.
        /// </summary>
        /// <param name="logger">the logger</param>
        /// <param name="yearSearcher">the year searcher</param>
        /// <param name="openEventCommand">
        /// Command used to open an event.
        /// </param>
        public CalendarViewModel(
            IAsLogger logger,
            IYearSearcher yearSearcher,
            Action<string> openEventCommand)
        {
            this.logger = logger;
            this.yearSearcher = yearSearcher;
            this.openEventCommand = openEventCommand;
            this.Years = this.yearSearcher.FindRawYears();
            this.MonthSelector = new ObservableCollection<IPageSelector>();
            this.Events = new ObservableCollection<ICalendarItem>();

            this.monthDictionary =
                new Dictionary<string, int>()
                {
                    { "Jan", 1 },
                    { "Feb", 2 },
                    { "Mar", 3 },
                    { "Apr", 4 },
                    { "May", 5 },
                    { "Jun", 6 },
                    { "Jul", 7 },
                    { "Aug", 8 },
                    { "Sept", 9 },
                    { "Oct", 10 },
                    { "Nov", 11 },
                    { "Dec", 12 },
                };

            foreach (KeyValuePair<string, int> month in this.monthDictionary)
            {
                IPageSelector selector =
                    new PageSelector(
                        month.Key,
                        this.NewPage);

                this.MonthSelector.Add(selector);
            }

            this.yearsIndex = this.Years.Count - 1;

            string monthName =
                this.monthDictionary.FirstOrDefault(x => x.Value == DateTime.Now.Month).Key;
            this.NewPage(monthName);
        }

        /// <summary>
        /// Gets the years which the data covers.
        /// </summary>
        public ObservableCollection<string> Years { get; }

        /// <summary>
        /// Gets or sets the index for <see cref="Years"/> collection.
        /// </summary>
        public int YearsIndex
        {
            get
            {
                return this.yearsIndex;
            }

            set
            {
                if (this.yearsIndex != value)
                {
                    this.yearsIndex = value;
                    this.RaisePropertyChangedEvent(nameof(this.YearsIndex));

                    this.NewPage(this.currentMonth);
                }
            }
        }

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
            this.SetMonth(newPageName);

            List<string> eventPaths = this.FindEventPaths();

            this.Events.Clear();

            foreach (string eventPath in eventPaths)
            {
                try
                {
                    RawObservations observations =
                        XmlFileIo.ReadXml<RawObservations>(
                            eventPath);

                    ICalendarItem calendarItem =
                        new CalendarItem(
                            observations.Date.Substring(0, 2),
                            observations.Location,
                            observations.Intensity,
                            eventPath,
                            this.openEventCommand);

                    this.Events.Add(calendarItem);
                }
                catch (Exception ex)
                {
                    string errorDescription = $"Error loading {eventPath}";
                    AppStatusMessage message =
                        new AppStatusMessage(
                            errorDescription);
                    Messenger.Default.Send(message);

                    this.logger.WriteLine(
                        $"Calendar view model : {errorDescription}: {ex}");
                }
            }

            this.RaisePropertyChangedEvent(nameof(this.Events));
        }

        /// <summary>
        /// Inform each of the components in the month selector collection of the name of the 
        /// currently selected month.
        /// </summary>
        /// <param name="pageName">page name</param>
        private void SetMonth(string monthName)
        {
            this.currentMonth = monthName;
            foreach (IPageSelector monthSelector in this.MonthSelector)
            {
                monthSelector.SelectedButton(monthName);
            }
        }

        /// <summary>
        /// Find and return the paths to all events in the currently selected month.
        /// </summary>
        /// <returns>collection of paths</returns>
        private List<string> FindEventPaths()
        {
            List<string> paths =
                this.yearSearcher.FindAllRawObservationsInAMonth(
                    this.Years[this.YearsIndex],
                    this.monthDictionary[this.currentMonth]);

            return paths;
        }
    }
}