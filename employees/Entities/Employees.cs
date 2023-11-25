using System.ComponentModel.DataAnnotations;

namespace employees.Entities
{
    public class Employees
    {
        [Key]
        public int EmployeeID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Department { get; set; }

    }
}
