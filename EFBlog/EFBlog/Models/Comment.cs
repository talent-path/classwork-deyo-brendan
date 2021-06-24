﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFBlog.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        
        public string Author { get; set; }

        public string Text { get; set; }

        public BlogPost ParentPost { get; set; }

    }
}
