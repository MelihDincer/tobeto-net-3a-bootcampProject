using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;

namespace Business.Rules
{
    public class InstructorBusinessRules : BaseBusinessRules
    {
        private readonly IInstructorRepository _instructorRepository;

        public InstructorBusinessRules(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public async Task CheckIfInstructorNotExists(int instructorId)
        {
            var isExists = await _instructorRepository.GetAsync(a => a.Id == instructorId);
            if (isExists is null)
                throw new BusinessException("Instructor does not exists");
        }
    }
}
