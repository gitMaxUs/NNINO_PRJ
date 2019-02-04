using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.TransferObjects;
using DAL.Identety.Entities;
using DAL.Identety.Interfaces;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                await Database.UserManager.CreateAsync(user, userDto.Password);
                // Add Role
                await Database.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                // Create client profile
                ClientProfile clientProfile = new ClientProfile
                {
                    Id = user.Id,
                    Address = userDto.Address,
                    Name = userDto.Name
                };
                Database.ClientManager.Create(clientProfile);
                await Database.SaveAsync();
                return new OperationDetails(true, "Реєстрацію пройдено!", "");

            }
            else
            {
                return new OperationDetails(false, "Користувач з таким імям вже існує", "Email");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            // find user
            ApplicationUser user = await Database.UserManager.FindAsync(userDto.Email, userDto.Password);
            // autoris and return instance ClaimsIdentity
            if (user != null)
                claim = await Database.UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        // Initial DB
        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await Database.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await Database.RoleManager.CreateAsync(role);
                }
            }

            await Create(adminDto);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }


}