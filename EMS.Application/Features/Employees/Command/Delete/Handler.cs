﻿using EMS.Application.Responses;
using EMS.Domain.Abstraction;
using MediatR;
using System.Net;

namespace EMS.Application.Features.Employees.Command.Delete
{
    public sealed record DeleteEmployeeHandler :IRequestHandler<DeleteEmployeeCommand,Response>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEmployeeHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(
            DeleteEmployeeCommand request,
            CancellationToken cancellationToken
        )
        {
            using (var transaction = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    await _employeeRepository.DeleteByIdAsync(request.Id, cancellationToken);
                    await transaction.CommitAsync();
                    return new()
                    {
                        Message = "operation done successfully",
                        Success = true,
                        StatusCode = (int)HttpStatusCode.OK,
                    };
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
