﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Reports;
using Microsoft.AspNetCore.Authorization;
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
   // [Authorize]
    public class UserController :Controller
    {
        private readonly IUserManagementHelper _iUserManagementHelper;
        public UserController(IUserManagementHelper iUserManagementHelper)
        {
            _iUserManagementHelper = iUserManagementHelper;
        }
        /// <summary>
        /// For new user to Register
        /// </summary>
        /// <param name="userDetails"></param>
        [Route("UserRegister")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(404, Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> UserRegister(UserDetails userDetails)
        {
            try
            {
                await _iUserManagementHelper.UserRegister(userDetails);
                return Ok();
            }

            catch (Exception ex)
            {
                return NotFound(ex.InnerException.Message);

            }
        }
        /// <summary>
        /// Login into account by entering Username and Password
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UserLogin")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(404, Type = typeof(string))]
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

        /// <summary>
        /// To get id of a particular user by using userName
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
       [Route("GetIdByName/{name}")]
       [ProducesResponseType(200,Type=typeof(int))]
       [ProducesResponseType(404, Type = typeof(string))]
        public async Task<IActionResult> GetIdByName(string name)
        {
            try
            {
                return Ok(await _iUserManagementHelper.GetIdByName(name));
            }
            catch(Exception ex)
            {
                return NotFound(ex.InnerException.Message);
            }
        }
        /// <summary>
        /// To edit details of a particular user
        /// </summary>
        /// <param name="userDetails"></param>
        /// <returns></returns>


           [HttpPut]
        [Route("EditProfile")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(404, Type = typeof(string))]
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
        /// <summary>
        /// To retrieve details of a particular by using userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUser/{userId}")]
        [ProducesResponseType(200, Type = typeof(UserDetails))]
        [ProducesResponseType(404, Type = typeof(string))]
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

        /// <summary>
        /// To retrieve all user details
        /// </summary>
        /// <returns></returns>
        
        [Route("ViewAllUsers")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<UserDetails>))]
        [ProducesResponseType(404, Type = typeof(string))]
        public async Task<IActionResult> ViewAllUsers()
        {
            try
            {
                List<UserDetails> userDetails = await _iUserManagementHelper.GetAll();
                return Ok(userDetails);
            }
            catch (Exception e)
            {
                return NotFound(e.InnerException.Message); 
            }
        }
    }
}
