namespace Asland.Interfaces.ViewModels.Body.Reports
{
    using System.Collections.ObjectModel;
    using Asland.Interfaces.ViewModels.Common;

    /// <summary>
    /// Interface which supports the calendar on the reports tab.
    /// </summary>
    public interface ICalendarViewModel
    {
        /// <summary>
        /// Gets the years which the data covers.
        /// </summary>
        ObservableCollection<string> Years { get; }

        /// <summary>
        /// Gets or sets the index for <see cref="Years"/> collection.
        /// </summary>
        int YearsIndex { get; set; }

        /// <summary>
        /// Gets a selection of commands which are used to choose a month to display.
        /// </summary>
        ObservableCollection<IPageSelector> MonthSelector { get; }

        /// <summary>
        /// Gets the selection of events in the currently selected month.
        /// </summary>
        ObservableCollection<ICalendarItem> Events { get; }
    }
}
