using PClub.Backend.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PClub.Backend.Models
{
    /// <summary>
    /// Запись на посещение
    /// </summary>
    public class Entry : IWithId<long>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }

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

        /// <summary>
        /// Компьютер
        /// </summary>
        public Computer Computer { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid ClubUserId { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public ClubUser ClubUser { get; set; }
    }
}
