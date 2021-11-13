using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asland.ViewModels.Body.Reports
{
    using Asland.Interfaces.ViewModels.Body.Reports;
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
        }
    }
}
