using Business.Abstracts;
using Business.Constants;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;

namespace Business.Rules
{
    public class BootcampBusinessRules : BaseBusinessRules
    {
        private readonly IBootcampRepository _bootcampRepository;
        private readonly IInstructorService _instructorService;
        private readonly IBootcampStateService _bootcampStateService;

        public BootcampBusinessRules(IBootcampRepository bootcampRepository, IInstructorService instructorService, IBootcampStateService bootcampStateService)
        {
            _bootcampRepository = bootcampRepository;
            _instructorService = instructorService;
            _bootcampStateService = bootcampStateService;
        }

        public async Task CheckIfBootcampNotExists(int id)
        {
            var isExists = await _bootcampRepository.GetAsync(a => a.Id == id);
            if (isExists is null)
                throw new BusinessException(BootcampMessages.BootcampIdCheck);
        }

        public async Task CheckIfInstructorNotExists(int instructorId)
        {
            var isExists = await _instructorService.GetByIdAsync(instructorId);
            if (isExists.Data is null)
                throw new BusinessException(InstructorMessages.InstructorIdCheck);
        }

        public async Task CheckIfBootcampStateNotExists(int bootcampStateId)
        {
            var isExists = await _bootcampStateService.GetByIdAsync(bootcampStateId);
            if (isExists.Data is null)
                throw new BusinessException(BootcampStateMessages.BootcampStateIdCheck);
        }

        public async Task CheckBootcampNameIfExist(string bootcampName)
        {
            var isExists = await _bootcampRepository.GetAsync(b => b.Name == bootcampName);
            if (isExists is not null)
                throw new BusinessException(BootcampMessages.BootcampNameCheck);
        }
    }
}
