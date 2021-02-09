namespace Asland.Interfaces.ViewModels.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interface which describes a component used by a user to select a set of enumerate values
    /// from all possible values in the enumeration.
    /// </summary>
    /// <typeparam name="TEnum">Subject enumeration</typeparam>
    public interface IEnumSelectorCompoundViewModel<TEnum> where TEnum : struct, IConvertible, IComparable, IFormattable
    {
        /// <summary>
        /// Gets the name of the comonent.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Collection of all the enumerate selector controls within the enumeration selector.
        /// </summary>
        List<IEnumComponentCompoundViewModel<TEnum>> Controls { get; }

        /// <summary>
        /// Gets the action to invoke when a new enumerate has been selected.
        /// </summary>
        Action<List<TEnum>> Action { get; }

        /// <summary>
        /// Set a new collection of values.
        /// </summary>
        /// <remarks>
        /// This just sets the values, it doesn't inform any other interested parties that it
        /// has done this.
        /// </remarks>
        /// <param name="newValues">The new values</param>
        void Set(List<TEnum> newValues);
    }
}