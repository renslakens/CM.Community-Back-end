using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace CM.Community_Back_end.Models
{
    public class AttachmentPost
    {
        [Key, ForeignKey("Post")]
        public int postID { get; set; }

        public Post Post { get; set; }

        public byte attachment { get; set; }
    }
}
