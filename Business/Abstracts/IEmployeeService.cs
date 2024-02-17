using Business.Requests.Employees;
using Business.Responses.Employees;

namespace Business.Abstracts
{
    public interface IEmployeeService
    {
        Task<List<GetAllEmployeeResponse>> GetAll();
        Task<GetByIdEmployeeResponse> GetById(int id);
        Task<CreateEmployeeResponse> AddAsync(CreateEmployeeRequest request);
        Task<DeleteEmployeeResponse> DeleteAsync(DeleteEmployeeRequest request);
        Task<UpdateEmployeeResponse> UpdateAsync(UpdateEmployeeRequest request);
    }
}
