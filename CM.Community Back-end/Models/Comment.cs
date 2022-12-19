using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CM.Community_Back_end.Models
{
    public class Comment
    {
        [Key]
        public int commentID { get; set; }

        [StringLength(100)]
        public string commentText { get; set; }
    }
}