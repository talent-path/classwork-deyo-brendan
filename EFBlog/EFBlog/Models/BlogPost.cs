using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFBlog.Models
{
    public class BlogPost
    {
        [Column("Id")]
        public int BlogPostId { get; set; }

        [Required]
        public BlogUser Author { get; set; }

        [Required]
        [MaxLength(200)]
        public string Text { get; set; }

        [Required]
        public List<Comment> Comments { get; set; }
    }
}
