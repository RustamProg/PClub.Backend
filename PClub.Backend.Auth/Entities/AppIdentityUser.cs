using Microsoft.AspNetCore.Identity;

namespace PClub.Backend.Auth.Entities
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class AppIdentityUser : IdentityUser
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string SecondName { get; set; }
    }
}
