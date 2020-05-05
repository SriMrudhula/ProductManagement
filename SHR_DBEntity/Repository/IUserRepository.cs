using ProductManagementDBEntity.Models;
using SHR_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProductManagementDBEntity.Repository
{
    public interface IUserRepository
    {

        Task<UserDetails> UserLogin(UserLogin user);

        Task<bool> UserRegister(UserDetails userDetails);

        Task<bool> UpdateProfile(UserDetails userDetails);

        Task<UserDetails> ViewProfile(int userId);
        Task<List<UserDetails>> GetAll();
    }
}
