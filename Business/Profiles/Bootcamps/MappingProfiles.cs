using AutoMapper;
using Business.Responses.Bootcamps;
using Entities.Concretes;

namespace Business.Profiles.Bootcamps
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Bootcamp, CreateBootcampResponse>().ReverseMap();
        }
    }
}
