using Business.Abstracts;
using Business.Requests.Employees;
using Business.Responses.Employees;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<GetAllEmployeeResponse>> GetAll()
        {
            List<GetAllEmployeeResponse> employees = new List<GetAllEmployeeResponse>();
            foreach (var employee in await _employeeRepository.GetAll())
            {
                GetAllEmployeeResponse response = new();
                response.UserId = employee.Id;
                response.Position = employee.Position;
                employees.Add(response);
            }
            return employees;
        }

        public async Task<GetByIdEmployeeResponse> GetById(int id)
        {
            GetByIdEmployeeResponse response = new();
            Employee employee = await _employeeRepository.Get(x => x.Id == id);
            response.UserId = employee.Id;
            response.Position = employee.Position;
            return response;
        }

        public async Task<CreateEmployeeResponse> AddAsync(CreateEmployeeRequest request)
        {
            Employee employee = new();
            employee.Id = request.UserId;
            employee.Position = request.Position;
            await _employeeRepository.Add(employee);

            CreateEmployeeResponse response = new();
            response.UserId = employee.Id;
            response.Position = employee.Position;
            return response;
        }

        public async Task<DeleteEmployeeResponse> DeleteAsync(DeleteEmployeeRequest request)
        {
            Employee employee = new();
            employee.Id = request.UserId;
            employee.Position = request.Position;
            await _employeeRepository.Delete(employee);


            DeleteEmployeeResponse response = new();
            response.UserId = employee.Id;
            response.Position = employee.Position;
            return response;
        }

        public async Task<UpdateEmployeeResponse> UpdateAsync(UpdateEmployeeRequest request)
        {
            Employee employee = await _employeeRepository.Get(x => x.Id == request.UserId);
            employee.Id = request.UserId;
            employee.Position = request.Position;
            await _employeeRepository.Update(employee);

            UpdateEmployeeResponse response = new();
            response.UserId = employee.Id;
            response.Position = employee.Position;
            return response;
        }
    }
}
