using Business.Abstracts;
using Business.Requests.Instructors;
using Business.Responses.Instructors;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class InstructorManager : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;

        public InstructorManager(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }
        public async Task<List<GetAllInstructorResponse>> GetAll()
        {
            List<GetAllInstructorResponse> instructors = new List<GetAllInstructorResponse>();
            foreach (var instructor in await _instructorRepository.GetAllAsync())
            {
                GetAllInstructorResponse response = new();
                response.UserId = instructor.Id;
                response.UserName = instructor.UserName;
                response.FirstName = instructor.FirstName;
                response.LastName = instructor.LastName;
                response.Email = instructor.Email;
                response.NationalIdentity = instructor.NationalIdentity;
                response.DateOfBirth = instructor.DateOfBirth;
                response.Password = instructor.Password;
                response.CompanyName = instructor.CompanyName;
                response.CreatedDate = instructor.CreatedDate;
                response.DeletedDate = instructor.DeletedDate;
                response.UpdatedDate = instructor.UpdatedDate;
                instructors.Add(response);
            }
            return instructors;
        }

        public async Task<GetByIdInstructorResponse> GetById(int id)
        {
            GetByIdInstructorResponse response = new();
            Instructor instructor = await _instructorRepository.GetAsync(x => x.Id == id);
            response.UserId = instructor.Id;
            response.UserName = instructor.UserName;
            response.FirstName = instructor.FirstName;
            response.LastName = instructor.LastName;
            response.Email = instructor.Email;
            response.NationalIdentity = instructor.NationalIdentity;
            response.DateOfBirth = instructor.DateOfBirth;
            response.Password = instructor.Password;
            response.CompanyName = instructor.CompanyName;
            response.CreatedDate = instructor.CreatedDate;
            response.DeletedDate = instructor.DeletedDate;
            response.UpdatedDate = instructor.UpdatedDate;
            return response;
        }

        public async Task<CreateInstructorResponse> AddAsync(CreateInstructorRequest request)
        {
            Instructor instructor = new();
            instructor.UserName = request.UserName;
            instructor.FirstName = request.FirstName;
            instructor.LastName = request.LastName;
            instructor.Email = request.Email;
            instructor.NationalIdentity = request.NationalIdentity;
            instructor.DateOfBirth = request.DateOfBirth;
            instructor.Password = request.Password;
            instructor.CompanyName = request.CompanyName;
            await _instructorRepository.AddAsync(instructor);

            CreateInstructorResponse response = new();
            response.UserId = instructor.Id;
            response.UserName = instructor.UserName;
            response.FirstName = instructor.FirstName;
            response.LastName = instructor.LastName;
            response.Email = instructor.Email;
            response.NationalIdentity = instructor.NationalIdentity;
            response.DateOfBirth = instructor.DateOfBirth;
            response.Password = instructor.Password;
            response.CompanyName = instructor.CompanyName;
            response.CreatedDate = instructor.CreatedDate;
            return response;
        }

        public async Task<DeleteInstructorResponse> DeleteAsync(DeleteInstructorRequest request)
        {
            Instructor instructor = await _instructorRepository.GetAsync(x => x.Id == request.UserId);
            instructor.Id = request.UserId;
            await _instructorRepository.DeleteAsync(instructor);

            DeleteInstructorResponse response = new();
            response.UserId = instructor.Id;
            response.UserName = instructor.UserName;
            response.FirstName = instructor.FirstName;
            response.LastName = instructor.LastName;
            response.Email = instructor.Email;
            response.NationalIdentity = instructor.NationalIdentity;
            response.DateOfBirth = instructor.DateOfBirth;
            response.Password = instructor.Password;
            response.CompanyName = instructor.CompanyName;
            response.CreatedDate = instructor.CreatedDate;
            response.DeletedDate = instructor.DeletedDate;
            response.UpdatedDate = instructor.UpdatedDate;
            return response;
        }

        public async Task<UpdateInstructorResponse> UpdateAsync(UpdateInstructorRequest request)
        {
            Instructor instructor = await _instructorRepository.GetAsync(x => x.Id == request.UserId);
            instructor.UserName = request.UserName;
            instructor.FirstName = request.FirstName;
            instructor.LastName = request.LastName;
            instructor.Email = request.Email;
            instructor.NationalIdentity = request.NationalIdentity;
            instructor.DateOfBirth = request.DateOfBirth;
            instructor.Password = request.Password;
            instructor.CompanyName = request.CompanyName;
            await _instructorRepository.UpdateAsync(instructor);

            UpdateInstructorResponse response = new();
            response.UserId = instructor.Id;
            response.UserName = instructor.UserName;
            response.FirstName = instructor.FirstName;
            response.LastName = instructor.LastName;
            response.Email = instructor.Email;
            response.NationalIdentity = instructor.NationalIdentity;
            response.DateOfBirth = instructor.DateOfBirth;
            response.Password = instructor.Password;
            response.CompanyName = instructor.CompanyName;
            response.CreatedDate = instructor.CreatedDate;
            response.UpdatedDate = instructor.UpdatedDate;
            return response;
        }
    }
}
