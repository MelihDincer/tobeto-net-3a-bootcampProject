using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;

namespace Business.Rules
{
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
                throw new BusinessException("Applicant does not exists");
        }
    }
}
