using HandsOnLab.BL.DTO;
using HandsOnLab.BL.Helpers;
using HandsOnLab.DAL;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace HandsOnLab.BL
{
    public class UsmanBL : IUsmanBL
    {
        private readonly IUsman _usmanDAL;
        private readonly AppSettings _appSettings;

        public UsmanBL(IUsman usmanDAL, IOptions<AppSettings> appSettings)
        {
            _usmanDAL = usmanDAL;
            _appSettings = appSettings.Value;
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

                //add claim
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Email, user.Email));

                var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(
                        new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key),
                        Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);


                var result = new UserWithTokenDTO
                {
                    Email = user.Email,
                    Token = tokenHandler.WriteToken(token)
                };

                return result;
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
