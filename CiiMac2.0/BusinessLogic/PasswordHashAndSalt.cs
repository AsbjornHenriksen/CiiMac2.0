using DAL.MergeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class PasswordHashAndSalt
    {
        private Dictionary<string, byte[]> hashingAndSalting;
        private static Random random;
      

        public PasswordHashAndSalt()
        {
            hashingAndSalting = new Dictionary<string, byte[]>();
            random = new Random();
         
        }
        
    #region HashingAndSalting

	public Dictionary<string, byte[]> HashAndSalt(string password)
        {
            byte[] passwordHash = Encoding.ASCII.GetBytes(password);
            byte[] passwordSalt = new byte[6];
            byte[] completePassword = new byte[passwordHash.Length + passwordSalt.Length];

            using (SHA256Managed sha = new SHA256Managed())
            {
                using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
                {
                    rng.GetNonZeroBytes(passwordSalt);
                }
                System.Buffer.BlockCopy(passwordHash, 0, completePassword, 0, passwordHash.Length);
                System.Buffer.BlockCopy(passwordSalt, 0, completePassword, passwordHash.Length, passwordSalt.Length);
                completePassword = sha.ComputeHash(completePassword);
            }

            hashingAndSalting.Add("passwordSalt", passwordSalt);
            hashingAndSalting.Add("completePassword", completePassword);



            return hashingAndSalting;
        }

        #endregion

        public string GenerateTemporaryPassword(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());

        }

        
    }

   


}
