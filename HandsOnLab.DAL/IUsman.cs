﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnLab.DAL
{
    public interface IUsman
    {
        //registration asp identity
        Task<bool> RegisterAsync(string email, string password);
        //login asp identity
        Task<bool> LoginAsync(string email, string password);
        //create role
        Task<bool> CreateRoleAsync(string roleName);
        //add user to role
        Task<bool> AddUserToRoleAsync(string email, string roleName);

    }
}
