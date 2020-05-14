using ProductManagementDBEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Authentication
{
    public interface IUserManagementAuthenticationManager
    {
        string UserLogin(string username, string password);
        IDictionary<string, string> Tokens { get; }
    }
    public class UserManagementAuthenticationManager:IUserManagementAuthenticationManager
    {
        private readonly ProductDBContext _productDBContext;
        public UserManagementAuthenticationManager(ProductDBContext productDBContext)
        {
            _productDBContext = productDBContext;
        }
        private readonly IDictionary<string, string> tokens = new Dictionary<string, string>();
            public IDictionary<string, string> Tokens => tokens;
            public string UserLogin(string username, string password)
            {
            UserDetails userDetails = _productDBContext.UserDetails.SingleOrDefault(e => e.UserName == username && e.UserPassword == password);
            if (userDetails == null)
                return null;
            else
            {
                var token = Guid.NewGuid().ToString();
                tokens.Add(token, password);
                return token;
            }
            }
        }

    }



