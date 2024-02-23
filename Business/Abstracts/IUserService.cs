using Business.Responses.Users;
using Core.Utilities.Results;

namespace Business.Abstracts
{
    public interface IUserService
    {
        Task<IDataResult<List<GetAllUserResponse>>> GetAllAsync();
        Task<IDataResult<GetByIdUserResponse>> GetByIdAsync(int id);

        //List<GetAllUserResponse> GetAll();
        //GetByIdUserResponse GetById(int id);
    }
}
