using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public double AvgGrade { get; set; }

    }
}