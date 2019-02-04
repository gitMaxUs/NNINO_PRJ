﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Identety.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();
    }
}
