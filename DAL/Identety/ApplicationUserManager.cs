using DAL.Identety.Entities;
using Microsoft.AspNet.Identity;

namespace DAL.Identety
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
                : base(store)
        {
        }
    }
}
