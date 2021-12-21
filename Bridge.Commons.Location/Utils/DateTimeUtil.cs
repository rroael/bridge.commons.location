using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Bridge.Commons.Location.Utils
{
    /// <summary>
    ///     DateTime Util
    /// </summary>
    public static class DateTimeUtil
    {
        /// <summary>
        ///     Formato de data UTC
        /// </summary>
        public const string UTC_DATETIME_FORMAT = "yyyy-MM-ddTHH:mm:ssZ";

        /// <summary>
        ///     Formato de data UTC com milesegundos
        /// </summary>
        public const string UTC_DATETIME_FORMAT_WITH_MILLISECONDS = "yyyy-MM-ddTHH:mm:ss.fffZ";

        /// <summary>
        ///     Lista datas entre duas datas
        /// </summary>
        /// <param name="dateStart">Data inicial</param>
        /// <param name="dateEnd">Data final</param>
        /// <returns>Lista de datas</returns>
        public static List<DateTime> ListDatesBetween(DateTime dateStart, DateTime dateEnd)
        {
            var dates = new List<DateTime> { dateStart };

            for (var dt = dateStart; dt <= dateEnd; dt = dt.AddDays(1)) dates.Add(dt);

            dates.Add(dateEnd);

            dates = dates.Distinct().ToList();

            return dates;
        }

        /// <summary>
        ///     Busca formato curto de data
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentThreadShortDateFormat()
        {
            return Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortDatePattern;
        }

        /// <summary>
        ///     Busca formato curto de hora
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentThreadShortTimeFormat()
        {
            return Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortTimePattern;
        }

        /// <summary>
        ///     Busca formato longo de data
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentThreadLongDateFormat()
        {
            return Thread.CurrentThread.CurrentUICulture.DateTimeFormat.LongDatePattern;
        }

        /// <summary>
        ///     Busca formato longo de hora
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentThreadLongTimeFormat()
        {
            return Thread.CurrentThread.CurrentUICulture.DateTimeFormat.LongTimePattern;
        }

        /// <summary>
        ///     Busca formato completo de data e hora
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentThreadFullDateTimeFormat()
        {
            return Thread.CurrentThread.CurrentUICulture.DateTimeFormat.FullDateTimePattern;
        }

        /// <summary>
        ///     Busca formato curto de data e hora
        /// </summary>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string GetCurrentThreadShortDateTimeFormat(string separator)
        {
            var dateTimeFormatInfo = Thread.CurrentThread.CurrentUICulture.DateTimeFormat;
            return $"{dateTimeFormatInfo.ShortDatePattern} + {separator} + {dateTimeFormatInfo.ShortTimePattern}";
        }

        /// <summary>
        ///     Busca formato longo de data e hora
        /// </summary>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string GetCurrentThreadLongDateTimeFormat(string separator)
        {
            var dateTimeFormatInfo = Thread.CurrentThread.CurrentUICulture.DateTimeFormat;
            return $"{dateTimeFormatInfo.LongDatePattern} + {separator} + {dateTimeFormatInfo.LongTimePattern}";
        }
    }
}