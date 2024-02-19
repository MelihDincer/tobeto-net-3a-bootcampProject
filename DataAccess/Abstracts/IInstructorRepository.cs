using Core.DataAccess;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface IInstructorRepository : IAsyncRepository<Instructor, int>, IRepository<Instructor, int>
    {
    }
}
