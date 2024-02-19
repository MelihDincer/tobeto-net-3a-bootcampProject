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
            foreach (var employee in await _employeeRepository.GetAllAsync())
            {
                GetAllEmployeeResponse response = new();
                response.UserId = employee.Id;
                response.UserName = employee.UserName;
                response.FirstName = employee.FirstName;
                response.LastName = employee.LastName;
                response.Email = employee.Email;
                response.DateOfBirth = employee.DateOfBirth;
                response.NationalIdentity = employee.NationalIdentity;
                response.Password = employee.Password;
                response.Position = employee.Position;
                response.CreatedDate = employee.CreatedDate;
                response.DeletedDate = employee.DeletedDate;
                response.UpdatedDate = employee.UpdatedDate;
                employees.Add(response);
            }
            return employees;
        }

        public async Task<GetByIdEmployeeResponse> GetById(int id)
        {
            GetByIdEmployeeResponse response = new();
            Employee employee = await _employeeRepository.GetAsync(x => x.Id == id);
            response.UserId = employee.Id;
            response.UserName = employee.UserName;
            response.FirstName = employee.FirstName;
            response.LastName = employee.LastName;
            response.Email = employee.Email;
            response.DateOfBirth = employee.DateOfBirth;
            response.NationalIdentity = employee.NationalIdentity;
            response.Password = employee.Password;
            response.Position = employee.Position;
            response.CreatedDate = employee.CreatedDate;
            response.DeletedDate = employee.DeletedDate;
            response.UpdatedDate = employee.UpdatedDate;
            return response;
        }

        public async Task<CreateEmployeeResponse> AddAsync(CreateEmployeeRequest request)
        {
            Employee employee = new();
            employee.UserName = request.UserName;
            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.Email = request.Email;
            employee.DateOfBirth = request.DateOfBirth;
            employee.Password = request.Password;
            employee.NationalIdentity = request.NationalIdentity;
            employee.Position = request.Position;
            await _employeeRepository.AddAsync(employee);

            CreateEmployeeResponse response = new();
            response.UserId = employee.Id;
            response.UserName = employee.UserName;
            response.FirstName = employee.FirstName;
            response.LastName = employee.LastName;
            response.Email = employee.Email;
            response.DateOfBirth = employee.DateOfBirth;
            response.NationalIdentity = employee.NationalIdentity;
            response.Password = employee.Password;
            response.Position = employee.Position;
            response.CreatedDate = employee.CreatedDate;
            return response;
        }

        public async Task<DeleteEmployeeResponse> DeleteAsync(DeleteEmployeeRequest request)
        {
            Employee employee = await _employeeRepository.GetAsync(x => x.Id == request.UserId);
            employee.Id = request.UserId;
            await _employeeRepository.DeleteAsync(employee);

            DeleteEmployeeResponse response = new();
            response.UserId = employee.Id;
            response.UserName = employee.UserName;
            response.FirstName = employee.FirstName;
            response.LastName = employee.LastName;
            response.Email = employee.Email;
            response.DateOfBirth = employee.DateOfBirth;
            response.NationalIdentity = employee.NationalIdentity;
            response.Password = employee.Password;
            response.Position = employee.Position;
            response.CreatedDate = employee.CreatedDate;
            response.DeletedDate = employee.DeletedDate;
            response.UpdatedDate = employee.UpdatedDate;
            return response;
        }

        public async Task<UpdateEmployeeResponse> UpdateAsync(UpdateEmployeeRequest request)
        {
            Employee employee = await _employeeRepository.GetAsync(x => x.Id == request.UserId);
            employee.UserName = request.UserName;
            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.Email = request.Email;
            employee.DateOfBirth = request.DateOfBirth;
            employee.NationalIdentity = request.NationalIdentity;
            employee.Password = request.Password;
            employee.Position = request.Position;
            await _employeeRepository.UpdateAsync(employee);

            UpdateEmployeeResponse response = new();
            response.UserId = employee.Id;
            response.UserName = employee.UserName;
            response.FirstName = employee.FirstName;
            response.LastName = employee.LastName;
            response.Email = employee.Email;
            response.DateOfBirth = employee.DateOfBirth;
            response.NationalIdentity = employee.NationalIdentity;
            response.Password = employee.Password;
            response.Position = employee.Position;
            response.CreatedDate = employee.CreatedDate;
            response.UpdatedDate = employee.UpdatedDate;
            return response;
        }
    }
}
