using Business.Constants;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;

namespace Business.Rules
{
    public class BlackListBusinessRules : BaseBusinessRules
    {
        private readonly IBlackListRepository _blackListRepository;

        public BlackListBusinessRules(IBlackListRepository blackListRepository)
        {
            _blackListRepository = blackListRepository;
        }

        public async Task CheckIfBlackListNotExists(int id)
        {
            var isExists = await _blackListRepository.GetAsync(a => a.Id == id);
            if (isExists is null)
                throw new BusinessException(BlacklistMessages.BlacklistIdCheck);
        }

        public async Task CheckIfApplicantNotExists(int applicantId)
        {
            var isExists = await _blackListRepository.GetAsync(b => b.ApplicantId == applicantId);
            if(isExists is not null)
            {
                throw new BusinessException(BlacklistMessages.BlacklistApplicantFound);
            } 
        }

        public async Task CheckIfApplicantExists(int applicantId)
        {
            var isExists = await _blackListRepository.GetAsync(b => b.ApplicantId == applicantId);
            if (isExists is null)
            {
                throw new BusinessException(BlacklistMessages.BlacklistApplicantNotFound);
            }
        }
    }
}