using Core.DataAccess;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface IBootcampRepository : IAsyncRepository<Bootcamp, int>, IRepository<Bootcamp, int>
    {
    }
}
