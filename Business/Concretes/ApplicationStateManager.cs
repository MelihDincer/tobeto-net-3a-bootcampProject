using AutoMapper;
using Business.Abstracts;
using Business.Requests.ApplicationStates;
using Business.Responses.ApplicationStates;
using Core.Exceptions.Types;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using static System.Net.Mime.MediaTypeNames;

namespace Business.Concretes
{
    public class ApplicationStateManager : IApplicationStateService
    {
        private readonly IApplicationStateRepository _applicationStateRepository;
        private readonly IMapper _mapper;

        public ApplicationStateManager(IApplicationStateRepository applicaitonStateRepository, IMapper mapper)
        {
            _applicationStateRepository = applicaitonStateRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<GetAllApplicationStateResponse>>> GetAllAsync()
        {
            List<ApplicationState> applicationStates = await _applicationStateRepository.GetAllAsync();
            List<GetAllApplicationStateResponse> responses = _mapper.Map<List<GetAllApplicationStateResponse>>(applicationStates);
            return new SuccessDataResult<List<GetAllApplicationStateResponse>>(responses, "Veriler başarıyla listelendi.");
        }

        public async Task<IDataResult<GetByIdApplicationStateResponse>> GetByIdAsync(int id)
        {
            await CheckIfApplicationStateNotExists(id);
            ApplicationState applicationState = await _applicationStateRepository.GetAsync(x => x.Id == id);
            GetByIdApplicationStateResponse response = _mapper.Map<GetByIdApplicationStateResponse>(applicationState);
            return new SuccessDataResult<GetByIdApplicationStateResponse>(response);
        }

        public async Task<IDataResult<CreateApplicationStateResponse>> AddAsync(CreateApplicationStateRequest request)
        {
            ApplicationState applicationState = _mapper.Map<ApplicationState>(request);
            await _applicationStateRepository.AddAsync(applicationState);
            CreateApplicationStateResponse response = _mapper.Map<CreateApplicationStateResponse>(applicationState);
            return new SuccessDataResult<CreateApplicationStateResponse>(response, "Ekleme işlemi başarılı");
        }

        public async Task<IResult> DeleteAsync(DeleteApplicationStateRequest request)
        {
            await CheckIfApplicationStateNotExists(request.Id);
            ApplicationState applicationState = _mapper.Map<ApplicationState>(request);
            await _applicationStateRepository.DeleteAsync(applicationState);
            return new SuccessResult("Silme işlemi başarılı");
        }

        public async Task<IDataResult<UpdateApplicationStateResponse>> UpdateAsync(UpdateApplicationStateRequest request)
        {
            await CheckIfApplicationStateNotExists(request.Id);
            ApplicationState applicationState = await _applicationStateRepository.GetAsync(x => x.Id == request.Id);
            _mapper.Map(request, applicationState);
            await _applicationStateRepository.UpdateAsync(applicationState);
            UpdateApplicationStateResponse response = _mapper.Map<UpdateApplicationStateResponse>(applicationState);
            return new SuccessDataResult<UpdateApplicationStateResponse>(response, "Güncelleme işlemi başarılı");
        }

        private async Task CheckIfApplicationStateNotExists(int id)
        {
            var isExists = await _applicationStateRepository.GetAsync(a => a.Id == id);
            if (isExists is null)
                throw new BusinessException("ApplicationState does not exists");
        }
    }
}