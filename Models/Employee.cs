using System.ComponentModel.DataAnnotations;

namespace HrManagementSystem.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime? DOB { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }

    }
}
