using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Reflection;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;
using BROWSit.Models;

namespace BROWSit.Helpers
{
    public class LoginHelper
    {
        public class PasswordManager
        {
            Hasher hasher = new Hasher();

            public string generatePasswordHash(string password, out string salt)
            {
                salt = SaltGenerator.GetSaltString();
                return hasher.getPasswordHashAndSalt(password + salt);
            }

            public bool IsPasswordMatch(string password, string salt, string hash)
            {
                bool check = false;
                string hasherValue = hasher.getPasswordHashAndSalt(password + salt);
                check = (hash == hasherValue);
                return check;
            }
        }

        public static bool IsValidLogin(string Username, string Password)
        {
            // var crypto = new SimpleCrypto.PBKDF2();
            //var crypto = new SaltGenerator();
            LoginHelper.PasswordManager pm = new LoginHelper.PasswordManager();

            using (BROWSit.DAL.BROWSitContext db = new BROWSit.DAL.BROWSitContext())
            {
                User user = db.Users.FirstOrDefault(u => u.Username == Username);
                if (user != null)
                {
                    if (pm.IsPasswordMatch(Password, user.Salt, user.Hash))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static class SaltGenerator
        {
            private static RNGCryptoServiceProvider crypto = null;
            private const int SALT_SIZE = 24;

            static SaltGenerator()
            {
                crypto = new RNGCryptoServiceProvider();
            }

            public static string GetSaltString()
            {
                byte[] saltBytes = new byte[SALT_SIZE];
                crypto.GetNonZeroBytes(saltBytes);

                string saltString = getStringFromBytes(saltBytes);

                int restrictedLength = (4 * SALT_SIZE - 3) / 3; 

                if (saltString.Length > restrictedLength)
                {
                    saltString = saltString.Substring(0, restrictedLength);
                }

                return saltString;
            }
        }

        public class Hasher
        {
            public string getPasswordHashAndSalt(string message)
            {
                // Using the SHA256 algorithm, generate hash from salted password
                SHA256 sha = new SHA256CryptoServiceProvider();
                byte[] dataBytes = getBytesFromString(message);
                byte[] resultBytes = sha.ComputeHash(dataBytes);
                string resultString = getStringFromBytes(resultBytes);
                return resultString;
            }
        }

        public static string getStringFromBytes(byte[] bytes)
        {
            string returnString = Convert.ToBase64String(bytes);
            returnString = returnString.TrimEnd('=');
            return returnString;
        }

        public static byte[] getBytesFromString(string str)
        {
            //str = str.TrimEnd('=');
            //str = str.Replace('+', '-').Replace('/', '_');
            
            return Convert.FromBase64String(str);
        }
    }
}