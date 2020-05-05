using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Reports;
using Microsoft.AspNetCore.Mvc;
using ProductManagementDBEntity.Models;
using ProductManagementDBEntity.Repository;
using SHR_Model;
using UserManagement.Helper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManagement
{

    [Route("api/v1")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserManagementHelper _iUserManagementHelper;
        public UserController(IUserManagementHelper iUserManagementHelper)
        {
            _iUserManagementHelper = iUserManagementHelper;
        }
        [HttpPost]
        [Route("UserRegister")]

        public async Task<IActionResult> UserRegister(UserDetails userDetails)
        {
            try
            {
                await _iUserManagementHelper.UserRegister(userDetails);
                return Ok();
            }

            catch (Exception ex)
            {
                return NotFound(ex.Message);

            }
        }

        [HttpPost]
        [Route("UserLogin/{userName}/{password}")]

        public async Task<IActionResult> UserLogin(UserLogin user)
        {
            try
            {
                return Ok(await _iUserManagementHelper.UserLogin(user));

            }

            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);

            }
        }




        [HttpPut]
        [Route("EditProfile")]

        public async Task<IActionResult> EditProfile(UserDetails userDetails)
        {
            try
            {
                await _iUserManagementHelper.UpdateProfile(userDetails);
                return Ok();
            }

            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }

        [HttpGet]
        [Route("GetUser/{userId}")]

        public async Task<IActionResult> GetUser(int userId)
        {
            try
            {
                return Ok(await _iUserManagementHelper.ViewProfile(userId));
            }

            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }



        [HttpGet]
        [Route("ViewAllUsers")]
        public async Task<IActionResult> ViewAllUsers()
        {
            try
            {
                List<UserDetails> userDetails = await _iUserManagementHelper.GetAll();
                return Ok(userDetails);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
