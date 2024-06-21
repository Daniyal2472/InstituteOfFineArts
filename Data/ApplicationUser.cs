using Microsoft.AspNetCore.Identity;

namespace InstituteOfFineArts.Data
{
    public class ApplicationUser: IdentityUser
    {
        public string Name{ get; set; }
    }
}