using AutoMapper;
using Business.Abstracts;
using Business.Requests.Applications;
using Business.Responses.Applications;
using Core.Exceptions.Types;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class ApplicationManager : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;
        private readonly IBlackListService _blackListService;

        public ApplicationManager(IApplicationRepository applicationRepository, IMapper mapper, IBlackListService blackListService)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
            _blackListService = blackListService;
        }
        public async Task<IDataResult<List<GetAllApplicationResponse>>> GetAllAsync()
        {
            List<Application> applications = await _applicationRepository.GetAllAsync(include: x => x.Include(x => x.Applicant).Include(x => x.Bootcamp).Include(x => x.ApplicationState));
            List<GetAllApplicationResponse> responses = _mapper.Map<List<GetAllApplicationResponse>>(applications);
            return new SuccessDataResult<List<GetAllApplicationResponse>>(responses, "Listeleme başarılı");
        }

        public async Task<IDataResult<GetByIdApplicationResponse>> GetByIdAsync(int id)
        {
            await CheckIfApplicationNotExists(id);
            Application application = await _applicationRepository.GetAsync(x => x.Id == id, include: x => x.Include(x => x.Applicant).Include(x => x.Bootcamp).Include(x => x.ApplicationState));
            GetByIdApplicationResponse response = _mapper.Map<GetByIdApplicationResponse>(application);
            return new SuccessDataResult<GetByIdApplicationResponse>(response);
        }

        public async Task<IDataResult<CreateApplicationResponse>> AddAsync(CreateApplicationRequest request)
        {
            await CheckIfApplicantIsBlackList(request.ApplicantId);
            Application application = _mapper.Map<Application>(request);
            await _applicationRepository.AddAsync(application);
            CreateApplicationResponse response = _mapper.Map<CreateApplicationResponse>(application);
            return new SuccessDataResult<CreateApplicationResponse>(response, "Başvuru ekleme başarılı.");
        }

        public async Task<IResult> DeleteAsync(DeleteApplicationRequest request)
        {
            await CheckIfApplicationNotExists(request.Id);
            Application application = _mapper.Map<Application>(request);
            await _applicationRepository.DeleteAsync(application);
            return new SuccessResult("Başvuru silme başarılı.");
        }

        public async Task<IDataResult<UpdateApplicationResponse>> UpdateAsync(UpdateApplicationRequest request)
        {
            await CheckIfApplicationNotExists(request.Id);
            Application application = await _applicationRepository.GetAsync(x => x.Id == request.Id);
            _mapper.Map(request, application);
            await _applicationRepository.UpdateAsync(application);
            UpdateApplicationResponse response = _mapper.Map<UpdateApplicationResponse>(application);
            return new SuccessDataResult<UpdateApplicationResponse>(response, "Güncelleme başarılı");
        }

        private async Task CheckIfApplicantIsBlackList(int applicantId)
        {
            var applicant = await _blackListService.GetByApplicantIdAsync(applicantId);
            if (applicant.Data is not null)
                throw new BusinessException("Applicant is in BlackList");
        }

        private async Task CheckIfApplicationNotExists(int applicationId)
        {
            var isExists = await _blackListService.GetByIdAsync(applicationId);
            if (isExists is not null)
                throw new BusinessException("Application does not exists");
        }
    }
}
