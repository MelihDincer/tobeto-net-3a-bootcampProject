using Business.Responses.Users;

namespace Business.Abstracts
{
    public interface IUserService
    {
        Task<List<GetAllUserResponse>> GetAll();
        Task<GetByIdUserResponse> GetById(int id);

        //List<GetAllUserResponse> GetAll();
        //GetByIdUserResponse GetById(int id);
    }
}
