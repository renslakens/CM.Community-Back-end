using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CM.Community_Back_end.Models
{
    public class UserPost
    {
        [Key, Column(Order = 1)]
        public int userID { get; set; }
        [Key, Column(Order = 2)]
        public int postID { get; set; }

        [ForeignKey("userID")]
        public User User { get; set; }

        [ForeignKey("postID")]
        public Post Post { get; set; }
    }
}