using EMS.Application.Responses;
using EMS.Domain.Abstraction;
using EMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Features.Employees.Command.Update
{
    public sealed record UpdateEmployeeHandler :IRequestHandler<UpdateEmployeeCommand,ResponseOf<UpdateEmployeeResult>>
    {
        private readonly IEmployeeRepository _EMPRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateEmployeeHandler(IEmployeeRepository EMPRepository, IUnitOfWork unitOfWork)
        {
            _EMPRepository = EMPRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseOf<UpdateEmployeeResult>> Handle(
            UpdateEmployeeCommand request,
            CancellationToken cancellationToken
        )
        {
            using (var transaction = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    Employee employee = await _EMPRepository.GetByIdAsync(request.id, cancellationToken);
                    employee.Update(
                        request.FirstName,
                        request.LastName,
                        request.Email,
                        request.Position
                    );
                    // job if discount not null update discount from worker service
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                    await transaction.CommitAsync();
                    return new()
                    {
                        Message = "PROCESS DONE SUCCEFULLY",
                        Success = true,
                        StatusCode = (int)HttpStatusCode.OK,
                        Result = employee,
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
