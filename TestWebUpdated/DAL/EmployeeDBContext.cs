using Microsoft.EntityFrameworkCore;
using TestWebUpdated.Models.DBEntities;

namespace TestWebUpdated.DAL
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
    }
}
