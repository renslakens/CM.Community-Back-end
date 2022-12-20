using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CM.Community_Back_end.Models
{
    public class Post
    {
        [Key]
        public int postID { get; set; }

        //[StringLength(50, MinimumLength = 3)]
        [StringLength(50)]
        public string postTitle { get; set; }

        [StringLength(360)]
        public string postText { get; set; }

        public DateTime publicationDate { get; set; }

        public string Subject { get; set; }

        [ForeignKey("groupID")]
        public Group Group { get; set; }


    }
}