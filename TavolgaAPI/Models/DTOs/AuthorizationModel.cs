using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TavolgaAPI.Models.DTOs
{
    public class AuthorizationModel
    {
        public string Email { get; set; }

        private string _password;
        public string Password 
        {
            get => _password;
            set
            {
                var hashes = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(value)).Select(b => b.ToString("x2"));
                _password = string.Concat(hashes);
            }
        }
    }
}
