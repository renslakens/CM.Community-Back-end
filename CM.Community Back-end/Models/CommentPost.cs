using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CM.Community_Back_end.Models
{
    public class CommentPost
    {
        [Key, Column(Order = 0)]
        public int postID { get; set; }
        [Key, Column(Order = 1)]
        public int commentID { get; set; }

        [ForeignKey("postID")]
        public Post Post { get; set; }

        [ForeignKey("commentID")]
        public Comment Comment { get; set; }
    }
}