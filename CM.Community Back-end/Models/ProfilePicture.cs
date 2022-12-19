using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace CM.Community_Back_end.Models
{
    public class ProfilePicture
    {
        [Key, ForeignKey("User")]
        public int userID { get; set; }

        public User User { get; set; }

        public byte profilePicture { get; set; }
    }
}
