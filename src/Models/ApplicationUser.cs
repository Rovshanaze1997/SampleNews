using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace News.Models
{
    public class ApplicationUser : IdentityUser {

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

         public int UserNameChangeLimit { get; set; }
        public byte[] ProfilePicture { get; set; }
       
     }
}