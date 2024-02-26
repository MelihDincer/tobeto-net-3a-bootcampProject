using AutoMapper;
using Business.Requests.Employees;
using Business.Responses.Employees;
using Entities.Concretes;

namespace Business.Profiles.Employees
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, CreateEmployeeRequest>().ReverseMap();
            CreateMap<Employee, DeleteEmployeeRequest>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeRequest>().ReverseMap();

            CreateMap<Employee, CreateEmployeeResponse>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeResponse>().ReverseMap();
            CreateMap<Employee, GetAllEmployeeResponse>().ReverseMap();
            CreateMap<Employee, GetByIdEmployeeResponse>().ReverseMap();
        }
    }
}
