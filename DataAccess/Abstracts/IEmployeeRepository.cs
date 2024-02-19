using Core.DataAccess;
using Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface IEmployeeRepository : IAsyncRepository<Employee, int>, IRepository<Employee, int>
    {
    }
}
