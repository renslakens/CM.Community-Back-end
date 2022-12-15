using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CM.Community_Back_end.Models
{
    public class Post
    {
        [Key]
        public int postID { get; set; }

        public string postTitle { get; set; }

        public string postText { get; set; }

        public DateTime publicationDate { get; set; }

        public string Subject { get; set; }


    }
}