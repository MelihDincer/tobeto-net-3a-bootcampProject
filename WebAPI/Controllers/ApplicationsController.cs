using Business.Abstracts;
using Business.Requests.Applications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ApplicationsController : BaseController
    {
        private readonly IApplicationService _applicationService;

        public ApplicationsController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        [Authorize(Roles = "application.list")]
        public async Task<IActionResult> GetAllAsync()
        {
            return HandleDataResult(await _applicationService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return HandleDataResult(await _applicationService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateApplicationRequest request)
        {
            return HandleDataResult(await _applicationService.AddAsync(request));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(DeleteApplicationRequest request)
        {
            return HandleResult(await _applicationService.DeleteAsync(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateApplicationRequest request)
        {
            return HandleDataResult(await _applicationService.UpdateAsync(request));
        }
    }
}