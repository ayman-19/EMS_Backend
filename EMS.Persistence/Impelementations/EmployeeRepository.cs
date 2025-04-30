using EMS.Domain.Abstraction;
using EMS.Domain.Entities;
using EMS.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EMS.Persistence.Impelementations
{
    public sealed class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly EMSDBContext _context;

        public EmployeeRepository(EMSDBContext context) : base(context)
        {
            _context = context;
        }

        public async ValueTask<Employee> GetByIdAsync(int Id, CancellationToken cancellationToken) =>
            await _context
                .Set<Employee>()
                .AsTracking()
                .FirstAsync(id => id.Id == Id, cancellationToken);

        public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken) =>
            await _context
                .Set<Employee>()
                .Where(s => s.Id == id)
                .ExecuteDeleteAsync(cancellationToken);

    }
}
