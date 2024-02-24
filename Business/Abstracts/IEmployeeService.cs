﻿using Business.Requests.Employees;
using Business.Responses.Employees;
using Core.Utilities.Results;

namespace Business.Abstracts
{
    public interface IEmployeeService
    {
        Task<IDataResult<List<GetAllEmployeeResponse>>> GetAllAsync();
        Task<IDataResult<GetByIdEmployeeResponse>> GetByIdAsync(int id);
        Task<IDataResult<CreateEmployeeResponse>> AddAsync(CreateEmployeeRequest request);
        Task<IDataResult<DeleteEmployeeResponse>> DeleteAsync(DeleteEmployeeRequest request);
        Task<IDataResult<UpdateEmployeeResponse>> UpdateAsync(UpdateEmployeeRequest request);

        //List<GetAllEmployeeResponse> GetAll();
        //GetByIdEmployeeResponse GetById(int id);
        //CreateEmployeeResponse Add(CreateEmployeeRequest request);
        //DeleteEmployeeResponse Delete(DeleteEmployeeRequest request);
        //UpdateEmployeeResponse Update(UpdateEmployeeRequest request);
    }
}
