using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CM.Community_Back_end.Models;

namespace CM.Community_Back_end.Models
{
    public class TagPost
    {
        [Key, Column(Order = 1)]
        public int postID { get; set; }
        [Key, Column(Order = 2)]
        public int tagID { get; set; }

        [ForeignKey("postID")]
        public Post Post { get; set; }

        [ForeignKey("tagID")]
        public Tag Tag { get; set; }
    }
}