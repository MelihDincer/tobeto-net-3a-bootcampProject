using Business.Requests.Users;
using Business.Responses.Users;

namespace Business.Abstracts
{
    public interface IUserService
    {
        Task<List<GetAllUserResponse>> GetAll();
        Task<GetByIdUserResponse> GetById(int id);
        Task<CreateUserResponse> AddAsync(CreateUserRequest user);
        Task<DeleteUserResponse> DeleteAsync(DeleteUserRequest user);
        Task<UpdateUserResponse> UpdateAsync(UpdateUserRequest user);     
    }
}
