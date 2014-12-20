using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitBook.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Message { get; set; }
        public System.DateTime PostedDate { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}