using AutoMapper;
using Business.Abstracts;
using Business.Requests.BootcampStates;
using Business.Responses.BootcampStates;
using Core.Exceptions.Types;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Repositories;
using Entities.Concretes;

namespace Business.Concretes
{
    public class BootcampStateManager : IBootcampStateService
    {
        private readonly IBootcampStateRepository _bootcampStateRepository;
        private readonly IMapper _mapper;

        public BootcampStateManager(IBootcampStateRepository bootcampStateRepository, IMapper mapper)
        {
            _bootcampStateRepository = bootcampStateRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<GetAllBootcampStateResponse>>> GetAllAsync()
        {
            List<BootcampState> bootcampStates = await _bootcampStateRepository.GetAllAsync();
            List<GetAllBootcampStateResponse> responses = _mapper.Map<List<GetAllBootcampStateResponse>>(bootcampStates);
            return new SuccessDataResult<List<GetAllBootcampStateResponse>>(responses, "Listeleme başarılı");
        }

        public async Task<IDataResult<GetByIdBootcampStateResponse>> GetByIdAsync(int id)
        {
            await CheckIfBootcampStateNotExists(id);
            BootcampState bootcampState = await _bootcampStateRepository.GetAsync(x => x.Id == id);
            GetByIdBootcampStateResponse response = _mapper.Map<GetByIdBootcampStateResponse>(bootcampState);
            return new SuccessDataResult<GetByIdBootcampStateResponse>(response);
        }

        public async Task<IDataResult<CreateBootcampStateResponse>> AddAsync(CreateBootcampStateRequest request)
        {
            BootcampState bootcampState = _mapper.Map<BootcampState>(request);
            await _bootcampStateRepository.AddAsync(bootcampState);
            CreateBootcampStateResponse response = _mapper.Map<CreateBootcampStateResponse>(bootcampState);
            return new SuccessDataResult<CreateBootcampStateResponse>(response, "Ekleme işlemi başarılı");
        }

        public async Task<IResult> DeleteAsync(DeleteBootcampStateRequest request)
        {
            await CheckIfBootcampStateNotExists(request.Id);
            BootcampState bootcamp = _mapper.Map<BootcampState>(request);
            await _bootcampStateRepository.DeleteAsync(bootcamp);
            return new SuccessResult("Silme işlemi başarılı");
        }

        public async Task<IDataResult<UpdateBootcampStateResponse>> UpdateAsync(UpdateBootcampStateRequest request)
        {
            await CheckIfBootcampStateNotExists(request.Id);
            BootcampState bootcampState = await _bootcampStateRepository.GetAsync(x=>x.Id == request.Id);
            _mapper.Map(request, bootcampState);
            await _bootcampStateRepository.UpdateAsync(bootcampState);
            UpdateBootcampStateResponse response = _mapper.Map<UpdateBootcampStateResponse>(bootcampState);
            return new SuccessDataResult<UpdateBootcampStateResponse>(response, "Güncelleme işlemi başarılı");
        }

        private async Task CheckIfBootcampStateNotExists(int id)
        {
            var isExists = await _bootcampStateRepository.GetAsync(a => a.Id == id);
            if (isExists is not null)
                throw new BusinessException("BootcampState does not exists");
        }
    }
}
