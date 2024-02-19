using Business.Abstracts;
using Business.Requests.Applicants;
using Business.Responses.Applicants;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class ApplicantManager : IApplicantService
    {
        private readonly IApplicantRepository _applicantRepository;
        public ApplicantManager(IApplicantRepository applicantRepository)
        {
            _applicantRepository = applicantRepository;
        }

        public async Task<List<GetAllApplicantResponse>> GetAll()
        {
            List<GetAllApplicantResponse> instructors = new List<GetAllApplicantResponse>();
            foreach (var applicant in await _applicantRepository.GetAllAsync())
            {
                GetAllApplicantResponse response = new();
                response.UserId = applicant.Id;
                response.UserName = applicant.UserName;
                response.FirstName = applicant.FirstName;
                response.LastName = applicant.LastName;
                response.Email = applicant.Email;
                response.DateOfBirth = applicant.DateOfBirth;
                response.NationalIdentity = applicant.NationalIdentity;
                response.Password = applicant.Password;
                response.About = applicant.About;
                response.CreatedDate = applicant.CreatedDate;
                response.DeletedDate = applicant.DeletedDate;
                response.UpdatedDate = applicant.UpdatedDate;
                instructors.Add(response);
            }
            return instructors;
        }

        public async Task<GetByIdApplicantResponse> GetById(int id)
        {
            GetByIdApplicantResponse response = new();
            Applicant applicant = await _applicantRepository.GetAsync(x => x.Id == id);
            response.UserId = applicant.Id;
            response.UserName = applicant.UserName;
            response.FirstName = applicant.FirstName;
            response.LastName = applicant.LastName;
            response.Email = applicant.Email;
            response.DateOfBirth = applicant.DateOfBirth;
            response.NationalIdentity = applicant.NationalIdentity;
            response.Password = applicant.Password;
            response.About = applicant.About;
            response.CreatedDate = applicant.CreatedDate;
            response.DeletedDate = applicant.DeletedDate;
            response.UpdatedDate = applicant.UpdatedDate;
            return response;
        }

        public async Task<CreateApplicantResponse> AddAsync(CreateApplicantRequest request)
        {
            Applicant applicant = new();
            applicant.UserName = request.UserName;
            applicant.FirstName = request.FirstName;
            applicant.LastName = request.LastName;
            applicant.Email = request.Email;
            applicant.DateOfBirth = request.DateOfBirth;
            applicant.NationalIdentity = request.NationalIdentity;
            applicant.Password = request.Password;
            applicant.About = request.About;
            await _applicantRepository.AddAsync(applicant);

            CreateApplicantResponse response = new();
            response.UserId = applicant.Id;
            response.UserName = applicant.UserName;
            response.FirstName = applicant.FirstName;
            response.LastName = applicant.LastName;
            response.Email = applicant.Email;
            response.DateOfBirth = applicant.DateOfBirth;
            response.NationalIdentity = applicant.NationalIdentity;
            response.Password = applicant.Password;
            response.About = applicant.About;
            response.CreatedDate = applicant.CreatedDate;
            return response;
        }

        public async Task<DeleteApplicantResponse> DeleteAsync(DeleteApplicantRequest request)
        {
            Applicant applicant = await _applicantRepository.GetAsync(x => x.Id == request.UserId);
            applicant.Id = request.UserId;
            await _applicantRepository.DeleteAsync(applicant);

            DeleteApplicantResponse response = new();
            response.UserId = applicant.Id;
            response.UserName = applicant.UserName;
            response.FirstName = applicant.FirstName;
            response.LastName = applicant.LastName;
            response.DateOfBirth = applicant.DateOfBirth;
            response.Email = applicant.Email;
            response.NationalIdentity = applicant.NationalIdentity;
            response.Password = applicant.Password;
            response.About = applicant.About;
            response.CreatedDate = applicant.CreatedDate;
            response.UpdatedDate = applicant.UpdatedDate;
            response.DeletedDate = applicant.DeletedDate;
            return response;
        }

        public async Task<UpdateApplicantResponse> UpdateAsync(UpdateApplicantRequest request)
        {
            Applicant applicant = await _applicantRepository.GetAsync(x => x.Id == request.UserId);
            applicant.UserName = request.UserName;
            applicant.FirstName = request.FirstName;
            applicant.LastName = request.LastName;
            applicant.DateOfBirth = request.DateOfBirth;
            applicant.Email = request.Email;
            applicant.NationalIdentity = request.NationalIdentity;
            applicant.Password = request.Password;
            applicant.About = request.About;
            await _applicantRepository.UpdateAsync(applicant);

            UpdateApplicantResponse response = new();
            response.UserId = applicant.Id;
            response.UserName = applicant.UserName;
            response.FirstName = applicant.FirstName;
            response.LastName = applicant.LastName;
            response.DateOfBirth = applicant.DateOfBirth;
            response.Email = applicant.Email;
            response.NationalIdentity = applicant.NationalIdentity;
            response.Password = applicant.Password;
            response.About = applicant.About;
            response.CreatedDate = applicant.CreatedDate;
            response.UpdatedDate = applicant.UpdatedDate;
            return response;
        }
    }
}
