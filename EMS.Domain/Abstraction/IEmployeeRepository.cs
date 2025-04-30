using EMS.Domain.Entities;

namespace EMS.Domain.Abstraction
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        Task DeleteByIdAsync(int id, CancellationToken cancellationToken);
        ValueTask<Employee> GetByIdAsync(int Id, CancellationToken cancellationToken);
    }
}
