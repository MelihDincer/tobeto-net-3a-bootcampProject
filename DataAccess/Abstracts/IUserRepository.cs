using Core.DataAccess;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface IUserRepository : IAsyncRepository<User, int>
    {
    }
}
