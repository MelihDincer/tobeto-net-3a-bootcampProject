using Business.Abstracts;
using Business.Requests.Users;
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

            foreach (var user in await _userRepository.GetAll())
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
            User user = await _userRepository.Get(x => x.Id == id);
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
        public async Task<CreateUserResponse> AddAsync(CreateUserRequest request)
        {
            User user = new();
            user.UserName = request.UserName;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.DateOfBirth = request.DateOfBirth;
            user.NationalIdentity = request.NationalIdentity;
            user.Email = request.Email;
            user.Password = request.Password;
            await _userRepository.Add(user);

            CreateUserResponse response = new();
            response.UserName = user.UserName;
            response.FirstName = user.FirstName;
            response.LastName = user.LastName;
            response.DateOfBirth = user.DateOfBirth;
            response.NationalIdentity = user.NationalIdentity;
            response.Email = user.Email;
            response.Password = user.Password;
            response.CreatedDate = user.CreatedDate;
            return response;
        }

        public async Task<DeleteUserResponse> DeleteAsync(DeleteUserRequest request)
        {
            User user = new();
            user.Id = request.Id;
            user.UserName = user.UserName;
            user.FirstName = user.FirstName;
            user.LastName = user.LastName;
            user.DateOfBirth = user.DateOfBirth;
            user.NationalIdentity = user.NationalIdentity;
            user.Email = user.Email;
            user.Password = user.Password;
            await _userRepository.Delete(user);

            DeleteUserResponse response = new();
            response.UserName = user.UserName;
            response.FirstName = user.FirstName;
            response.LastName = user.LastName;
            response.DateOfBirth = user.DateOfBirth;
            response.NationalIdentity = user.NationalIdentity;
            response.Email = user.Email;
            response.Password = user.Password;
            response.DeletedDate = user.DeletedDate;
            return response;
        }

        public async Task<UpdateUserResponse> UpdateAsync(UpdateUserRequest request)
        {
            User user = await _userRepository.Get(u => u.Id == request.Id);
            user.Id = request.Id;
            user.UserName = request.UserName;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.DateOfBirth = request.DateOfBirth;
            user.NationalIdentity = request.NationalIdentity;
            user.Email = request.Email;
            user.Password = request.Password;
            await _userRepository.Update(user);

            UpdateUserResponse response = new();
            response.UserName = user.UserName;
            response.FirstName = user.FirstName;
            response.LastName = user.LastName;
            response.DateOfBirth = user.DateOfBirth;
            response.NationalIdentity = user.NationalIdentity;
            response.Email = user.Email;
            response.Password = user.Password;
            response.UpdatedDate = user.UpdatedDate;
            return response;
        }
    }
}
