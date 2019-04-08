using Microsoft.AspNetCore.Identity;

namespace Shop.Web2.Data
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
