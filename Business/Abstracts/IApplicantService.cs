using Business.Requests.Applicants;
using Business.Responses.Applicants;
using Core.Utilities.Results;

namespace Business.Abstracts
{
    public interface IApplicantService
    {
        Task<IDataResult<List<GetAllApplicantResponse>>> GetAllAsync();
        Task<IDataResult<GetByIdApplicantResponse>> GetByIdAsync(int id);
        Task<IDataResult<CreateApplicantResponse>> AddAsync(CreateApplicantRequest request);
        Task<IResult> DeleteAsync(DeleteApplicantRequest request);
        Task<IDataResult<UpdateApplicantResponse>> UpdateAsync(UpdateApplicantRequest request);
    }
}
