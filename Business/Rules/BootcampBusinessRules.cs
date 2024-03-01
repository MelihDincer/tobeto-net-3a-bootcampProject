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
                throw new BusinessException("Bootcamp does not exists");
        }
    }
}
