namespace Asland.Interfaces.ViewModels.Body.Analysis.Common
{
    using System;

    /// <summary>
    /// This interface counts a single habitat.
    /// </summary>
    public interface IEnumCounterViewModel<T> where T : Enum
    {
        /// <summary>
        /// Gets the <see cref="T"/> which is the subject of this view model.
        /// </summary>
        T Name { get; }

        /// <summary>
        /// Gets the <see cref="Name"/> as a string.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the total number of occurances of <see cref="Name"/>.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Add one to the <see cref="Count"/>.
        /// </summary>
        void CountOne();
    }
}