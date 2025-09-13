namespace Asland.Common.Utils
{
    using System.Windows.Media;

    /// <summary>
    /// A static class used to store all colours used by the c# code within the solution.
    /// </summary>
    public static class ColourLibrary
    {
        /// <summary>
        /// A colour which is used for an unrecognised colour.
        /// </summary>
        public static Color UnknownColour => Colors.HotPink;

        /// <summary>
        /// A colour which is used for a snapshot.
        /// </summary>
        public static Color Snapshot => Colors.Indigo;

        /// <summary>
        /// A colour which is used for the high intensity.
        /// </summary>
        public static Color HighIntensity => Colors.DarkGreen;

        /// <summary>
        /// A colour which is used for the medium intensity.
        /// </summary>
        public static Color MediumIntensity => Colors.ForestGreen;

        /// <summary>
        /// A colour which used for the low intensity.
        /// </summary>
        public static Color LowIntensity => Colors.Olive;

        /// <summary>
        /// A colour which is used for a run.
        /// </summary>
        public static Color Run => Colors.DarkBlue;

        /// <summary>
        /// A colour which is used for a ride.
        /// </summary>
        public static Color Cycling => Colors.MediumBlue;

        /// <summary>
        /// A colour which is used for a walk.
        /// </summary>
        public static Color Walk => Colors.RoyalBlue;

        /// <summary>
        /// A colour which is used for the commute.
        /// </summary>
        public static Color Commute => Colors.IndianRed;

        /// <summary>
        /// A colour which is used for rail.
        /// </summary>
        public static Color Rail => Colors.DarkGoldenrod;

        /// <summary>
        /// A colour which is used for sea.
        /// </summary>
        public static Color Sea => Colors.Goldenrod;

        /// <summary>
        /// A colour used for a beastie which comes to breed.
        /// </summary>
        public static Color Breeding => Colors.Tomato;

        /// <summary>
        /// A colour used for a beastie which stays year round, but which hibernates.
        /// </summary>
        public static Color Hibernates => Colors.PowderBlue;

        /// <summary>
        /// A colour used for a beastie which comes to over winter.
        /// </summary>
        public static Color NonBreeding => Colors.DodgerBlue;

        /// <summary>
        /// A colour for a beastie which migrates through.
        /// </summary>
        public static Color Passing => Colors.DarkGoldenrod;

        /// <summary>
        /// A colour for a beastie which lives year round.
        /// </summary>
        public static Color Resident => Colors.ForestGreen;

        /// <summary>
        /// A colour for a rare/unusual beastie.
        /// </summary>
        public static Color Vagrant => Colors.LightSteelBlue;

    }
}
