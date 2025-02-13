using Microsoft.AspNetCore.Identity;

namespace RAD302Week3Lab12025WebAPIS00237686.DataLayer
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
