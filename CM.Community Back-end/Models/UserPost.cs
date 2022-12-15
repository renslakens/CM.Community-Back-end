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

        [Key, ForeignKey("userEmail")]
        public User User { get; set; }

        [Key, ForeignKey("postID")]
        public Post Post { get; set; }
    }
}