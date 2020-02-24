using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechTest.Models
{
    public class UsersViewModel
    {
        [Required]
        public Guid ID { get; set; }

        [Required]
        public string Name { get; set;  }

        [Required]
        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

    }
}