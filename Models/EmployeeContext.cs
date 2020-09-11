using System.Data.Entity.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class EmployeeContext : DbContext
    {
   //     public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Staff { get; set; }

       public EmployeeContext(DbContextOptions<EmployeeContext> options) 
           : base(options)
       {
          Database.EnsureCreated();
       }
    }
}