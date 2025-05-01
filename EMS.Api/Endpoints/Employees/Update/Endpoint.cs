using EMS.Application.Features.Employees.Command.Update;
using EMS.Application.Responses;
using FastEndpoints;
using MediatR;

namespace EMS.Api.Endpoints.Employees.Update
{
    public class UpdateEndpoint : Endpoint<UpdateEmployeeCommand, ResponseOf<UpdateEmployeeResult>>
    {
        public override void Configure()
        {
            Post("Employee/Update");
            AllowAnonymous();
        }

        public override async Task HandleAsync(UpdateEmployeeCommand req, CancellationToken ct)
        {
            Response = await Resolve<ISender>().Send(req, ct);
        }
    }
}
