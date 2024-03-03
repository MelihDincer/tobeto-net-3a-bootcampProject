using Business.Constants;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;

namespace Business.Rules;
public class InstructorBusinessRules : BaseBusinessRules
{
    private readonly IInstructorRepository _instructorRepository;

    public InstructorBusinessRules(IInstructorRepository instructorRepository)
    {
        _instructorRepository = instructorRepository;
    }

    public async Task CheckIfInstructorNotExists(int instructorId)
    {
        var isExists = await _instructorRepository.GetAsync(a => a.Id == instructorId);
        if (isExists is null)
            throw new BusinessException(InstructorMessages.InstructorIdCheck);
    }

    public async Task CheckUserNameIfExist(string userName)
    {
        var isExists = await _instructorRepository.GetAsync(a => a.UserName == userName);
        if (isExists is not null)
            throw new BusinessException(InstructorMessages.UserNameCheck);
    }

    public async Task CheckEmailExist(string email)
    {
        var isExists = await _instructorRepository.GetAsync(a => a.Email == email);
        if (isExists is not null)
            throw new BusinessException(InstructorMessages.EmailCheck);
    }

    public async Task CheckNationalIdentityIfExist(string nationalIdentity)
    {
        var isExists = await _instructorRepository.GetAsync(a => a.NationalIdentity == nationalIdentity);
        if (isExists is not null)
            throw new BusinessException(InstructorMessages.NationalIdentityCheck);
    }
}
