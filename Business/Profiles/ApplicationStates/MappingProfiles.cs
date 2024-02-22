using AutoMapper;
using Business.Responses.Applications;
using Entities.Concretes;

namespace Business.Profiles.ApplicationStates
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ApplicationState, CreateApplicationResponse>().ReverseMap();
        }
    }
}
