using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCourseManager.Models
{
    [Table("Students")]
    public class Student
    {
        [Column("Id")]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(75)]
        public string Name { get; set; }

        public List<Course> StudentCourses { get; set; }

    }
}
