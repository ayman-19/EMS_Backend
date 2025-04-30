using EMS.Application.Responses;
using MediatR;
namespace EMS.Application.Features.Employees.Command.Delete
{
    public sealed record DeleteEmployeeCommand(int Id):IRequest<Response>;
    
}
