using Business.Abstracts;
using Business.Requests.Bootcamps;
using Business.Responses.Bootcamps;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootcampsController : ControllerBase
    {
        private readonly IBootcampService _bootcampService;

        public BootcampsController(IBootcampService bootcampService)
        {
            _bootcampService = bootcampService;
        }

        [HttpGet]
        public async Task<IDataResult<List<GetAllBootcampResponse>>> GetAllAsync()
        {
            return await _bootcampService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IDataResult<GetByIdBootcampResponse>> GetById(int id)
        {
            return await _bootcampService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<IDataResult<CreateBootcampResponse>> AddAsync(CreateBootcampRequest request)
        {
            return await _bootcampService.AddAsync(request);
        }

        [HttpDelete]
        public async Task<Core.Utilities.Results.IResult> DeleteAsync(DeleteBootcampRequest request)
        {
            return await _bootcampService.DeleteAsync(request);
        }

        [HttpPut]
        public async Task<IDataResult<UpdateBootcampResponse>> UpdateAsync(UpdateBootcampRequest request)
        {
            return await _bootcampService.UpdateAsync(request);
        }
    }
}
