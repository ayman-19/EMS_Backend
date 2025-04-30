using EMS.Domain.Entities;
namespace EMS.Application.Features.Employees.Command.Update
{
public sealed record UpdateEmployeeResult(
        int id ,
        string FirstName,
        string LastName,
        string Email,
        string Position)
    {
        public static implicit operator UpdateEmployeeResult(Employee emp) =>
            new(emp.Id, emp.FirstName, emp.LastName, emp.Email, emp.Position);
    }
}
