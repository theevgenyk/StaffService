using System.Linq;
using WebApplication2.Models;

namespace WebApplication2
{
    public static class SampleData
    {
        public static void Initialize(EmployeeContext context)
        {
            if (context.Staff.Any()) return;
            context.Staff.Add(
                new Employee()
                {
                    Name = "Eugene",
                    Surname = "Kuznetsov",
                    Phone = "89273949734",
                    CompanyId = "1",
                    PassportType = "5816",
                    PassportNumber = "968991"
                });
            context.SaveChanges();
        }
    }
}