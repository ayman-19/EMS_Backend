using EMS.Application.Features.Employees.Command.Delete;
using EMS.Application.Responses;
using FastEndpoints;
using MediatR;

namespace EMS.Api.Endpoints.Employees.Delete
{
    public class DeleteCategory : Endpoint<EmptyRequest, Response>
    {
        public override void Configure()
        {
            Delete("Employee/Delete/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
        {
            int id = Route<int>("id");
            Response = await Resolve<ISender>().Send(new DeleteEmployeeCommand(id), ct);
        }
    }
}
