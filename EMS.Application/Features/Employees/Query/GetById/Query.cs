using EMS.Application.Responses;
using MediatR;
namespace EMS.Application.Features.Employees.Query.GetById
{
    public sealed record GetEmployeeQuery(int Id) :IRequest<ResponseOf<GetEmployeeResult>>;
   
}
