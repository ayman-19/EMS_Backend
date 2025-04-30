using EMS.Domain.Entities;

namespace EMS.Application.Features.Employees.Command.Create
{
    public sealed record CreateEmployeeResult(
        int Id,
        string FirstName,
        string LastName,
        string Position
    )
    {
        public static implicit operator CreateEmployeeResult(Employee emp) =>
            new(emp.Id, emp.FirstName, emp.LastName, emp.Position);
    }
}
