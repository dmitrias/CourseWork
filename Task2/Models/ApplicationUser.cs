using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Task2.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public DateTime Register { get; set; }
        public DateTime Auth { get; set; }

        public List<Recepie> UserRecepies { get; set; }

        public List<Comment> UserComments { get; set; }


    }   
}