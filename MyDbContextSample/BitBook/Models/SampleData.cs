using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BitBook.Models
{
    public class SampleData:DropCreateDatabaseIfModelChanges<BitBookDbContext>
    {
        protected override void Seed(BitBookDbContext context)
        {
            Comment aComment=new Comment(){CommentedDate = DateTime.Parse("2008-05-01T07:34:42-5:00"),
                Message = "I like Cricket"};
            context.Comments.Add(aComment);
             Comment bComment=new Comment(){CommentedDate = DateTime.Parse("2014-08-01T07:34:42-5:00"),
                Message = "I like it too"};
            context.Comments.Add(bComment);
            List<Comment> commentList=new List<Comment>();
            commentList.Add(aComment);
            commentList.Add(bComment);
            context.Posts.Add(new Post() {Message = "Bangladesh is playing with Zimbabwa",PostedDate =DateTime.Parse("2014-07-01T07:34:42-5:00"),Comments =commentList});
            

        }
    }
}