using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CM.Community_Back_end.Models
{
    public class CommentPost
    {
        [ForeignKey("postID")]
        public int postID { get; set; }

        [ForeignKey("commentID")]
        public int commentID { get; set; }
    }
}