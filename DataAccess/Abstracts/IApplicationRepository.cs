using Core.DataAccess;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface IApplicationRepository : IAsyncRepository<Application, int>, IRepository<Application, int>
    {
    }
}
