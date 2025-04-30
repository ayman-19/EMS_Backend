using EMS.Application.Responses;
using MediatR;

namespace EMS.Application.Features.Employees.Command.Update
{
    public  sealed record UpdateEmployeeCommand(int id ,
        string FirstName,
        string LastName,
        string Email,
        string Position)
        :IRequest<ResponseOf<UpdateEmployeeResult>>;
}
