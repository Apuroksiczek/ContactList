using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public static class StringToSHA
    {
        public static string ConvertToSHA(string text)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(text);

                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                
                return hashString;
            }
        }
    }
}
