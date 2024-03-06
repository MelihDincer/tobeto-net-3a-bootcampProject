using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Business.Requests.Applications;
using Business.Responses.Applications;
using Business.Rules;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
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
        private readonly ApplicationBusinessRules _rules;

        public ApplicationManager(IApplicationRepository applicationRepository, IMapper mapper, ApplicationBusinessRules rules)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
            _rules = rules;
        }

        [LogAspect(typeof(MongoDbLogger))]
        public async Task<IDataResult<List<GetAllApplicationResponse>>> GetAllAsync()
        {
            List<Application> applications = await _applicationRepository.GetAllAsync(include: x => x.Include(x => x.Applicant).Include(x => x.Bootcamp).Include(x => x.ApplicationState));
            List<GetAllApplicationResponse> responses = _mapper.Map<List<GetAllApplicationResponse>>(applications);
            return new SuccessDataResult<List<GetAllApplicationResponse>>(responses, ApplicationMessages.ApplicationListed);
        }

        public async Task<IDataResult<GetByIdApplicationResponse>> GetByIdAsync(int id)
        {
            await _rules.CheckIfApplicationNotExists(id);
            Application application = await _applicationRepository.GetAsync(x => x.Id == id, include: x => x.Include(x => x.Applicant).Include(x => x.Bootcamp).Include(x => x.ApplicationState));
            GetByIdApplicationResponse response = _mapper.Map<GetByIdApplicationResponse>(application);
            return new SuccessDataResult<GetByIdApplicationResponse>(response);
        }

        [LogAspect(typeof(MongoDbLogger))]
        public async Task<IDataResult<CreateApplicationResponse>> AddAsync(CreateApplicationRequest request)
        {
            await _rules.CheckIfApplicantIsBlackList(request.ApplicantId);
            await _rules.CheckIfApplicantNotExists(request.ApplicantId);
            await _rules.CheckIfBootcampNotExists(request.BootcampId);
            await _rules.CheckIfApplicationStateNotExists(request.ApplicationStateId);
            await _rules.CheckIfApplicantBootcampNotExists(request.ApplicantId, request.BootcampId);
            Application application = _mapper.Map<Application>(request);
            await _applicationRepository.AddAsync(application);
            CreateApplicationResponse response = _mapper.Map<CreateApplicationResponse>(application);
            return new SuccessDataResult<CreateApplicationResponse>(response, ApplicationMessages.ApplicationAdded);
        }

        public async Task<IResult> DeleteAsync(DeleteApplicationRequest request)
        {
            await _rules.CheckIfApplicationNotExists(request.Id);
            Application application = await _applicationRepository.GetAsync(a => a.Id == request.Id);
            await _applicationRepository.DeleteAsync(application);
            return new SuccessResult("Başvuru silme başarılı.");
        }

        public async Task<IDataResult<UpdateApplicationResponse>> UpdateAsync(UpdateApplicationRequest request)
        {
            await _rules.CheckIfApplicationNotExists(request.Id);
            await _rules.CheckIfApplicantIsBlackList(request.ApplicantId);
            await _rules.CheckIfApplicantNotExists(request.ApplicantId);
            await _rules.CheckIfBootcampNotExists(request.BootcampId);
            await _rules.CheckIfApplicationStateNotExists(request.ApplicationStateId);
            await _rules.CheckIfApplicantBootcampNotExists(request.ApplicantId, request.BootcampId);
            Application application = await _applicationRepository.GetAsync(x => x.Id == request.Id, include: x => x.Include(x => x.Applicant).Include(x => x.Bootcamp).Include(x => x.ApplicationState));
            _mapper.Map(request, application);
            await _applicationRepository.UpdateAsync(application);
            UpdateApplicationResponse response = _mapper.Map<UpdateApplicationResponse>(application);
            return new SuccessDataResult<UpdateApplicationResponse>(response, ApplicationMessages.ApplicationUpdated);
        }
    }
}