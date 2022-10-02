using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace Student.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string Name { get; set; }
        public int? TelNo { get; set; }  
        public string? Id { get; set; }  

        


    }
}
