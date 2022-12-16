using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CM.Community_Back_end.Models
{
    public class UserGroup
    {
        [Key, Column(Order = 1)]
        public int groupID { get; set; }
        [Key, Column(Order = 2)]
        public int userID { get; set; }

        [ForeignKey("groupID")]
        public Group Group { get; set; }

        [ForeignKey("userID")]
        public User User { get; set; }
    }
}