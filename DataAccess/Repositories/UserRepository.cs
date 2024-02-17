using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class UserRepository : EfRepositoryBase<User, int, BaseDbContext>, IUserRepository
    {
        protected readonly BaseDbContext _context;
        public UserRepository(BaseDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
