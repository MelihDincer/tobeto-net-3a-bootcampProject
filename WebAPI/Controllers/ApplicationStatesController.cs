using Business.Abstracts;
using Business.Requests.ApplicationStates;
using Business.Responses.ApplicationStates;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationStateStatesController : ControllerBase
    {
        private readonly IApplicationStateService _applicationStateService;

        public ApplicationStateStatesController(IApplicationStateService applicationStateStateService)
        {
            _applicationStateService = applicationStateStateService;
        }

        [HttpGet]
        public async Task<IDataResult<List<GetAllApplicationStateResponse>>> GetAllAsync()
        {
            return await _applicationStateService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IDataResult<GetByIdApplicationStateResponse>> GetByIdAsync(int id)
        {
            return await _applicationStateService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<IDataResult<CreateApplicationStateResponse>> AddAsync(CreateApplicationStateRequest request)
        {
            return await _applicationStateService.AddAsync(request);
        }

        [HttpDelete]
        public async Task<Core.Utilities.Results.IResult> DeleteAsync(DeleteApplicationStateRequest request)
        {
            return await _applicationStateService.DeleteAsync(request);
        }

        [HttpPut]
        public async Task<IDataResult<UpdateApplicationStateResponse>> UpdateAsync(UpdateApplicationStateRequest request)
        {
            return await _applicationStateService.UpdateAsync(request);
        }
    }
}
