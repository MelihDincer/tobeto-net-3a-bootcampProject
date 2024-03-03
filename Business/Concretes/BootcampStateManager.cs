using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Business.Requests.BootcampStates;
using Business.Responses.BootcampStates;
using Business.Rules;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class BootcampStateManager : IBootcampStateService
    {
        private readonly IBootcampStateRepository _bootcampStateRepository;
        private readonly IMapper _mapper;
        private readonly BootcampStateBusinessRules _rules;

        public BootcampStateManager(IBootcampStateRepository bootcampStateRepository, IMapper mapper, BootcampStateBusinessRules rules)
        {
            _bootcampStateRepository = bootcampStateRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<IDataResult<List<GetAllBootcampStateResponse>>> GetAllAsync()
        {
            List<BootcampState> bootcampStates = await _bootcampStateRepository.GetAllAsync();
            List<GetAllBootcampStateResponse> responses = _mapper.Map<List<GetAllBootcampStateResponse>>(bootcampStates);
            return new SuccessDataResult<List<GetAllBootcampStateResponse>>(responses, BootcampStateMessages.BootcampStatesListed);
        }

        public async Task<IDataResult<GetByIdBootcampStateResponse>> GetByIdAsync(int id)
        {
            await _rules.CheckIfBootcampStateNotExists(id);
            BootcampState bootcampState = await _bootcampStateRepository.GetAsync(x => x.Id == id);
            GetByIdBootcampStateResponse response = _mapper.Map<GetByIdBootcampStateResponse>(bootcampState);
            return new SuccessDataResult<GetByIdBootcampStateResponse>(response);
        }

        public async Task<IDataResult<CreateBootcampStateResponse>> AddAsync(CreateBootcampStateRequest request)
        {
            await _rules.CheckBootcampStateNameIfExist(request.Name);
            BootcampState bootcampState = _mapper.Map<BootcampState>(request);
            await _bootcampStateRepository.AddAsync(bootcampState);
            CreateBootcampStateResponse response = _mapper.Map<CreateBootcampStateResponse>(bootcampState);
            return new SuccessDataResult<CreateBootcampStateResponse>(response, BootcampStateMessages.BootcampStateAdded);
        }

        public async Task<IResult> DeleteAsync(DeleteBootcampStateRequest request)
        {
            await _rules.CheckIfBootcampStateNotExists(request.Id);
            BootcampState bootcamp = _mapper.Map<BootcampState>(request);
            await _bootcampStateRepository.DeleteAsync(bootcamp);
            return new SuccessResult(BootcampStateMessages.BootcampStateDeleted);
        }

        public async Task<IDataResult<UpdateBootcampStateResponse>> UpdateAsync(UpdateBootcampStateRequest request)
        {
            await _rules.CheckIfBootcampStateNotExists(request.Id);
            await _rules.CheckBootcampStateNameIfExist(request.Name);
            BootcampState bootcampState = await _bootcampStateRepository.GetAsync(x=>x.Id == request.Id);
            _mapper.Map(request, bootcampState);
            await _bootcampStateRepository.UpdateAsync(bootcampState);
            UpdateBootcampStateResponse response = _mapper.Map<UpdateBootcampStateResponse>(bootcampState);
            return new SuccessDataResult<UpdateBootcampStateResponse>(response, BootcampStateMessages.BootcampStateUpdated);
        }
    }
}
