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
        Task<UserDetails> UserLogin(UserLogin user);

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

        public async Task<UserDetails> UserLogin(UserLogin user)
        {

            try
            {
                UserDetails userDetails = await _iUserRepository.UserLogin(user);
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
            //return await _iUserRepository.UserLogin(userName, password);
        }

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
    }
}