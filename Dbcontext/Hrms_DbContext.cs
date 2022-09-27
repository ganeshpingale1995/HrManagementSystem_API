using HrManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Dbcontext
{
    public class Hrms_DbContext : DbContext
    {
        public Hrms_DbContext(DbContextOptions options) : base(options)
        {

        }

        //dbset
        public DbSet<Employee> Employees { get; set; }
    }
}
