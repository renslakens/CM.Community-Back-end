using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace CM.Community_Back_end.Models
{
    public class AttachmentPost
    {
        [Key, ForeignKey("postID")]
        public Post Post { get; set; }

        public Blob attachment { get; set; }
    }
}
