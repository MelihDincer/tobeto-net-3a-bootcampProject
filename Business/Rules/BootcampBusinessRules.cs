using Business.Constants;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;

namespace Business.Rules
{
    public class BootcampBusinessRules : BaseBusinessRules
    {
        private readonly IBootcampRepository _bootcampRepository;

        public BootcampBusinessRules(IBootcampRepository bootcampRepository)
        {
            _bootcampRepository = bootcampRepository;
        }

        public async Task CheckIfBootcampNotExists(int id)
        {
            var isExists = await _bootcampRepository.GetAsync(a => a.Id == id);
            if (isExists is null)
                throw new BusinessException(BootcampMessages.BootcampIdCheck);
        }

        public async Task CheckIfInstructorNotExists(int instructorId)
        {
            var isExists = await _bootcampRepository.GetAsync(b => b.InstructorId == instructorId);
            if (isExists is null)
                throw new BusinessException(BootcampMessages.BootcampInstructorCheck);
        }

        public async Task CheckIfBootcampStateNotExists(int bootcampStateId)
        {
            var isExists = await _bootcampRepository.GetAsync(b => b.BootcampStateId == bootcampStateId);
            if (isExists is null)
                throw new BusinessException(BootcampMessages.BootcampStateCheck);
        }

        public async Task CheckBootcampNameIfExist(string bootcampName)
        {
            var isExists = await _bootcampRepository.GetAsync(b => b.Name == bootcampName);
            if (isExists is not null)
                throw new BusinessException(BootcampMessages.BootcampNameCheck);
        }
    }
}
