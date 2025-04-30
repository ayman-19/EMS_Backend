using EMS.Application.Responses;
using EMS.Domain.Abstraction;
using MediatR;
using System.Net;
namespace EMS.Application.Features.Employees.Query.GetById
{
    public sealed class GetEmployeeHandler:
        IRequestHandler<GetEmployeeQuery,ResponseOf<GetEmployeeResult>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetEmployeeHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseOf<GetEmployeeResult>> Handle(
            GetEmployeeQuery request,
            CancellationToken cancellationToken
        )
        {
            using (var transaction = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    var result = await _employeeRepository.GetAsync(
                        e => e.Id == request.Id,
                        e => new GetEmployeeResult(e.Id, e.FirstName, e.LastName, e.Email, e.Position),
                        null!,
                        false,
                        cancellationToken
                    );
                    return new()
                    {
                        Message = "Process is done successfully",
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
}
