using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Authentication
{
    public interface IUserManagementAuthenticationManager

    {
        string Authenticate(string username, string password);
        IDictionary<string, string> Tokens { get; }
    }
    public class UserManagementAuthenticationManager:IUserManagementAuthenticationManager
    {

            private readonly IDictionary<string, string> tokens = new Dictionary<string, string>();
            public IDictionary<string, string> Tokens => tokens;
            public string Authenticate(string username, string password)
            {

                if (password != "4545")
                {
                    return null;
                }
                var token = Guid.NewGuid().ToString();
                tokens.Add(token, password);
                return token;
            }
        }

    }



