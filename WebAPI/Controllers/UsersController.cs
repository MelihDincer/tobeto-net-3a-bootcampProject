using Business.Abstracts;
using Business.Responses.Users;
using Core.Utilities.Results;
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
        public async Task<IDataResult<List<GetAllUserResponse>>> GetAllAsync()
        {
            return await _userService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IDataResult<GetByIdUserResponse>> GetByIdAsync(int id)
        {
            return await _userService.GetByIdAsync(id);
        }
    }
}
