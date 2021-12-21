using System;
using Bridge.Commons.Location.Models;

namespace Bridge.Commons.Location.Utils
{
    /// <summary>
    ///     Location Util
    /// </summary>
    public class LocationUtil
    {
        /// <summary>
        ///     Equatorial radius	       6378.137 km
        ///     Polar radius               6356.752 km
        ///     Volumetric mean radius     6371.008 km
        /// </summary>
        /// <remarks>
        ///     [Veja mais](http://nssdc.gsfc.nasa.gov/planetary/factsheet/earthfact.html)
        /// </remarks>
        public const int EarthRadius = 6371008;

        /// <summary>
        ///     Calcula a distância em metros entre dois pontos
        /// </summary>
        /// <param name="lat1">Latitude do ponto 1</param>
        /// <param name="lon1">Longitude do ponto 1</param>
        /// <param name="lat2">Latitude do ponto 2</param>
        /// <param name="lon2">Longitude do ponto 2</param>
        /// <returns>Distância em metros</returns>
        public static double GetMetersBetweenTwoPoints(double lat1, double lon1, double lat2, double lon2)
        {
            lat1 = Degrees2Radians(lat1);
            lat2 = Degrees2Radians(lat2);

            var dLat = lat2 - lat1;
            var dLon = Degrees2Radians(lon2 - lon1);
            var sinHalfDLat = Math.Sin(dLat / 2);
            var sinHalfDLon = Math.Sin(dLon / 2);

            var a = Math.Pow(sinHalfDLat, 2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(sinHalfDLon, 2);

            var c = 2 * Math.Asin(Math.Sqrt(a));

            return EarthRadius * c;
        }

        /// <summary>
        ///     Calcula a distância em metros entre dois pontos
        /// </summary>
        /// <param name="location1">Localização 1</param>
        /// <param name="location2">Localização 2</param>
        /// <returns>Distância em metros</returns>
        public static double GetMetersBetweenTwoPoints(LocationPoint location1, LocationPoint location2)
        {
            return GetMetersBetweenTwoPoints(location1.Latitude, location1.Longitude, location2.Latitude,
                location2.Longitude);
        }

        /// <summary>
        ///     Converte Graus em Radianos
        /// </summary>
        /// <param name="degrees">Graus</param>
        /// <returns>Radianos</returns>
        public static double Degrees2Radians(double degrees)
        {
            return degrees * (Math.PI / 180.0);
        }

        /// <summary>
        ///     Converte Radianos em Graus
        /// </summary>
        /// <param name="radians">Radianos</param>
        /// <returns>Graus</returns>
        public static double Radians2Degrees(double radians)
        {
            return radians * (180.0 / Math.PI);
        }
    }
}