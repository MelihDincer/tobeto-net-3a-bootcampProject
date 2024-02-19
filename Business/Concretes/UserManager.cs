using Business.Abstracts;
using Business.Responses.Users;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<GetAllUserResponse>> GetAll()
        {
            List<GetAllUserResponse> users = new();

            foreach (var user in await _userRepository.GetAllAsync())
            {
                GetAllUserResponse response = new();
                response.Id = user.Id;
                response.UserName = user.UserName;
                response.FirstName = user.FirstName;
                response.LastName = user.LastName;
                response.DateOfBirth = user.DateOfBirth;
                response.NationalIdentity = user.NationalIdentity;
                response.Email = user.Email;
                response.Password = user.Password;
                response.CreatedDate = user.CreatedDate;
                response.DeletedDate = user.DeletedDate;
                response.UpdatedDate = user.UpdatedDate;
                users.Add(response);
            }
            return users;
        }

        public async Task<GetByIdUserResponse> GetById(int id)
        {
            GetByIdUserResponse response = new();
            User user = await _userRepository.GetAsync(x => x.Id == id);
            response.Id = user.Id;
            response.UserName = user.UserName;
            response.FirstName = user.FirstName;
            response.LastName = user.LastName;
            response.DateOfBirth = user.DateOfBirth;
            response.NationalIdentity = user.NationalIdentity;
            response.Email = user.Email;
            response.Password = user.Password;
            response.CreatedDate = user.CreatedDate;
            response.DeletedDate = user.DeletedDate;
            response.UpdatedDate = user.UpdatedDate;
            return response;
        }
    }
}
