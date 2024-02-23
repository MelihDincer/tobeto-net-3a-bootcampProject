﻿using Business.Abstracts;
using Business.Requests.Applicants;
using Business.Responses.Applicants;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantsController : ControllerBase
    {
        private readonly IApplicantService _applicantService;

        public ApplicantsController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        [HttpGet]
        public async Task<IDataResult<List<GetAllApplicantResponse>>> GetAllAsync()
        {
            return await _applicantService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IDataResult<GetByIdApplicantResponse>> GetByIdAsync(int id)
        {
            return await _applicantService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<IDataResult<CreateApplicantResponse>> AddAsync(CreateApplicantRequest request)
        {
            return await _applicantService.AddAsync(request);
        }

        [HttpDelete]
        public async Task<Core.Utilities.Results.IResult> DeleteAsync(DeleteApplicantRequest request)
        {
            return await _applicantService.DeleteAsync(request);
        }

        [HttpPut]
        public async Task<IDataResult<UpdateApplicantResponse>> UpdateAsync(UpdateApplicantRequest request)
        {
            return await _applicantService.UpdateAsync(request);
        }
    }
}
