using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCourseManager.Models
{
    [Table("Teachers")]
    public class Teacher
    {
        [Column("Id")]
        public int TeacherId { get; set; }

        [Required]
        [MaxLength(75)]
        public string Name { get; set; }

        public List<Course> TeacherCourses { get; set; }

    }
}
