using PClub.Backend.Models;

namespace PClub.Backend.WebAPI.Helpers
{
    /// <summary>
    /// Сервис текущего пользователя
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Получить текущего пользователя
        /// </summary>
        /// <returns></returns>
        ClubUser GetUser();

        /// <summary>
        /// Задать пользователя
        /// </summary>
        void SetUser(ClubUser user);
    }
}
