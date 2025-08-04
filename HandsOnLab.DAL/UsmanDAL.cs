using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnLab.DAL
{
    public class UsmanDAL : IUsman
    {
        private readonly UserManager<IdentityUser> _usermManager;
        public UsmanDAL(UserManager<IdentityUser> userManager)
        {
            _usermManager = userManager;
        }


        public Task<bool> AddUserToRoleAsync(string email, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateRoleAsync(string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> LoginAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterAsync(string email, string password)
        {
            try
            {
                var user = new IdentityUser { UserName = email, Email = email };
                var result = await _usermManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
