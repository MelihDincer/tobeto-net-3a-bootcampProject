using AutoMapper;
using Business.Requests.BlackLists;
using Business.Responses.BlackLists;
using Entities.Concretes;

namespace Business.Profiles.BlackLists
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<BlackList, CreateBlackListRequest>().ReverseMap();
            CreateMap<BlackList, DeleteBlackListRequest>().ReverseMap();
            CreateMap<BlackList, UpdateBlackListRequest>().ReverseMap();

            CreateMap<BlackList, CreateBlackListResponse>().ReverseMap();
            CreateMap<BlackList, UpdateBlackListResponse>().ReverseMap();
            CreateMap<BlackList, GetAllBlackListResponse>().ReverseMap();
            CreateMap<BlackList, GetByIdBlackListResponse>().ReverseMap();
            CreateMap<BlackList, GetByApplicantIdBlackListResponse>().ReverseMap();
        }
    }
}
