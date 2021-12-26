using System;

namespace PClub.Backend.WebAPI.Models
{
    /// <summary>
    /// Запись
    /// </summary>
    public class EntryDto
    {
        /// <summary>
        /// Дата и время начала посещения
        /// </summary>
        public DateTime VisitStartDateTime { get; set; }

        /// <summary>
        /// Дата и время конца посещения
        /// </summary>
        public DateTime VisitEndDateTime { get; set; }

        /// <summary>
        /// Идентификатор компьютера
        /// </summary>
        public long ComputerId { get; set; }
    }
}
