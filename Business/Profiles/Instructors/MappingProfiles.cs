using AutoMapper;
using Business.Requests.Instructors;
using Business.Responses.Instructors;
using Entities.Concretes;

namespace Business.Profiles.Instructors
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Instructor, CreateInstructorRequest>().ReverseMap();
            CreateMap<Instructor, DeleteInstructorRequest>().ReverseMap();
            CreateMap<Instructor, UpdateInstructorRequest>().ReverseMap();

            CreateMap<Instructor, CreateInstructorResponse>().ReverseMap();
            CreateMap<Instructor, UpdateInstructorResponse>().ReverseMap();
            CreateMap<Instructor, GetAllInstructorResponse>().ReverseMap();
            CreateMap<Instructor, GetByIdInstructorResponse>().ReverseMap();
        }
    }
}
