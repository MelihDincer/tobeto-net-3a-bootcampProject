using Business.Constants;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;

namespace Business.Rules;
public class EmployeeBusinessRules : BaseBusinessRules
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeBusinessRules(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task CheckIfEmployeeNotExists(int employeeId)
    {
        var isExists = await _employeeRepository.GetAsync(a => a.Id == employeeId);
        if (isExists is null)
            throw new BusinessException(EmployeeMessages.EmployeeIdCheck);
    }

    public async Task CheckUserNameIfExist(string userName)
    {
        var isExists = await _employeeRepository.GetAsync(a => a.UserName == userName);
        if (isExists is not null)
            throw new BusinessException(EmployeeMessages.UserNameCheck);
    }

    public async Task CheckEmailExist(string email)
    {
        var isExists = await _employeeRepository.GetAsync(a => a.Email == email);
        if (isExists is not null)
            throw new BusinessException(EmployeeMessages.EmailCheck);
    }

    public async Task CheckNationalIdentityIfExist(string nationalIdentity)
    {
        var isExists = await _employeeRepository.GetAsync(a => a.NationalIdentity == nationalIdentity);
        if (isExists is not null)
            throw new BusinessException(EmployeeMessages.NationalIdentityCheck);
    }
}
