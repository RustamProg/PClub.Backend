using AutoMapper;
using PClub.Backend.Models;
using PClub.Backend.WebAPI.Models;

namespace PClub.Backend.WebAPI.Profiles
{
    public class EntryProfile : Profile
    {
        public EntryProfile()
        {
            CreateMap<EntryDto, Entry>();

            CreateMap<Entry, EntryResponse>()
                .ForMember(d => d.VisitDate, opt => opt.MapFrom(s => s.VisitStartDateTime.ToString("dd.MM.yyyy")))
                .ForMember(d => d.VisitTimeInfo, opt => opt.MapFrom(s => s.VisitStartDateTime.ToString("HH:mm") + s.VisitEndDateTime.ToString("HH:mm")))
                .ForMember(d => d.ComputerName, opt => opt.MapFrom(s => s.Computer.Name))
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.ClubUser.FirstName + " " + s.ClubUser.SecondName));
        }
    }
}
