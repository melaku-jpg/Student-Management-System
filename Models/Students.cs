
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Student.Models

{
    public class Students
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        [DisplayName("Student Name")]
        public string? StudentName { get; set; }
        [DisplayName("Student Grade")]
        public string? StudentGrade { get; set; }

        public string? StudentTelNo { get; set; }

    }
    }


