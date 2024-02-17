using Business.Abstracts;
using Business.Requests.Users;
using Business.Responses.Users;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _userService.GetById(id));
        }

        [HttpPost]
        public async Task<CreateUserResponse> AddAsync(CreateUserRequest request)
        {
            return await _userService.AddAsync(request);
        }

        [HttpDelete]
        public async Task<DeleteUserResponse> DeleteAsync(DeleteUserRequest request)
        {
            return await _userService.DeleteAsync(request);
        }

        [HttpPut]
        public async Task<UpdateUserResponse> UpdateAsync(UpdateUserRequest request)
        {
            return await _userService.UpdateAsync(request);
        }

    }
}
