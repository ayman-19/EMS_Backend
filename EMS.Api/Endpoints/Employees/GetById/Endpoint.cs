using EMS.Application.Features.Employees.Query.GetById;
using EMS.Application.Responses;
using FastEndpoints;
using MediatR;

namespace EMS.Api.Endpoints.Employees.GetById
{
    public class Endpoint
    {
        public class GetByIdEndpoint : Endpoint<EmptyRequest, ResponseOf<GetEmployeeResult>>
        {
            public override void Configure()
            {
                Get("Employee/GetById/{id}");
                AllowAnonymous();
            }

            public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
            {
                int id = Route<int>("id");
                Response = await Resolve<ISender>().Send(new GetEmployeeQuery(id), ct);
            }
        }
    }
}
