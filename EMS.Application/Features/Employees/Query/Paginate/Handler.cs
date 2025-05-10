using System.Net;
using EMS.Application.Responses;
using EMS.Domain.Abstraction;
using MediatR;

namespace EMS.Application.Features.Employees.Query.Paginate
{
    public sealed class PaginateEmployeeHandler
        : IRequestHandler<PaginateEmployeeQuery, ResponseOf<PaginateEmployeeResult>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public PaginateEmployeeHandler(IEmployeeRepository employeeRepository) =>
            _employeeRepository = employeeRepository;

        public async Task<ResponseOf<PaginateEmployeeResult>> Handle(
            PaginateEmployeeQuery request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                var page = request.page <= 0 ? 1 : request.page;
                var pagesize = request.pageSize <= 0 ? 10 : request.pageSize;

                var result = await _employeeRepository.PaginateAsync(
                    page,
                    pagesize,
                    e => new EmployeeResult(e.Id, e.FirstName, e.LastName, e.Email, e.Position),
                    b => b.Id == request.Id || request.Id == 0,
                    null!,
                    null!,
                    cancellationToken
                );
                return new()
                {
                    Message = "Operation is done successfully",
                    Success = true,
                    StatusCode = (int)HttpStatusCode.OK,
                    Result = new(
                        page,
                        pagesize,
                        (int)Math.Ceiling(result.count / (double)pagesize),
                        result.Item1
                    ),
                };
            }
            catch
            {
                throw new Exception("Occur Exception By Transaction.");
            }
        }
    }
}
