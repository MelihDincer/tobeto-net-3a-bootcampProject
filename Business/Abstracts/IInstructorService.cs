﻿using Business.Requests.Instructors;
using Business.Responses.Instructors;
using Core.Utilities.Results;

namespace Business.Abstracts
{
    public interface IInstructorService
    {
        Task<IDataResult<List<GetAllInstructorResponse>>> GetAllAsync();
        Task<IDataResult<GetByIdInstructorResponse>> GetByIdAsync(int id);
        Task<IDataResult<CreateInstructorResponse>> AddAsync(CreateInstructorRequest request);
        Task<IResult> DeleteAsync(DeleteInstructorRequest request);
        Task<IDataResult<UpdateInstructorResponse>> UpdateAsync(UpdateInstructorRequest request);
    }
}
