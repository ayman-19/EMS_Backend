using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Persistence.Context.Configuration
{
    public class EmployeeConfiguration:IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
    
            builder.HasKey(e => e.Id);  
            builder.HasIndex(e => e.Id).IsUnique();
            builder.HasIndex(e => e.Email).IsUnique();
        }
    }
}
