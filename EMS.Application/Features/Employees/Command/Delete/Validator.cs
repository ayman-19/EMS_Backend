using EMS.Domain.Abstraction;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace EMS.Application.Features.Employees.Command.Delete
{
    public  sealed class DeleteEmployeeValidator :AbstractValidator<DeleteEmployeeCommand>
    {
        private readonly IServiceProvider _serviceProvider;

        public DeleteEmployeeValidator(IServiceProvider serviceProvider)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            ClassLevelCascadeMode = CascadeMode.Stop;
            _serviceProvider = serviceProvider;
            var scope = _serviceProvider.CreateScope();
            ValidateRequest(scope.ServiceProvider.GetRequiredService<IEmployeeRepository>());
        }

        private void ValidateRequest(IEmployeeRepository EmployeeRepository)
        {
            RuleFor(e=>e.Id)
                .NotEmpty()
                .WithMessage("ID CANT BE EMPTY")
                .NotNull()
                .WithMessage("ID CANT BE EMPTY")
                .MustAsync(
                    async (id, CancellationToken) =>
                        await EmployeeRepository.IsAnyExistAsync(EMP => EMP.Id == id)
                )
                .WithMessage("EMPLOYEE IS NOT EXIST");
        }

    }
}
