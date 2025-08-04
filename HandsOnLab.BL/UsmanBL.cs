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

        public async Task<UserWithTokenDTO> LoginAsync(LoginDTO loginDTO)
        {
            try
            {
                if (loginDTO == null)
                {
                    throw new ArgumentNullException(nameof(loginDTO), "Login data cannot be null");
                }
                var user = await _usmanDAL.LoginAsync(loginDTO.Email, loginDTO.Password);
                if (user == null)
                {
                    return null; // User not found or invalid password
                }
                // Here you would typically generate a JWT token or similar for the user
                // For simplicity, we are returning a dummy token
                var token = "dummy_token"; // Replace with actual token generation logic
                return new UserWithTokenDTO
                {
                    Email = user.Email,
                    Token = token
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
