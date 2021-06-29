using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCourseManager.Models
{
    [Table("Courses")]
    public class Course
    {
        [Column("Id")]
        public int CourseId { get; set; }

        public Teacher ClassTeacher { get; set; }

        public List<Student> ClassStudents { get; set; }
        
        [Required]
        [MaxLength(75)]
        public string Name { get; set; }

    }
}
