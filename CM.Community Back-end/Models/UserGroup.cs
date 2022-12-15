using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CM.Community_Back_end.Models
{
    public class UserGroup
    {
        [ForeignKey("groupID")]
        public int groupID { get; set; }

        [ForeignKey("userEmail")]
        public string userEmail { get; set; }
    }
}