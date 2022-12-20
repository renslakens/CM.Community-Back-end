using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CM.Community_Back_end.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(50)]
        public string userEmail { get; set; }

        [StringLength(25)]
        public string userFirstName { get; set; }

        [StringLength(25)]
        public string userLastName { get; set; }

        public DateTime userBirthDate { get; set; }

        [StringLength(50)]
        public string userPassword { get; set; }
    }
}