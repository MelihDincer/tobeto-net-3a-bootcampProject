using AutoMapper;
using Business.Abstracts;
using Business.Requests.BlackLists;
using Business.Responses.BlackLists;
using Core.Exceptions.Types;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class BlackListManager : IBlackListService
    {
        private readonly IBlackListRepository _blackListRepository;
        private readonly IMapper _mapper;

        public BlackListManager(IBlackListRepository blackListRepository, IMapper mapper)
        {
            _blackListRepository = blackListRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<CreateBlackListResponse>> CreateAsync(CreateBlackListRequest request)
        {
            BlackList blackList = _mapper.Map<BlackList>(request);
            await _blackListRepository.AddAsync(blackList);
            CreateBlackListResponse response = _mapper.Map<CreateBlackListResponse>(blackList);
            return new SuccessDataResult<CreateBlackListResponse>(response, "Başarıyla eklendi.");
        }

        public async Task<IResult> DeleteAsync(DeleteBlackListRequest request)
        {
            await CheckIfBlackListNotExists(request.Id);
            BlackList blackList = await _blackListRepository.GetAsync(b => b.Id == request.Id);
            await _blackListRepository.DeleteAsync(blackList);
            return new SuccessResult("Başarıyla silindi.");
        }

        public async Task<IDataResult<List<GetAllBlackListResponse>>> GetAllAsync()
        {
            List<BlackList> blackLists = await _blackListRepository.GetAllAsync();
            List<GetAllBlackListResponse> responses = _mapper.Map<List<GetAllBlackListResponse>>(blackLists);
            return new SuccessDataResult<List<GetAllBlackListResponse>>(responses, "Listeleme başarılı.");
        }

        public async Task<IDataResult<GetByApplicantIdBlackListResponse>> GetByApplicantIdAsync(int applicantId)
        {
            BlackList blackList = await _blackListRepository.GetAsync(x => x.ApplicantId == applicantId);
            GetByApplicantIdBlackListResponse response = _mapper.Map<GetByApplicantIdBlackListResponse>(blackList);
            return new SuccessDataResult<GetByApplicantIdBlackListResponse>(response);
        }

        public async Task<IDataResult<GetByIdBlackListResponse>> GetByIdAsync(int id)
        {
            await CheckIfBlackListNotExists(id);
            BlackList blackList = await _blackListRepository.GetAsync(x => x.Id == id);
            GetByIdBlackListResponse response = _mapper.Map<GetByIdBlackListResponse>(blackList);
            return new SuccessDataResult<GetByIdBlackListResponse>(response);
        }

        public async Task<IDataResult<UpdateBlackListResponse>> UpdateAsync(UpdateBlackListRequest request)
        {
            await CheckIfBlackListNotExists(request.Id);
            BlackList blackList = await _blackListRepository.GetAsync(x => x.Id == request.Id);
            _mapper.Map(request, blackList);
            await _blackListRepository.UpdateAsync(blackList);
            UpdateBlackListResponse response = _mapper.Map<UpdateBlackListResponse>(blackList);
            return new SuccessDataResult<UpdateBlackListResponse>(response, "Başarıyla güncellendi.");
        }

        private async Task CheckIfBlackListNotExists(int id)
        {
            var isExists = await _blackListRepository.GetAsync(a => a.Id == id);
            if (isExists is null)
                throw new BusinessException("Applicant does not exists");
        }
    }
}