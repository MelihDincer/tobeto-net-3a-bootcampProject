using Business.Requests.BlackLists;
using Business.Responses.BlackLists;
using Core.Utilities.Results;

namespace Business.Abstracts
{
    public interface IBlackListService
    {
        Task<IDataResult<List<GetAllBlackListResponse>>> GetAllAsync();
        Task<IDataResult<GetByIdBlackListResponse>> GetByIdAsync(int id);
        Task<IDataResult<GetByApplicantIdBlackListResponse>> GetByApplicantIdAsync(int applicantId);
        Task<IDataResult<CreateBlackListResponse>> CreateAsync(CreateBlackListRequest request);
        Task<IResult> DeleteAsync(DeleteBlackListRequest request);
        Task<IDataResult<UpdateBlackListResponse>> UpdateAsync(UpdateBlackListRequest request);
        Task<IDataResult<GetByApplicantIdBlackListResponse>> CheckIfApplicantIdBlackList(int applicantId);
    }
}
