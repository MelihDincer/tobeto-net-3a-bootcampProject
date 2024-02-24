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

        public async Task<IDataResult<DeleteApplicantResponse>> DeleteAsync(DeleteApplicantRequest request)
        {
            Applicant applicant = _applicantRepository.Get(x => x.Id == request.UserId);
            await _applicantRepository.DeleteAsync(applicant);
            DeleteApplicantResponse response = _mapper.Map<DeleteApplicantResponse>(applicant);
            return new SuccessDataResult<DeleteApplicantResponse>(response, "Başarıyla silindi");
        }

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
