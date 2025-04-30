using EMS.Application.Responses;
using EMS.Domain.Entities;
using MediatR;

namespace EMS.Application.Features.Employees.Command.Create
{
    public sealed record CreateEmployeeCommand(
        string FirstName,
        string LastName,
        string Email,
        String Position
    ) : IRequest<ResponseOf<CreateEmployeeResult>>
    {
        public static implicit operator Employee(CreateEmployeeCommand createEmployeeCommand) =>
            Employee.Create(
                createEmployeeCommand.FirstName,
                createEmployeeCommand.LastName,
                createEmployeeCommand.Email,
                createEmployeeCommand.Position
            );
    }
}
