namespace Bridge.Commons.Location.Models
{
    /// <summary>
    ///     Ponto de localização
    /// </summary>
    public class LocationPoint
    {
        /// <summary>
        ///     Construtor
        /// </summary>
        public LocationPoint()
        {
        }

        /// <summary>
        ///     Construtor
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public LocationPoint(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        ///     Latitude
        /// </summary>
        /// <example>-25.4677143</example>
        public double Latitude { get; set; }

        /// <summary>
        ///     Longitude
        /// </summary>
        /// <example>-49.2919272</example>
        public double Longitude { get; set; }
    }
}