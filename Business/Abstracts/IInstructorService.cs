using Business.Requests.Instructors;
using Business.Responses.Instructors;

namespace Business.Abstracts
{
    public interface IInstructorService
    {
        Task<List<GetAllInstructorResponse>> GetAll();
        Task<GetByIdInstructorResponse> GetById(int id);
        Task<CreateInstructorResponse> AddAsync(CreateInstructorRequest request);
        Task<DeleteInstructorResponse> DeleteAsync(DeleteInstructorRequest request);
        Task<UpdateInstructorResponse> UpdateAsync(UpdateInstructorRequest request);
    }
}
