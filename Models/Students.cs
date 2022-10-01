
using System.ComponentModel.DataAnnotations;

namespace Student.Models

{
    public class Students
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string? StudentName { get; set; }
        public string? StudentGrade { get; set; }

    
    }
}
