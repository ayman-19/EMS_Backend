using EMS.Application.Responses;
using MediatR;

namespace EMS.Application.Features.Employees.Query.Paginate
{
    public sealed record PaginateEmployeeQuery(int page, int pageSize, int? Id)
        : IRequest<ResponseOf<PaginateEmployeeResult>>;
}
