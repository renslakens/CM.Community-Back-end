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
        public int userID { get; set; }

        public string userEmail { get; set; }

        public string userName { get; set; }

        public string userFirstName { get; set; }

        public string userLastName { get; set; }

        public DateTime userBirthDate { get; set; }

        public string userPassword { get; set; }
    }
}