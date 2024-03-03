using Business.Constants;
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
                throw new BusinessException(ApplicationStateMessages.ApplicationStateIdCheck);
        }

        public async Task CheckApplicationStateNameIfExist(string name)
        {
            var isExists = await _applicationStateRepository.GetAsync(a => a.Name == name);
            if (isExists is not null)
                throw new BusinessException(ApplicationStateMessages.ApplicationStateNameCheck);
        }
    }
}
