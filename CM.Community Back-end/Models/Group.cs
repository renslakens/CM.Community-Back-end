using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CM.Community_Back_end.Models
{
    public class Group
    {
        [Key]
        public int groupID { get; set; }

        [StringLength(50)]
        public string groupName { get; set; }
    }
}