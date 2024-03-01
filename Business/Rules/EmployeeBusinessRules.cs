using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;

namespace Business.Rules
{
    public class EmployeeBusinessRules : BaseBusinessRules
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeBusinessRules(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task CheckIfEmployeeNotExists(int employeeId)
        {
            var isExists = await _employeeRepository.GetAsync(a => a.Id == employeeId);
            if (isExists is null)
                throw new BusinessException("Employee does not exists");
        }
    }
}
