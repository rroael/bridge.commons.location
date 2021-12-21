using System.Globalization;
using System.Threading;

namespace Bridge.Commons.Location.Utils
{
    /// <summary>
    ///     Globalization Util
    /// </summary>
    public class GlobalizationUtil
    {
        /// <summary>
        ///     Seta a cultura padrão da Thread atual
        /// </summary>
        /// <param name="cultureInfo">Informação de cultura</param>
        public static void SetThreadCulture(CultureInfo cultureInfo)
        {
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }

        /// <summary>
        ///     Busca a cultura padrão da Thread atual
        /// </summary>
        /// <returns>Informação de cultura</returns>
        public static CultureInfo GetCurrentThreadCulture()
        {
            return Thread.CurrentThread.CurrentCulture;
        }
    }
}