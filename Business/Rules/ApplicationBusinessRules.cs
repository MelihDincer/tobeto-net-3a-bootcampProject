using Business.Abstracts;
using Business.Constants;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;

namespace Business.Rules
{
    public class ApplicationBusinessRules : BaseBusinessRules
    {
        private readonly IBlackListService _blackListService;
        private readonly IApplicationRepository _applicationRepository;
        private readonly ApplicantBusinessRules _applicantRules;
        private readonly BootcampBusinessRules _bootcampRules;
        private readonly ApplicationStateBusinessRules _applicationStateRules;


        public ApplicationBusinessRules(IBlackListService blackListService, IApplicationRepository applicationRepository, BootcampBusinessRules bootcampRules, ApplicantBusinessRules applicantRules, ApplicationStateBusinessRules applicationStateRules)
        {
            _blackListService = blackListService;
            _applicationRepository = applicationRepository;
            _bootcampRules = bootcampRules;
            _applicantRules = applicantRules;
            _applicationStateRules = applicationStateRules;
        }

        public async Task CheckIfApplicantIsBlackList(int applicantId)
        {
            var applicant = await _blackListService.CheckIfApplicantIdBlackList(applicantId);
            if (applicant.Data is not null)
                throw new BusinessException(ApplicationMessages.ApplicantBlacklisted);
        }

        public async Task CheckIfApplicationNotExists(int applicationId)
        {
            var isExists = await _applicationRepository.GetAsync(a => a.Id == applicationId);
            if (isExists is null)
                throw new BusinessException(ApplicationMessages.ApplicationIdCheck);
        }

        public async Task CheckIfApplicantNotExists(int applicantId)
        {
            await _applicantRules.CheckIfApplicantNotExists(applicantId);
        }

        public async Task CheckIfBootcampNotExists(int bootcampId)
        {
            await _bootcampRules.CheckIfBootcampNotExists(bootcampId);
        }

        public async Task CheckIfApplicationStateNotExists(int applicationStateId)
        {
            await _applicationStateRules.CheckIfApplicationStateNotExists(applicationStateId);
        }

        public async Task CheckIfApplicantBootcampNotExists(int applicantId, int bootcampId)
        {
            var isExists = await _applicationRepository.GetAsync(a => a.ApplicantId == applicantId && a.BootcampId == bootcampId);
            if (isExists is not null)
                throw new BusinessException(ApplicationMessages.ApplicationAlreadyExists);
        }
    }
}