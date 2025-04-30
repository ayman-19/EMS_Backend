using EMS.Domain.Abstraction;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace EMS.Application.Features.Employees.Command.Create
{
    public sealed class CreateEmployeeValidator : AbstractValidator<CreateEmployeeCommand>
    {
        private readonly IServiceProvider _serviceProvider;

        public CreateEmployeeValidator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            RuleLevelCascadeMode = CascadeMode.Stop;
            ClassLevelCascadeMode = CascadeMode.Stop;

            _serviceProvider = serviceProvider;
            var scope = _serviceProvider.CreateScope();
            ValidateRequest(scope.ServiceProvider.GetRequiredService<IEmployeeRepository>());
        }

        private void ValidateRequest(IEmployeeRepository branchRepository)
        {
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

            RuleFor(e => e.Position)
                .NotEmpty()
                .WithMessage("Position MUST NOT BE EMPTY")
                .NotNull()
                .WithMessage("Position MUST NOT BE EMPTY");
        }
    }
}
