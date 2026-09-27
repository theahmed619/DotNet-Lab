using System.ComponentModel.DataAnnotations;

namespace FirstMVCProject.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string EmployeeName { get; set; } = null!;
        public string Department { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Designation { get; set; } = null!;
    }
}
