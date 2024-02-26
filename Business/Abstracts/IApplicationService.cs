using Business.Requests.Applications;
using Business.Responses.Applications;
using Core.Utilities.Results;

namespace Business.Abstracts
{
    public interface IApplicationService 
    {
        Task<IDataResult<List<GetAllApplicationResponse>>> GetAllAsync();
        Task<IDataResult<GetByIdApplicationResponse>> GetByIdAsync(int id);
        Task<IDataResult<CreateApplicationResponse>> AddAsync(CreateApplicationRequest request);
        Task<IResult> DeleteAsync(DeleteApplicationRequest request);
        Task<IDataResult<UpdateApplicationResponse>> UpdateAsync(UpdateApplicationRequest request);
    }
}
