using Business.Constants;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;

namespace Business.Rules;
public class ApplicantBusinessRules : BaseBusinessRules
{
    private readonly IApplicantRepository _applicantRepository;

    public ApplicantBusinessRules(IApplicantRepository applicantRepository)
    {
        _applicantRepository = applicantRepository;
    }

    public async Task CheckIfApplicantNotExists(int applicantId)
    {
        var isExists = await _applicantRepository.GetAsync(a => a.Id == applicantId);
        if (isExists is null)
            throw new BusinessException(ApplicantMessages.ApplicantIdCheck);
    }

    public async Task CheckUserNameIfExist(string userName)
    {
        var isExists = await _applicantRepository.GetAsync(a => a.UserName == userName);
        if (isExists is not null)
            throw new BusinessException(ApplicantMessages.UserNameCheck);
    }

    public async Task CheckEmailExist(string email)
    {
        var isExists = await _applicantRepository.GetAsync(a => a.Email == email);
        if (isExists is not null)
            throw new BusinessException(ApplicantMessages.EmailCheck);
    }

    public async Task CheckNationalIdentityIfExist(string nationalIdentity)
    {
        var isExists = await _applicantRepository.GetAsync(a => a.NationalIdentity == nationalIdentity);
        if (isExists is not null)
            throw new BusinessException(ApplicantMessages.NationalIdentityCheck);
    }
}