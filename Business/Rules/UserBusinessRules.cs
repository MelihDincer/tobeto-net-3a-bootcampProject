using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;

namespace Business.Rules
{
    public class UserBusinessRules : BaseBusinessRules
    {
        private readonly IUserRepository _userRepository;
        public async Task CheckIfUserNotExists(int userId)
        {
            var isExists = await _userRepository.GetAsync(u => u.Id == userId);
            if (isExists is null)
                throw new BusinessException("User does not exists");
        }
    }
}
