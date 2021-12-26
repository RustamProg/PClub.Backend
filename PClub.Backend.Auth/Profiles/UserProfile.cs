using AutoMapper;
using PClub.Backend.Auth.Entities;
using PClub.Backend.Auth.Models;

namespace PClub.Backend.Auth.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegistrationRequest, AppIdentityUser>()
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.Email));
        }
    }
}
