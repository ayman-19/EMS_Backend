using EMS.Application.Features.Employees.Command.Create;
using EMS.Application.Responses;
using FastEndpoints;
using MediatR;

namespace EMS.Api.Endpoints.Employees.Create
{
    public class CreateEndpoint : Endpoint<CreateEmployeeCommand, ResponseOf<CreateEmployeeResult>>
    {
        public override void Configure()
        {
            Post("employees/add");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateEmployeeCommand req, CancellationToken ct)
        {
            Response = await Resolve<ISender>().Send(req, ct);
        }
    }
}
