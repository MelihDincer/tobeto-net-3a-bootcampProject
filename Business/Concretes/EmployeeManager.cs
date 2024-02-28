﻿using AutoMapper;
using Azure.Core;
using Business.Abstracts;
using Business.Requests.Employees;
using Business.Responses.Employees;
using Core.Exceptions.Types;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Repositories;
using Entities.Concretes;

namespace Business.Concretes
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeManager(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<GetAllEmployeeResponse>>> GetAllAsync()
        {
            List<Employee> employees = await _employeeRepository.GetAllAsync();
            List<GetAllEmployeeResponse> responses = _mapper.Map<List<GetAllEmployeeResponse>>(employees);
            return new SuccessDataResult<List<GetAllEmployeeResponse>>(responses, "Başarıyla listelendi");
        }

        public async Task<IDataResult<GetByIdEmployeeResponse>> GetByIdAsync(int id)
        {
            await CheckIfEmployeeNotExists(id);
            Employee employee = await _employeeRepository.GetAsync(x => x.Id == id);
            GetByIdEmployeeResponse response = _mapper.Map<GetByIdEmployeeResponse>(employee);
            return new SuccessDataResult<GetByIdEmployeeResponse>(response);
        }

        public async Task<IDataResult<CreateEmployeeResponse>> AddAsync(CreateEmployeeRequest request)
        {
            Employee employee = _mapper.Map<Employee>(request);
            await _employeeRepository.AddAsync(employee);
            CreateEmployeeResponse response = _mapper.Map<CreateEmployeeResponse>(employee);
            return new SuccessDataResult<CreateEmployeeResponse>(response, "Başarıyla eklendi");
        }

        public async Task<IResult> DeleteAsync(DeleteEmployeeRequest request)
        {
            await CheckIfEmployeeNotExists(request.UserId);
            Employee employee = await _employeeRepository.GetAsync(e => e.Id == request.UserId);
            await _employeeRepository.DeleteAsync(employee);
            return new SuccessResult("Başarıyla silindi");
        }

        public async Task<IDataResult<UpdateEmployeeResponse>> UpdateAsync(UpdateEmployeeRequest request)
        {
            await CheckIfEmployeeNotExists(request.UserId);
            Employee employee = await _employeeRepository.GetAsync(x => x.Id == request.UserId);
            _mapper.Map(request, employee);
            await _employeeRepository.UpdateAsync(employee);
            UpdateEmployeeResponse response = _mapper.Map<UpdateEmployeeResponse>(employee);
            return new SuccessDataResult<UpdateEmployeeResponse>(response, "Başarıyla güncellendi");
        }

        private async Task CheckIfEmployeeNotExists(int employeeId)
        {
            var isExists = await _employeeRepository.GetAsync(a => a.Id == employeeId);
            if (isExists is null)
                throw new BusinessException("Employee does not exists");
        }
    }
}