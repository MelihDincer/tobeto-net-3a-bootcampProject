using Business.Abstracts;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;

namespace Business.Rules
{
    public class ApplicationBusinessRules : BaseBusinessRules
    {
        private readonly IBlackListService _blackListService;
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationBusinessRules(IBlackListService blackListService, IApplicationRepository applicationRepository)
        {
            _blackListService = blackListService;
            _applicationRepository = applicationRepository;
        }

        public async Task CheckIfApplicantIsBlackList(int applicantId)
        {
            var applicant = await _blackListService.GetByApplicantIdAsync(applicantId);
            if (applicant.Data is not null)
                throw new BusinessException("Applicant is in BlackList");
        }

        public async Task CheckIfApplicationNotExists(int applicationId)
        {
            var isExists = await _applicationRepository.GetAsync(a => a.Id == applicationId);
            if (isExists is null)
                throw new BusinessException("Application does not exists");
        }
    }
}