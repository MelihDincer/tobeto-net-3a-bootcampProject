using Core.DataAccess;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface IApplicationStateRepository : IAsyncRepository<ApplicationState, int>, IRepository<ApplicationState, int>
    {
    }
}
