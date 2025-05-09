﻿using EMS.Domain.Abstraction;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace EMS.Application.Features.Employees.Command.Update
{
    public sealed class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        private readonly IServiceProvider _serviceProvider;

        public UpdateEmployeeValidator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            RuleLevelCascadeMode = CascadeMode.Stop;
            ClassLevelCascadeMode = CascadeMode.Stop;

            _serviceProvider = serviceProvider;
            var scope = _serviceProvider.CreateScope();
            ValidateRequest(scope.ServiceProvider.GetRequiredService<IEmployeeRepository>());
        }

        private void ValidateRequest(IEmployeeRepository employeeRepository)
        {
            RuleFor(e => e.id)
                .NotEmpty()
                .WithMessage(" ID MUST NOT BE EMPTY")
                .NotNull()
                .WithMessage("ID NAME MUST NOT BE EMPTY");

            RuleFor(e => e.FirstName)
                .NotEmpty()
                .WithMessage("FIRST NAME MUST NOT BE EMPTY")
                .NotNull()
                .WithMessage("FIRST NAME MUST NOT BE EMPTY");

            RuleFor(e => e.LastName)
                .NotEmpty()
                .WithMessage("LAST NAME MUST NOT BE EMPTY")
                .NotNull()
                .WithMessage("LAST NAME MUST NOT BE EMPTY");

            RuleFor(e => e.Email)
                .NotEmpty()
                .WithMessage("Email MUST NOT BE EMPTY")
                .NotNull()
                .WithMessage("Email MUST NOT BE EMPTY");

            RuleFor(e => e)
                .MustAsync(
                    async (req, cancellationToken) =>
                        !await employeeRepository.IsAnyExistAsync(e =>
                            e.Email == req.Email && e.Id != req.id
                        )
                )
                .WithMessage("Email IS EXIST.");

            RuleFor(e => e.Position)
                .NotEmpty()
                .WithMessage("Position MUST NOT BE EMPTY")
                .NotNull()
                .WithMessage("Position MUST NOT BE EMPTY");
        }
    }
}
