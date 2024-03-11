using Business.Constants;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using Core.Utilities.Security.Entities;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstracts;

namespace Business.Rules;

public class AuthBusinessRules : BaseBusinessRules
{
    private readonly IUserRepository _userRepository;

    public AuthBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task UserEmailShouldBeNotExists(string email)
    {
        User? user = await _userRepository.GetAsync(u => u.Email == email);
        if (user is not null) 
            throw new BusinessException(AuthMessages.UserMailCheck);
    }

    public async Task UserEmailShouldBeExists(string email)
    {
        User? user = await _userRepository.GetAsync(u => u.Email == email);
        if (user is null) 
            throw new BusinessException(AuthMessages.UserOrMailCheck);
    }

    public Task UserShouldBeExists(User? user)
    {
        if (user is null) 
            throw new BusinessException(AuthMessages.UserOrMailCheck);
        return Task.CompletedTask;
    }

    public async Task UserPasswordShouldBeMatch(int id, string password)
    {
        User? user = await _userRepository.GetAsync(u => u.Id == id);
        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            throw new BusinessException(AuthMessages.UserMailPasswordCheck);
    }
}
