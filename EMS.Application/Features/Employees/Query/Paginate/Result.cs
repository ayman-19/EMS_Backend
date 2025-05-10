namespace EMS.Application.Features.Employees.Query.Paginate
{
    public sealed record PaginateEmployeeResult(
        int Page,
        int PageSize,
        int TotalPage,
        IReadOnlyCollection<EmployeeResult> Employees
    );

    public sealed record EmployeeResult(
        int Id,
        string FirstName,
        string LastName,
        string Email,
        string Position
    );
}
