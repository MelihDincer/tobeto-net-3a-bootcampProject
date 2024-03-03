using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Business.Requests.Employees;
using Business.Responses.Employees;
using Business.Rules;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;
public class EmployeeManager : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;
    private readonly EmployeeBusinessRules _rules;

    public EmployeeManager(IEmployeeRepository employeeRepository, IMapper mapper, EmployeeBusinessRules rules)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
        _rules = rules;
    }

    public async Task<IDataResult<List<GetAllEmployeeResponse>>> GetAllAsync()
    {
        List<Employee> employees = await _employeeRepository.GetAllAsync();
        List<GetAllEmployeeResponse> responses = _mapper.Map<List<GetAllEmployeeResponse>>(employees);
        return new SuccessDataResult<List<GetAllEmployeeResponse>>(responses, EmployeeMessages.EmployeesListed);
    }

    public async Task<IDataResult<GetByIdEmployeeResponse>> GetByIdAsync(int id)
    {
        await _rules.CheckIfEmployeeNotExists(id);
        Employee employee = await _employeeRepository.GetAsync(x => x.Id == id);
        GetByIdEmployeeResponse response = _mapper.Map<GetByIdEmployeeResponse>(employee);
        return new SuccessDataResult<GetByIdEmployeeResponse>(response);
    }

    public async Task<IDataResult<CreateEmployeeResponse>> AddAsync(CreateEmployeeRequest request)
    {
        await _rules.CheckUserNameIfExist(request.UserName);
        await _rules.CheckEmailExist(request.Email);
        await _rules.CheckNationalIdentityIfExist(request.NationalIdentity);
        Employee employee = _mapper.Map<Employee>(request);
        await _employeeRepository.AddAsync(employee);
        CreateEmployeeResponse response = _mapper.Map<CreateEmployeeResponse>(employee);
        return new SuccessDataResult<CreateEmployeeResponse>(response, EmployeeMessages.EmployeeAdded);
    }

    public async Task<IResult> DeleteAsync(DeleteEmployeeRequest request)
    {
        await _rules.CheckIfEmployeeNotExists(request.UserId);
        Employee employee = await _employeeRepository.GetAsync(e => e.Id == request.UserId);
        await _employeeRepository.DeleteAsync(employee);
        return new SuccessResult(EmployeeMessages.EmployeeDeleted);
    }

    public async Task<IDataResult<UpdateEmployeeResponse>> UpdateAsync(UpdateEmployeeRequest request)
    {
        await _rules.CheckIfEmployeeNotExists(request.UserId);
        await _rules.CheckUserNameIfExist(request.UserName);
        await _rules.CheckEmailExist(request.Email);
        await _rules.CheckNationalIdentityIfExist(request.NationalIdentity);
        Employee employee = await _employeeRepository.GetAsync(x => x.Id == request.UserId);
        _mapper.Map(request, employee);
        await _employeeRepository.UpdateAsync(employee);
        UpdateEmployeeResponse response = _mapper.Map<UpdateEmployeeResponse>(employee);
        return new SuccessDataResult<UpdateEmployeeResponse>(response, EmployeeMessages.EmployeeUpdated);
    }
}