using AutoMapper;
using Business.Responses.Users;
using Core.Utilities.Security.Entities;

namespace Business.Profiles.Users;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, GetAllUserResponse>().ReverseMap();
        CreateMap<User, GetByIdUserResponse>().ReverseMap();
    }
}