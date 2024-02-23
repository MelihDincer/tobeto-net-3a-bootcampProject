using Business.Abstracts;
using Business.Requests.BootcampStates;
using Business.Responses.BootcampStates;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootcampStatesController : ControllerBase
    {
        private readonly IBootcampStateService _bootcampStateService;

        public BootcampStatesController(IBootcampStateService bootcampStateService)
        {
            _bootcampStateService = bootcampStateService;
        }

        [HttpGet]
        public async Task<IDataResult<List<GetAllBootcampStateResponse>>> GetAllAsync()
        {
            return await _bootcampStateService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IDataResult<GetByIdBootcampStateResponse>> GetByIdAsync(int id)
        {
            return await _bootcampStateService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<IDataResult<CreateBootcampStateResponse>> AddAsync(CreateBootcampStateRequest request)
        {
            return await _bootcampStateService.AddAsync(request);
        }

        [HttpDelete]
        public async Task<Core.Utilities.Results.IResult> DeleteAsync(DeleteBootcampStateRequest request)
        {
            return await _bootcampStateService.DeleteAsync(request);
        }

        [HttpPut]
        public async Task<IDataResult<UpdateBootcampStateResponse>> UpdateAsync(UpdateBootcampStateRequest request)
        {
            return await _bootcampStateService.UpdateAsync(request);
        }
    }
}
