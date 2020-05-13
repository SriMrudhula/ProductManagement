using ProductManagementDBEntity.Models;
using ProductManagementDBEntity.Repository;
using SHR_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Helper
{
    public interface IUserManagementHelper
    {
        Task<string> UserLogin(UserLogin user);
        Task<int> GetIdByName(string name);
        Task<bool> UserRegister(UserDetails userDetails);

        Task<bool> UpdateProfile(UserDetails userDetails);

        Task<UserDetails> ViewProfile(int userId);
        Task<List<UserDetails>> GetAll();

    }
    public class UserManagementHelper : IUserManagementHelper
    {
        private readonly IUserRepository _iUserRepository;

        public UserManagementHelper(IUserRepository iUserRepository)
        {
            _iUserRepository = iUserRepository;
        }
        /// <summary>
        /// For new user to register
        /// </summary>
        /// <param name="userDetails"></param>
        /// <returns></returns>
        public async Task<bool> UserRegister(UserDetails userDetails)
        {
            try
            {
                bool user = await _iUserRepository.UserRegister(userDetails);
                return user;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// For user login by entering username and password
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>

        public async Task<string> UserLogin(UserLogin user)
        {

            try
            {
                UserDetails userDetails = await _iUserRepository.UserLogin(user);
                if (userDetails != null)
                {
                    return "Sucessfully Logged in";
                }
                else
                    return "Invalid User";
            }
            catch
            {
                throw;
            }
            //return await _iUserRepository.UserLogin(userName, password);
        }
        /// <summary>
        /// To update details of a particular user
        /// </summary>
        /// <param name="userDetails"></param>
        /// <returns></returns>
        public async Task<bool> UpdateProfile(UserDetails userDetails)
        {


            try
            {
                bool user = await _iUserRepository.UpdateProfile(userDetails);
                if (user == true)
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                throw;
            }

        }

        /// <summary>
        /// To get details of a particular user by using userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>



        public async Task<UserDetails> ViewProfile(int userId)
        {
            try
            {
                UserDetails userDetails = await _iUserRepository.ViewProfile(userId);
                if (userDetails != null)
                {
                    return userDetails;
                }
                else
                    return null;
            }
            catch
            {
                throw;
            }

        }

        /// <summary>
        /// To get all user details
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserDetails>> GetAll()
        {
            try
            {
                return await _iUserRepository.GetAll();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// To get id of a particular user by using userName
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<int> GetIdByName(string name)
        {
            try
            {
               return await _iUserRepository.GetIdByName(name);
            }
            catch
            {
                throw;
            }
        }
    }
}