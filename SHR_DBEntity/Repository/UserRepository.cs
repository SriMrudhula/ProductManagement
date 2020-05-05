using Microsoft.EntityFrameworkCore;
using ProductManagementDBEntity.Models;
using ProductManagementDBEntity.Repository;
using SHR_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace UserManagement.Repository
{  
    public class UserRepository : IUserRepository
    {

        private readonly ProductDBContext _productDBContext;
        public UserRepository(ProductDBContext productDBContext)
        {
            _productDBContext = productDBContext;
        }


        public async Task<UserDetails> UserLogin(UserLogin user)
        {
            try
            {
                UserDetails userDetails = await _productDBContext.UserDetails.SingleOrDefaultAsync(e => e.UserName == user.UserName && e.UserPassword == user.UserPassword);
                if (userDetails == null)
                    return null;
                else
                    return userDetails;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UserRegister(UserDetails userDetails)
        {
            try
            {
                _productDBContext.UserDetails.Add(userDetails);
                var productId = await _productDBContext.SaveChangesAsync();
                if (productId > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                // To Do Log
                throw;
            }
        }

        public async Task<bool> UpdateProfile(UserDetails userDetails)
        {
            try
            {
                _productDBContext.UserDetails.Update(userDetails);
                var productId = await _productDBContext.SaveChangesAsync();
                if (productId > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                // To Do Log
                throw;
            }
        }

        public async Task<UserDetails> ViewProfile(int userId)
        {
            try
            {
                return await _productDBContext.UserDetails.FindAsync(userId);
            }
            catch (Exception e)
            {
                throw;
            }

        }


        public async Task<List<UserDetails>> GetAll()
        {
            try
            {
                return await _productDBContext.UserDetails.ToListAsync();
            }
            catch (Exception e)
            {
                throw;
            }
        }


    }
}

