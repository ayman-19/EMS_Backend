using EMS.Application.Features.Employees.Query.Paginate;
using EMS.Application.Responses;
using FastEndpoints;
using MediatR;

namespace EMS.Api.Endpoints.Employees.Paginate
{
    public class PaginateEndpoint
        : Endpoint<PaginateEmployeeQuery, ResponseOf<PaginateEmployeeResult>>
    {
        public override void Configure()
        {
            Post("employees/paginate");
            AllowAnonymous();
        }

        public override async Task HandleAsync(PaginateEmployeeQuery req, CancellationToken ct)
        {
            Response = await Resolve<ISender>().Send(req, ct);
        }
    }
}
