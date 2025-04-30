using Microsoft.EntityFrameworkCore;
using System.Reflection;
namespace EMS.Persistence.Context
{
    public class EMSDBContext:DbContext
    {
        public EMSDBContext(DbContextOptions<EMSDBContext> options)
           : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
