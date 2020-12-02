namespace Asland.Interfaces.ViewModels.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interface which describes a component used by a user to select a enumerate value from all
    /// possible enumeration values.
    /// </summary>
    /// <typeparam name="TEnum">Subject enumeration</typeparam>
    public interface IEnumSelectorViewModel<TEnum> where TEnum : struct, IConvertible, IComparable, IFormattable
    {
        /// <summary>
        /// Gets the name of the comonent.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Collection of all the enumerate selector controls within the enumeration selector.
        /// </summary>
        List<IEnumComponentViewModel<TEnum>> Controls { get; }

        /// <summary>
        /// Gets the action to invoke when a new enumerate is select.
        /// </summary>
        Action<TEnum> Action { get; }

        /// <summary>
        /// Set a new current value.
        /// </summary>
        /// <param name="newValue">The new value</param>
        void Set(TEnum newValue);
    }
}