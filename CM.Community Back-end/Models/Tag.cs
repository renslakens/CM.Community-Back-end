using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CM.Community_Back_end.Models
{
    public class Tag
    {
        [Key]
        public int tagID { get; set; }

        public string tagName { get; set; }
    }
}