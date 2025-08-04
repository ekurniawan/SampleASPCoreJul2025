using HandsOnLab.BL.DTO;
using HandsOnLab.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnLab.BL
{
    public class UsmanBL : IUsmanBL
    {
        private readonly IUsman _usmanDAL;
        public UsmanBL(IUsman usmanDAL)
        {
            _usmanDAL = usmanDAL;
        }

        public Task<bool> AddUserToRoleAsync(string email, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateRoleAsync(string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<UserWithTokenDTO> LoginAsync(LoginDTO loginDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterAsync(RegistrationDTO registrationDTO)
        {
            try
            {
                if (registrationDTO == null)
                {
                    throw new ArgumentNullException(nameof(registrationDTO), "Registration data cannot be null");
                }
                var result = await _usmanDAL.RegisterAsync(registrationDTO.Email, registrationDTO.Password);
                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
