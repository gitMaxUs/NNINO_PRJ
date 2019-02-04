﻿using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Identety.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
    }
}

