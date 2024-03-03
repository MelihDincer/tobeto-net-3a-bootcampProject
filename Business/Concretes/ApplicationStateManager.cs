using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Business.Requests.ApplicationStates;
using Business.Responses.ApplicationStates;
using Business.Rules;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class ApplicationStateManager : IApplicationStateService
    {
        private readonly IApplicationStateRepository _applicationStateRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationStateBusinessRules _rules;

        public ApplicationStateManager(IApplicationStateRepository applicaitonStateRepository, IMapper mapper, ApplicationStateBusinessRules rules)
        {
            _applicationStateRepository = applicaitonStateRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<IDataResult<List<GetAllApplicationStateResponse>>> GetAllAsync()
        {
            List<ApplicationState> applicationStates = await _applicationStateRepository.GetAllAsync();
            List<GetAllApplicationStateResponse> responses = _mapper.Map<List<GetAllApplicationStateResponse>>(applicationStates);
            return new SuccessDataResult<List<GetAllApplicationStateResponse>>(responses, ApplicationStateMessages.ApplicationStatesListed);
        }

        public async Task<IDataResult<GetByIdApplicationStateResponse>> GetByIdAsync(int id)
        {
            await _rules.CheckIfApplicationStateNotExists(id);
            ApplicationState applicationState = await _applicationStateRepository.GetAsync(x => x.Id == id);
            GetByIdApplicationStateResponse response = _mapper.Map<GetByIdApplicationStateResponse>(applicationState);
            return new SuccessDataResult<GetByIdApplicationStateResponse>(response);
        }

        public async Task<IDataResult<CreateApplicationStateResponse>> AddAsync(CreateApplicationStateRequest request)
        {
            await _rules.CheckApplicationStateNameIfExist(request.Name);
            ApplicationState applicationState = _mapper.Map<ApplicationState>(request);
            await _applicationStateRepository.AddAsync(applicationState);
            CreateApplicationStateResponse response = _mapper.Map<CreateApplicationStateResponse>(applicationState);
            return new SuccessDataResult<CreateApplicationStateResponse>(response, ApplicationStateMessages.ApplicationStateAdded);
        }

        public async Task<IResult> DeleteAsync(DeleteApplicationStateRequest request)
        {
            await _rules.CheckIfApplicationStateNotExists(request.Id);
            ApplicationState applicationState = _mapper.Map<ApplicationState>(request);
            await _applicationStateRepository.DeleteAsync(applicationState);
            return new SuccessResult(ApplicationStateMessages.ApplicationStateDeleted);
        }

        public async Task<IDataResult<UpdateApplicationStateResponse>> UpdateAsync(UpdateApplicationStateRequest request)
        {
            await _rules.CheckIfApplicationStateNotExists(request.Id);
            await _rules.CheckApplicationStateNameIfExist(request.Name);
            ApplicationState applicationState = await _applicationStateRepository.GetAsync(x => x.Id == request.Id);
            _mapper.Map(request, applicationState);
            await _applicationStateRepository.UpdateAsync(applicationState);
            UpdateApplicationStateResponse response = _mapper.Map<UpdateApplicationStateResponse>(applicationState);
            return new SuccessDataResult<UpdateApplicationStateResponse>(response, ApplicationStateMessages.ApplicationStateUpdated);
        }
    }
}