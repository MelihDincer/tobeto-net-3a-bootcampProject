using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Business.Responses.Users;
using Business.Rules;
using Core.Utilities.Results;
using Core.Utilities.Security.Entities;
using DataAccess.Abstracts;

namespace Business.Concretes;

public class UserManager : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly UserBusinessRules _rules;

    public UserManager(IUserRepository userRepository, IMapper mapper, UserBusinessRules rules)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _rules = rules;
    }
    public async Task<IDataResult<List<GetAllUserResponse>>> GetAllAsync()
    {
        List<User> users = await _userRepository.GetAllAsync();
        List<GetAllUserResponse> responses = _mapper.Map<List<GetAllUserResponse>>(users);
        return new SuccessDataResult<List<GetAllUserResponse>>(responses, UserMessages.UsersListed);
    }

    public async Task<IDataResult<GetByIdUserResponse>> GetByIdAsync(int id)
    {
        await _rules.CheckIfUserNotExists(id);
        User user = await _userRepository.GetAsync(x => x.Id == id);
        GetByIdUserResponse response = _mapper.Map<GetByIdUserResponse>(user);
        return new SuccessDataResult<GetByIdUserResponse>(response);
    }

    public async Task<DataResult<User>> GetByMail(string email)
    {
        return new SuccessDataResult<User>(await _userRepository.GetAsync(x => x.Email == email));
    }
}