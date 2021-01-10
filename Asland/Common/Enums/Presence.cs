namespace Asland.Common.Enums
{
    /// <summary>
    /// Enumeration describing the presence of the beastie.
    /// </summary>
    public enum Presence
    {
        /// <summary>
        /// Summer vistor, is present to breed.
        /// </summary>
        Breeding,

        /// <summary>
        /// Present all year around.
        /// </summary>
        Resident,

        /// <summary>
        /// Winter visitor, is present to over winter.
        /// </summary>
        NonBreeding,

        /// <summary>
        /// Passes on migration.
        /// </summary>
        Passing,

        /// <summary>
        /// Resident, but as it hibernates it can only be observed at certain times of the year.
        /// </summary>
        Hibernates,

        /// <summary>
        /// Rare vistor
        /// </summary>
        Vagrant
    }
}
