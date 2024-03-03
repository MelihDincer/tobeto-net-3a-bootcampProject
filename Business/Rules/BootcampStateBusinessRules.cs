using Business.Constants;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;
using DataAccess.Repositories;

namespace Business.Rules
{
    public class BootcampStateBusinessRules : BaseBusinessRules
    {
        private readonly IBootcampStateRepository _bootcampStateRepository;

        public BootcampStateBusinessRules(IBootcampStateRepository bootcampStateRepository)
        {
            _bootcampStateRepository = bootcampStateRepository;
        }

        public async Task CheckIfBootcampStateNotExists(int id)
        {
            var isExists = await _bootcampStateRepository.GetAsync(a => a.Id == id);
            if (isExists is null)
                throw new BusinessException("BootcampState does not exists");
        }

        public async Task CheckBootcampStateNameIfExist(string name)
        {
            var isExists = await _bootcampStateRepository.GetAsync(b => b.Name == name);
            if (isExists is not null)
                throw new BusinessException(BootcampStateMessages.BootcampStateNameCheck);
        }
    }
}
