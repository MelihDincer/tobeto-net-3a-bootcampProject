using AutoMapper;
using Business.Abstracts;
using Business.Requests.BootcampStates;
using Business.Responses.BootcampStates;
using Core.Utilities.Results;
using DataAccess.Abstracts;
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

        public async Task<IDataResult<CreateBootcampStateResponse>> AddAsync(CreateBootcampStateRequest request)
        {
            BootcampState bootcampState = _mapper.Map<BootcampState>(request);
            await _bootcampStateRepository.AddAsync(bootcampState);
            CreateBootcampStateResponse response = _mapper.Map<CreateBootcampStateResponse>(bootcampState);
            return new SuccessDataResult<CreateBootcampStateResponse>(response, "Ekleme işlemi başarılı");
        }

        public async Task<IDataResult<DeleteBootcampStateResponse>> DeleteAsync(DeleteBootcampStateRequest request)
        {
            BootcampState bootcamp = _mapper.Map<BootcampState>(request);
            await _bootcampStateRepository.DeleteAsync(bootcamp);
            DeleteBootcampStateResponse response = _mapper.Map<DeleteBootcampStateResponse>(bootcamp);
            return new SuccessDataResult<DeleteBootcampStateResponse>(response, "Silme işlemi başarılı");
        }

        public async Task<IDataResult<List<GetAllBootcampStateResponse>>> GetAllAsync()
        {
            List<BootcampState> bootcampStates = await _bootcampStateRepository.GetAllAsync();
            List<GetAllBootcampStateResponse> responses = _mapper.Map<List<GetAllBootcampStateResponse>>(bootcampStates);
            return new SuccessDataResult<List<GetAllBootcampStateResponse>>(responses, "Listeleme başarılı");
        }

        public async Task<IDataResult<GetByIdBootcampStateResponse>> GetByIdAsync(int id)
        {
            BootcampState bootcampState = await _bootcampStateRepository.GetAsync(x => x.Id == id);
            GetByIdBootcampStateResponse response = _mapper.Map<GetByIdBootcampStateResponse>(bootcampState);
            return new SuccessDataResult<GetByIdBootcampStateResponse>(response);
        }

        public async Task<IDataResult<UpdateBootcampStateResponse>> UpdateAsync(UpdateBootcampStateRequest request)
        {
            BootcampState bootcampState = await _bootcampStateRepository.GetAsync(x=>x.Id == request.Id);
            _mapper.Map(request, bootcampState);
            await _bootcampStateRepository.UpdateAsync(bootcampState);
            UpdateBootcampStateResponse response = _mapper.Map<UpdateBootcampStateResponse>(bootcampState);
            return new SuccessDataResult<UpdateBootcampStateResponse>(response, "Güncelleme işlemi başarılı");
        }
    }
}
