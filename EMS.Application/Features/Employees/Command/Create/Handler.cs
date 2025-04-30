using System.Net;
using EMS.Application.Responses;
using EMS.Domain.Abstraction;
using EMS.Domain.Entities;
using MediatR;

namespace EMS.Application.Features.Employees.Command.Create
{
    public sealed record CreateEmployeeHandler
        : IRequestHandler<CreateEmployeeCommand, ResponseOf<CreateEmployeeResult>>
    {
        private readonly IEmployeeRepository _EMPRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateEmployeeHandler(IEmployeeRepository EMPRepository, IUnitOfWork unitOfWork)
        {
            _EMPRepository = EMPRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseOf<CreateEmployeeResult>> Handle(
            CreateEmployeeCommand request,
            CancellationToken cancellationToken
        )
        {
            using (var transaction = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    Employee book = request;
                    await _EMPRepository.CreateAsync(book, cancellationToken);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                    await transaction.CommitAsync(cancellationToken);
                    return new()
                    {
                        Message = "operation done successfully",
                        Success = true,
                        StatusCode = (int)HttpStatusCode.OK,
                        Result = book,
                    };
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    throw new Exception(ex.Message, ex);
                }
            }
        }
    }
}
