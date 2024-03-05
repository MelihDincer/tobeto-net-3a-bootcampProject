using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Business.Requests.BlackLists;
using Business.Responses.BlackLists;
using Business.Rules;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class BlackListManager : IBlackListService
    {
        private readonly IBlackListRepository _blackListRepository;
        private readonly IMapper _mapper;
        private readonly BlackListBusinessRules _rules;

        public BlackListManager(IBlackListRepository blackListRepository, IMapper mapper, BlackListBusinessRules rules)
        {
            _blackListRepository = blackListRepository;
            _mapper = mapper;
            _rules = rules;
        }

        public async Task<IDataResult<GetByApplicantIdBlackListResponse>> CheckIfApplicantIdBlackList(int applicantId)
        {
            BlackList blackList = await _blackListRepository.GetAsync(x => x.ApplicantId == applicantId);
            GetByApplicantIdBlackListResponse response = _mapper.Map<GetByApplicantIdBlackListResponse>(blackList);
            return new SuccessDataResult<GetByApplicantIdBlackListResponse>(response);
        }

        public async Task<IDataResult<CreateBlackListResponse>> CreateAsync(CreateBlackListRequest request)
        {
            await _rules.CheckIfApplicantNotExists(request.ApplicantId);
            BlackList blackList = _mapper.Map<BlackList>(request);
            await _blackListRepository.AddAsync(blackList);
            CreateBlackListResponse response = _mapper.Map<CreateBlackListResponse>(blackList);
            return new SuccessDataResult<CreateBlackListResponse>(response, BlacklistMessages.BlacklistAdded);
        }

        public async Task<IResult> DeleteAsync(DeleteBlackListRequest request)
        {
            await _rules.CheckIfBlackListNotExists(request.Id);
            BlackList blackList = await _blackListRepository.GetAsync(b => b.Id == request.Id);
            await _blackListRepository.DeleteAsync(blackList);
            return new SuccessResult(BlacklistMessages.BlacklistDeleted);
        }

        public async Task<IDataResult<List<GetAllBlackListResponse>>> GetAllAsync()
        {
            List<BlackList> blackLists = await _blackListRepository.GetAllAsync(include: x => x.Include(x => x.Applicant));
            List<GetAllBlackListResponse> responses = _mapper.Map<List<GetAllBlackListResponse>>(blackLists);
            return new SuccessDataResult<List<GetAllBlackListResponse>>(responses, BlacklistMessages.BlacklistsListed);
        }

        public async Task<IDataResult<GetByApplicantIdBlackListResponse>> GetByApplicantIdAsync(int applicantId)
        {
            await _rules.CheckIfApplicantExists(applicantId);
            BlackList blackList = await _blackListRepository.GetAsync(x => x.ApplicantId == applicantId, include: x => x.Include(x => x.Applicant));
            GetByApplicantIdBlackListResponse response = _mapper.Map<GetByApplicantIdBlackListResponse>(blackList);
            return new SuccessDataResult<GetByApplicantIdBlackListResponse>(response);
        }

        public async Task<IDataResult<GetByIdBlackListResponse>> GetByIdAsync(int id)
        {
            await _rules.CheckIfBlackListNotExists(id);
            BlackList blackList = await _blackListRepository.GetAsync(x => x.Id == id, include: x => x.Include(x => x.Applicant));
            GetByIdBlackListResponse response = _mapper.Map<GetByIdBlackListResponse>(blackList);
            return new SuccessDataResult<GetByIdBlackListResponse>(response);
        }

        public async Task<IDataResult<UpdateBlackListResponse>> UpdateAsync(UpdateBlackListRequest request)
        {
            await _rules.CheckIfBlackListNotExists(request.Id);
            BlackList blackList = await _blackListRepository.GetAsync(x => x.Id == request.Id, include: x => x.Include(x => x.Applicant));
            _mapper.Map(request, blackList);
            await _blackListRepository.UpdateAsync(blackList);
            UpdateBlackListResponse response = _mapper.Map<UpdateBlackListResponse>(blackList);
            return new SuccessDataResult<UpdateBlackListResponse>(response, BlacklistMessages.BlacklistUpdated);
        }
    }
}