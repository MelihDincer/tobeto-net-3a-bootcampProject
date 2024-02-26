﻿using AutoMapper;
using Business.Requests.ApplicationStates;
using Business.Responses.ApplicationStates;
using Entities.Concretes;

namespace Business.Profiles.ApplicationStates
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ApplicationState, CreateApplicationStateRequest>().ReverseMap();
            CreateMap<ApplicationState, DeleteApplicationStateRequest>().ReverseMap();
            CreateMap<ApplicationState, UpdateApplicationStateRequest>().ReverseMap();

            CreateMap<ApplicationState, CreateApplicationStateResponse>().ReverseMap();
            CreateMap<ApplicationState, UpdateApplicationStateResponse>().ReverseMap();
            CreateMap<ApplicationState, GetAllApplicationStateResponse>().ReverseMap();
            CreateMap<ApplicationState, GetByIdApplicationStateResponse>().ReverseMap();
        }
    }
}