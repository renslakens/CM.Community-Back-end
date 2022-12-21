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
        [ForeignKey("groupID")]
        public int groupID { get; set; }
        [Key, Column(Order = 2)]
        [ForeignKey("userID")]
        public int userID { get; set; }

        
        //public Group Group { get; set; }

        
        //public User User { get; set; }
    }
}