using System.Collections.Generic;

namespace WebApplication2.Models
{
    public class Employee 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string CompanyId { get; set; }
        public string PassportType { get; set; }
        public string PassportNumber { get; set; }
    }
}