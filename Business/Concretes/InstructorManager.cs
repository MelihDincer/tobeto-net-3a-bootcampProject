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
            foreach (var instructor in await _instructorRepository.GetAll())
            {
                GetAllInstructorResponse response = new();
                response.UserId = instructor.Id;
                response.CompanyName = instructor.CompanyName;
                instructors.Add(response);
            }
            return instructors;
        }

        public async Task<GetByIdInstructorResponse> GetById(int id)
        {
            GetByIdInstructorResponse response = new();
            Instructor instructor = await _instructorRepository.Get(x => x.Id == id);
            response.CompanyName = instructor.CompanyName;
            return response;
        }

        public async Task<CreateInstructorResponse> AddAsync(CreateInstructorRequest request)
        {
            Instructor instructor = new();
            instructor.Id = request.UserId;
            instructor.CompanyName = request.CompanyName;
            await _instructorRepository.Add(instructor);

            CreateInstructorResponse response = new();
            response.UserId = instructor.Id;
            response.CompanyName = instructor.CompanyName;
            return response;
        }

        public async Task<DeleteInstructorResponse> DeleteAsync(DeleteInstructorRequest request)
        {
            Instructor instructor = new();
            instructor.Id = request.UserId;
            instructor.CompanyName = request.CompanyName;
            await _instructorRepository.Delete(instructor);

            DeleteInstructorResponse response = new();
            response.UserId = instructor.Id;
            response.CompanyName = instructor.CompanyName;
            return response;
        }

        public async Task<UpdateInstructorResponse> UpdateAsync(UpdateInstructorRequest request)
        {
            Instructor instructor = await _instructorRepository.Get(x => x.Id == request.UserId);
            instructor.Id = request.UserId;
            instructor.CompanyName = request.CompanyName;
            await _instructorRepository.Update(instructor);

            UpdateInstructorResponse response = new();
            response.UserId = instructor.Id;
            response.CompanyName = instructor.CompanyName;
            return response;
        }
    }
}
