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
                throw new BusinessException("Applicant does not exists");
        }
    }
}