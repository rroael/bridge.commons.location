using System;
using Bridge.Commons.Location.Exceptions;
using Bridge.Commons.Location.Models;
using GeoTimeZone;
using NodaTime;

namespace Bridge.Commons.Location.Extensions
{
    /// <summary>
    ///     Extensões de DateTime
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        ///     Busca a quantidade de segundos Epoch Unix Timestamp
        /// </summary>
        /// <param name="utcDateTime">Data e hora em UTC</param>
        /// <returns></returns>
        public static double GetSecondsEpoch(this DateTime utcDateTime)
        {
            if (utcDateTime.Kind != DateTimeKind.Utc)
                throw new DateTimeKindException();

            return utcDateTime.Subtract(Get1970Utc()).TotalSeconds;
        }

        /// <summary>
        ///     Busca a quantidade de milissegundos Epoch Unix Timestamp
        /// </summary>
        /// <param name="utcDateTime">Data e hora em UTC</param>
        /// <returns></returns>
        public static double GetMillisecondsEpoch(this DateTime utcDateTime)
        {
            if (utcDateTime.Kind != DateTimeKind.Utc)
                throw new DateTimeKindException();

            return utcDateTime.Subtract(Get1970Utc()).TotalMilliseconds;
        }

        /// <summary>
        ///     Busca a data e hora localizada a partir de um local
        /// </summary>
        /// <param name="utcDateTime">Data e hora em UTC</param>
        /// <param name="lat">Latitude do local</param>
        /// <param name="lon">Longitude do local</param>
        /// <returns>Data e hora localizada</returns>
        public static DateTimeZoned GetDateTimeZonedFromPosition(this DateTime utcDateTime, double lat, double lon)
        {
            if (utcDateTime.Kind != DateTimeKind.Utc)
                throw new DateTimeKindException();

            var resultZone = TimeZoneLookup.GetTimeZone(lat, lon);
            var now = Instant.FromDateTimeUtc(utcDateTime);
            var dateTimeZoneProvider = DateTimeZoneProviders.Tzdb[resultZone.Result];
            var zoneInterval = dateTimeZoneProvider.GetZoneInterval(now);

            var result = new DateTimeZoned
            {
                Name = dateTimeZoneProvider.Id,
                Offset = zoneInterval.WallOffset,
                StandardOffset = zoneInterval.StandardOffset,
                IntOffset = zoneInterval.WallOffset.ToTimeSpan().Hours,
                UtcDateTime = utcDateTime,
                LocalDateTime = now.InZone(dateTimeZoneProvider).ToDateTimeUnspecified()
            };

            return result;
        }

        /// <summary>
        ///     Busca a data e hora localizada a partir de um fuso horário
        /// </summary>
        /// <param name="utcDateTime">Data e hora em UTC</param>
        /// <param name="zoneId">Identificador do fuso horário</param>
        /// <returns>Data e hora localizada</returns>
        public static DateTimeZoned GetDateTimeZonedFromZoneId(this DateTime utcDateTime, string zoneId)
        {
            if (utcDateTime.Kind != DateTimeKind.Utc)
                throw new DateTimeKindException();

            var now = Instant.FromDateTimeUtc(utcDateTime);
            var dateTimeZoneProvider = DateTimeZoneProviders.Tzdb[zoneId];
            var zoneInterval = dateTimeZoneProvider.GetZoneInterval(now);

            var result = new DateTimeZoned
            {
                Name = dateTimeZoneProvider.Id,
                Offset = zoneInterval.WallOffset,
                StandardOffset = zoneInterval.StandardOffset,
                IntOffset = zoneInterval.WallOffset.ToTimeSpan().Hours,
                UtcDateTime = utcDateTime,
                LocalDateTime = now.InZone(dateTimeZoneProvider).ToDateTimeUnspecified()
            };

            return result;
        }

        #region PRIVATE

        private static DateTime Get1970Utc()
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        }

        #endregion
    }
}