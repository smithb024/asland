namespace Asland.Interfaces.ViewModels.Body
{
    using Asland.Interfaces.ViewModels.Common;

    /// <summary>
    /// View model for the main consistency view. 
    /// </summary>
    public interface IConsistencyViewModel
    {
        /// <summary>
        /// Gets the location collection.
        /// </summary>
        IComponentCounterCollectionViewModel LocationCollection { get; }

        /// <summary>
        /// Gets the length collection.
        /// </summary>
        IComponentCounterCollectionViewModel LengthCollection { get; }

        /// <summary>
        /// Gets the intensity collection.
        /// </summary>
        IComponentCounterCollectionViewModel IntensityCollection { get; }

        /// <summary>
        /// Gets the time of day collection.
        /// </summary>
        IComponentCounterCollectionViewModel TimeOfDayCollection { get; }

        /// <summary>
        /// Gets the weather collection.
        /// </summary>
        IComponentCounterCollectionViewModel WeatherCollection { get; }

        /// <summary>
        /// Gets the habitat collection.
        /// </summary>
        IComponentCounterCollectionViewModel HabitatCollection { get; }

        /// <summary>
        /// Gets the kind collection.
        /// </summary>
        IComponentCounterCollectionViewModel KindCollection { get; }
    }
}