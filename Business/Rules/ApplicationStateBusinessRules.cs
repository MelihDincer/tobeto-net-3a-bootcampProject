using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;

namespace Business.Rules
{
    public class ApplicationStateBusinessRules : BaseBusinessRules
    {
        private readonly IApplicationStateRepository _applicationStateRepository;

        public ApplicationStateBusinessRules(IApplicationStateRepository applicationStateRepository)
        {
            _applicationStateRepository = applicationStateRepository;
        }

        public async Task CheckIfApplicationStateNotExists(int id)
        {
            var isExists = await _applicationStateRepository.GetAsync(a => a.Id == id);
            if (isExists is null)
                throw new BusinessException("ApplicationState does not exists");
        }
    }
}
