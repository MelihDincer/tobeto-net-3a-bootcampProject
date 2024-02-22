using Core.DataAccess;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface IBootcampStateRepository : IAsyncRepository<BootcampState, int>, IRepository<BootcampState, int>
    {
    }
}
