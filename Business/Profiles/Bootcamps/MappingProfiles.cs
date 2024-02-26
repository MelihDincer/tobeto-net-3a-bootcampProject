using AutoMapper;
using Business.Requests.Bootcamps;
using Business.Responses.Bootcamps;
using Entities.Concretes;

namespace Business.Profiles.Bootcamps
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Bootcamp, CreateBootcampRequest>().ReverseMap();
            CreateMap<Bootcamp, DeleteBootcampRequest>().ReverseMap();
            CreateMap<Bootcamp, UpdateBootcampRequest>().ReverseMap();

            CreateMap<Bootcamp, CreateBootcampResponse>().ReverseMap();
            CreateMap<Bootcamp, UpdateBootcampResponse>().ReverseMap();
            CreateMap<Bootcamp, GetAllBootcampResponse>().ReverseMap();
            CreateMap<Bootcamp, GetByIdBootcampResponse>().ReverseMap();
        }
    }
}