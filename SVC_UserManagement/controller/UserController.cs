using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagementDBEntity.Models;
using SHR_Model;
using UserManagement.Authentication;

namespace UserManagement.controller
{
    [ApiController]
    public class UserController :Controller
    {
        private readonly IUserManagementAuthenticationManager _iUserManagementAuthenticationManager;
        public UserController(IUserManagementAuthenticationManager iUserManagementAuthenticationManager)
        {
            _iUserManagementAuthenticationManager = iUserManagementAuthenticationManager;
        }
        [AllowAnonymous]
        [HttpPost("UserLogin")]
        public IActionResult UserLogin([FromBody] UserLogin userLogin)
        {
            var token = _iUserManagementAuthenticationManager.UserLogin(userLogin.UserName, userLogin.UserPassword);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }

    }
}