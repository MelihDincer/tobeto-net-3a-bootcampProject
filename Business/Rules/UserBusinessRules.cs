using Business.Constants;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;

namespace Business.Rules
{
    public class UserBusinessRules : BaseBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CheckIfUserNotExists(int userId)
        {
            var isExists = await _userRepository.GetAsync(u => u.Id == userId);
            if (isExists is null)
                throw new BusinessException(UserMessages.UserIdCheck);
        }
    }
}
