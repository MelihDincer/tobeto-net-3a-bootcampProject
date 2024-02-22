using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities.Concretes;

namespace DataAccess.Repositories
{
    public class BootcampStateRepository : EfRepositoryBase<BootcampState, int, BaseDbContext>, IBootcampStateRepository
    {
        public BootcampStateRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
