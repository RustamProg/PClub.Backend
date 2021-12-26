using PClub.Backend.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PClub.Backend.Models
{
    /// <summary>
    /// Компьютер
    /// </summary>
    public class Computer : IWithId<long>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название ПК
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ЦП
        /// </summary>
        public string Cpu { get; set; }

        /// <summary>
        /// ГП
        /// </summary>
        public string Gpu { get; set; }

        /// <summary>
        /// ОЗУ
        /// </summary>
        public string RAM { get; set; }

        /// <summary>
        /// Память (HDD/SSD)
        /// </summary>
        public string Storage { get; set; }

        /// <summary>
        /// Монитор
        /// </summary>
        public string Monitor { get; set; }

        /// <summary>
        /// Мышь
        /// </summary>
        public string Mouse { get; set; }

        /// <summary>
        /// Клавиатура
        /// </summary>
        public string Keypad { get; set; }

        /// <summary>
        /// Наушники
        /// </summary>
        public string Earphones { get; set; }

        /// <summary>
        /// Вебкамера
        /// </summary>
        public string Webcamera { get; set; }
    }
}
