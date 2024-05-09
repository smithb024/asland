namespace Asland.ViewModels.Body
{
    using Asland.Factories.IO;
    using Asland.Interfaces;
    using Asland.Interfaces.ViewModels.Body;
    using Asland.Interfaces.ViewModels.Common;
    using Asland.Model.IO;
    using Asland.ViewModels.Common;
    using NynaeveLib.ViewModel;
    using System;
    using System.IO;

    /// <summary>
    /// The view model which supports the main consistency check view.
    /// </summary>
    public class ConsistencyViewModel : ViewModelBase, IConsistencyViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ConsistencyViewModel"/> class.
        /// </summary>
        /// <param name="pathManager">the path manager</param>
        public ConsistencyViewModel(
            IPathManager pathManager)
        {
            string basePath = pathManager.RawDataPath;

            this.LocationCollection = new ComponentCounterCollectionViewModel("Locations");
            this.LengthCollection = new ComponentCounterCollectionViewModel("Length");
            this.IntensityCollection = new ComponentCounterCollectionViewModel("Intensity");
            this.TimeOfDayCollection = new ComponentCounterCollectionViewModel("TimeOfDay");
            this.WeatherCollection = new ComponentCounterCollectionViewModel("Weather");
            this.HabitatCollection = new ComponentCounterCollectionViewModel("Habitat");
            this.KindCollection = new ComponentCounterCollectionViewModel("Kind");

            string[] subdirectoryEntries = Directory.GetDirectories(basePath);

            try
            {
                foreach (string directory in subdirectoryEntries)
                {
                    string[] files = Directory.GetFiles(directory);

                    foreach (string file in files)
                    {
                        RawObservationsString cars = XmlFileIo.ReadXml<RawObservationsString>(file);

                        this.LocationCollection.AddOne(cars.Location);
                        this.LengthCollection.AddOne(cars.Length);
                        this.IntensityCollection.AddOne(cars.Intensity);
                        this.TimeOfDayCollection.AddOne(cars.TimeOfDay);
                        this.WeatherCollection.AddOne(cars.Weather);

                        foreach (string habitat in cars.Habitats.Habitat)
                        {
                            this.HabitatCollection.AddOne(habitat);
                        }

                        foreach (string kind in cars.Species.Kind)
                        {
                            this.KindCollection.AddOne(kind);
                        }

                        foreach (string kind in cars.Heard.Kind)
                        {
                            this.KindCollection.AddOne(kind);
                        }
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.ToString());
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// Gets the location collection.
        /// </summary>
        public IComponentCounterCollectionViewModel LocationCollection { get; }

        /// <summary>
        /// Gets the length collection.
        /// </summary>
        public IComponentCounterCollectionViewModel LengthCollection { get; }

        /// <summary>
        /// Gets the intensity collection.
        /// </summary>
        public IComponentCounterCollectionViewModel IntensityCollection { get; }

        /// <summary>
        /// Gets the time of day collection.
        /// </summary>
        public IComponentCounterCollectionViewModel TimeOfDayCollection { get; }

        /// <summary>
        /// Gets the weather collection.
        /// </summary>
        public IComponentCounterCollectionViewModel WeatherCollection { get; }

        /// <summary>
        /// Gets the habitat collection.
        /// </summary>
        public IComponentCounterCollectionViewModel HabitatCollection { get; }

        /// <summary>
        /// Gets the kind collection.
        /// </summary>
        public IComponentCounterCollectionViewModel KindCollection { get; }
    }
}