using AutoMapper;
using Business.Abstracts;
using Business.Requests.Applicants;
using Business.Responses.Applicants;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class ApplicantManager : IApplicantService
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IMapper _mapper;
        public ApplicantManager(IApplicantRepository applicantRepository, IMapper mapper)
        {
            _applicantRepository = applicantRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<GetAllApplicantResponse>>> GetAllAsync()
        {
            List<Applicant> applicants = await _applicantRepository.GetAllAsync();
            List<GetAllApplicantResponse> responses = _mapper.Map<List<GetAllApplicantResponse>>(applicants);
            return new SuccessDataResult<List<GetAllApplicantResponse>>(responses, "Listeleme başarılı.");
        }

        public async Task<IDataResult<GetByIdApplicantResponse>> GetByIdAsync(int id)
        {
            Applicant applicant = await _applicantRepository.GetAsync(x => x.Id == id);
            GetByIdApplicantResponse response = _mapper.Map<GetByIdApplicantResponse>(applicant);
            return new SuccessDataResult<GetByIdApplicantResponse>(response);
        }

        public async Task<IDataResult<CreateApplicantResponse>> AddAsync(CreateApplicantRequest request)
        {
            Applicant applicant = _mapper.Map<Applicant>(request);
            await _applicantRepository.AddAsync(applicant);
            CreateApplicantResponse response = _mapper.Map<CreateApplicantResponse>(applicant);
            return new SuccessDataResult<CreateApplicantResponse>(response, "Ekleme işlemi başarılı");
        }

        public async Task<IResult> DeleteAsync(DeleteApplicantRequest request)
        {
            Applicant applicant = _applicantRepository.Get(x => x.Id == request.UserId);
            await _applicantRepository.DeleteAsync(applicant);
            return new SuccessResult("Başarıyla silindi");
        }

        //public async Task<UpdateApplicantResponse> UpdateAsync(UpdateApplicantRequest request)
        //{
        //    Applicant applicant = await _applicantRepository.GetAsync(x => x.Id == request.UserId);
        //    applicant.UserName = request.UserName;
        //    applicant.FirstName = request.FirstName;
        //    applicant.LastName = request.LastName;
        //    applicant.DateOfBirth = request.DateOfBirth;
        //    applicant.Email = request.Email;
        //    applicant.NationalIdentity = request.NationalIdentity;
        //    applicant.Password = request.Password;
        //    applicant.About = request.About;
        //    await _applicantRepository.UpdateAsync(applicant);

        //    UpdateApplicantResponse response = new();
        //    response.UserId = applicant.Id;
        //    response.UserName = applicant.UserName;
        //    response.FirstName = applicant.FirstName;
        //    response.LastName = applicant.LastName;
        //    response.DateOfBirth = applicant.DateOfBirth;
        //    response.Email = applicant.Email;
        //    response.NationalIdentity = applicant.NationalIdentity;
        //    response.Password = applicant.Password;
        //    response.About = applicant.About;
        //    response.CreatedDate = applicant.CreatedDate;
        //    response.UpdatedDate = applicant.UpdatedDate;
        //    return response;
        //}
        public async Task<IDataResult<UpdateApplicantResponse>> UpdateAsync(UpdateApplicantRequest request)
        {
            Applicant applicant = await _applicantRepository.GetAsync(x => x.Id == request.UserId);
            _mapper.Map(request, applicant);
            await _applicantRepository.UpdateAsync(applicant);
            UpdateApplicantResponse response = _mapper.Map<UpdateApplicantResponse>(applicant);
            return new SuccessDataResult<UpdateApplicantResponse>(response, "Güncelleme başarılı");
        }
    }
}
