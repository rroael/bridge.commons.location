using System;
using NodaTime;

namespace Bridge.Commons.Location.Models
{
    /// <summary>
    ///     Data e hora em zonas
    /// </summary>
    public struct DateTimeZoned
    {
        /// <summary>
        ///     Identificador do fuso horário
        /// </summary>
        public string Id => Name;

        /// <summary>
        ///     Nome do fuso horário
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Descrição do fuso horário
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Offset (número que representa a diferença em horas do UTC) do fuso horário - Funcional (diferente quando em horário
        ///     de verão)
        /// </summary>
        public Offset Offset { get; set; }

        /// <summary>
        ///     Offset (número que representa a diferença em horas do UTC) do fuso horário - Padrão
        /// </summary>
        public Offset StandardOffset { get; set; }

        /// <summary>
        ///     Inteiro do Offset funcional
        /// </summary>
        public int IntOffset { get; set; }

        /// <summary>
        ///     Se é horário de verão (DST - Daylight Saving Time)
        /// </summary>
        public bool IsDst => Offset != StandardOffset;

        /// <summary>
        ///     Data e hora local
        /// </summary>
        public DateTime LocalDateTime { get; set; }

        /// <summary>
        ///     Data e hora UTC
        /// </summary>
        public DateTime UtcDateTime { get; set; }
    }
}