using Business.Requests.Applicants;
using Business.Responses.Applicants;

namespace Business.Abstracts
{
    public interface IApplicantService
    {
        Task<List<GetAllApplicantResponse>> GetAll();
        Task<GetByIdApplicantResponse> GetById(int id);
        Task<CreateApplicantResponse> AddAsync(CreateApplicantRequest request);
        Task<DeleteApplicantResponse> DeleteAsync(DeleteApplicantRequest request);
        Task<UpdateApplicantResponse> UpdateAsync(UpdateApplicantRequest request);
    }
}
