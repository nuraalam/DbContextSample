using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitBook.Models
{
    public class Comment
    {
        public int CommentId { get; set; }      
        public string Message { get; set; }    
        public System.DateTime CommentedDate { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}