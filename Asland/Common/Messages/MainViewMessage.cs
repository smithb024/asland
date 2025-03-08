namespace Asland.Common.Messages
{
    using Asland.Common.Enums;

    /// <summary>
    /// Massage used to indiicate which view to display.
    /// </summary>
    public class MainViewMessage
    {
        /// <summary>
        /// Imitialisese s new instance of the <see cref="MainViewMessage"/> class.
        /// </summary>
        /// <param name="view">view to display</param>
        public MainViewMessage(MainViews view)
        {
            this.View = view;
        }

        /// <summary>
        /// Gets the view.
        /// </summary>
        public MainViews View { get; }
    }
}
