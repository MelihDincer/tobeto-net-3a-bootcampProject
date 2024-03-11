using Business.Responses.Users;
using Core.Utilities.Results;
using Core.Utilities.Security.Entities;

namespace Business.Abstracts
{
    public interface IUserService
    {
        Task<IDataResult<List<GetAllUserResponse>>> GetAllAsync();
        Task<IDataResult<GetByIdUserResponse>> GetByIdAsync(int id);
        Task<DataResult<User>> GetByMail(string email);
    }
}
