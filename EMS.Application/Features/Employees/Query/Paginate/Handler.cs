using EMS.Application.Responses;
using EMS.Domain.Abstraction;
using MediatR;
using System.Net;
namespace EMS.Application.Features.Employees.Query.Paginate
{
    public sealed class PaginateEmployeeHandler:
       IRequestHandler<PaginateEmployeeQuery,
        ResponseOf<IReadOnlyCollection<PaginateEmployeeResult>>>
      
    {
        private readonly IEmployeeRepository _employeeRepository;

        public PaginateEmployeeHandler(IEmployeeRepository employeeRepository) =>
           _employeeRepository = employeeRepository;

        public async Task<ResponseOf<IReadOnlyCollection<PaginateEmployeeResult>>> Handle(
            PaginateEmployeeQuery request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                IReadOnlyCollection<PaginateEmployeeResult>? result =
                    await _employeeRepository.PaginateAsync(
                        request.page <= 0 ? 1 : request.page,
                        request.pageSize <= 0 ? 10 : request.pageSize,
                        e => new PaginateEmployeeResult(e.Id,e.FirstName,e.LastName,e.Email,e.Position),
                        b => b.Id == request.Id || request.Id == null,
                        null!,
                        null!,
                        cancellationToken
                    );
                return new()
                {
                    Message ="Operation is done successfully",
                    Success = true,
                    StatusCode = (int)HttpStatusCode.OK,
                    Result = result,
                };
            }
            catch
            {
                throw new Exception("Occur Exception By Transaction.");
            }
        }
    }
}
