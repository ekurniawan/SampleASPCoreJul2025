using HandsOnLab.BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnLab.BL
{
    public interface IUsmanBL
    {
        //registration asp identity
        Task<bool> RegisterAsync(RegistrationDTO registrationDTO);
        //login asp identity
        Task<UserWithTokenDTO> LoginAsync(LoginDTO loginDTO);
        //create role
        Task<bool> CreateRoleAsync(string roleName);
        //add user to role
        Task<bool> AddUserToRoleAsync(string email, string roleName);
    }
}
