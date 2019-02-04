using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using DAL.Identety.Entities;

namespace DAL.Identety.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(string conectionString) 
            : base(conectionString) { }

        //public ApplicationContext() 
        //    : base("DefaultConnection_Identity") { }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
    }
}
