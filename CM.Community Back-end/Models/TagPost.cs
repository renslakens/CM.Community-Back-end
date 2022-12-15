using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CM.Community_Back_end.Models;

namespace CM.Community_Back_end.Models
{
    public class TagPost
    {
        [ForeignKey("postID")]
        public int postID { get; set; }

        [ForeignKey("tagID")]
        public int tagID { get; set; }
    }
}