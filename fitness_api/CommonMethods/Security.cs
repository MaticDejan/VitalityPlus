using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Fitness_Application.CommonMethods
{ 
    public static class Security
    {
        public static string key = "CeaMaiTareLicentaOFaceDejanMatic";

        public static string ConvertToEncrypt(string password)
        {
            if ((string.IsNullOrEmpty(password)))
                return "";
            password += key;
            var passwordBytes = Encoding.UTF8.GetBytes(password);   
            return Convert.ToBase64String(passwordBytes);
        }

        public static string ConvertToDecrypt(string base64EncodedData)
        {
            if (string.IsNullOrEmpty(base64EncodedData)) return "";
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            var result = Encoding.UTF8.GetString(base64EncodedBytes);
            result = result.Substring(0, result.Length - key.Length);
            return result;
        }
    }
}
