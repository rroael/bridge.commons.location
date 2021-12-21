using System.Collections.Generic;
using System.Linq;
using Bridge.Commons.Location.Resources;
using NodaTime;
using NodaTime.TimeZones;

namespace Bridge.Commons.Location.Utils
{
    /// <summary>
    ///     Time Zone Util
    /// </summary>
    public static class TimeZoneUtil
    {
        /// <summary>
        ///     Lista um dicionário com todos os fuso horários
        /// </summary>
        /// <returns>Lista de fuso horários</returns>
        public static IDictionary<string, string> GetAllTimeZones()
        {
            var now = SystemClock.Instance.GetCurrentInstant();
            var tzdb = DateTimeZoneProviders.Tzdb;

            var list = from l in TzdbDateTimeZoneSource.Default.ZoneLocations
                let zoneId = l.ZoneId
                let tz = tzdb[zoneId]
                let offset = tz.GetZoneInterval(now).WallOffset
                let offsetStandard = tz.GetZoneInterval(now).StandardOffset
                orderby offset, zoneId
                select new
                {
                    Id = l.ZoneId,
                    Name =
                        $"{zoneId} ({offset:+HH:mm}){(offset != offsetStandard ? " - " + TimeZone.DaylightSavings : string.Empty)}"
                };

            return list.ToDictionary(x => x.Id, x => x.Name);
        }

        /// <summary>
        ///     Lista todos os fuso horários existentes do offset informado
        /// </summary>
        /// <param name="zoneOffset">Número inteiro correspondente ao fuso horário</param>
        /// <returns>Lista de fuso horários</returns>
        public static List<string> GetTimeZonesFromOffset(int zoneOffset)
        {
            var now = SystemClock.Instance.GetCurrentInstant();
            var tzdb = DateTimeZoneProviders.Tzdb;

            var list = from l in TzdbDateTimeZoneSource.Default.ZoneLocations
                let zoneId = l.ZoneId
                let tz = tzdb[zoneId]
                let offset = tz.GetZoneInterval(now).WallOffset
                let offsetStandard = tz.GetZoneInterval(now).StandardOffset
                orderby offset, zoneId
                where offsetStandard.Milliseconds == zoneOffset * 3600000
                      && offset == offsetStandard
                select l.ZoneId;

            return list.ToList();
        }
    }
}