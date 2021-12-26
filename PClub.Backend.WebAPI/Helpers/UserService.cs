using PClub.Backend.Models;

namespace PClub.Backend.WebAPI.Helpers
{
    /// <summary>
    /// Сервис пользователя
    /// </summary>
    public class UserService : IUserService
    {
        private ClubUser _user;

        public ClubUser GetUser()
        {
            return _user;
        }

        public void SetUser(ClubUser user)
        {
            _user = user;
        }
    }
}
