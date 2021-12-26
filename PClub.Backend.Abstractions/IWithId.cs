using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PClub.Backend.Abstractions
{
    /// <summary>
    /// У объекта есть Id
    /// </summary>
    public interface IWithId<T>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public T Id { get; set; }
    }
}
