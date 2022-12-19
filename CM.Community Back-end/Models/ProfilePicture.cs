using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace CM.Community_Back_end.Models
{
    public class ProfilePicture
    {
        [Key, ForeignKey("userID")]
        public User User { get; set; }

        public Blob profilePicture { get; set; }
    }
}
