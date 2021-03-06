﻿using DAL;
using DAL.MergeModels;
using Model.DatabaseModels;
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
        DBContext dBContext; 
        public PasswordHashAndSalt()
        {
            dBContext = new DBContext();
        }
        
    #region HashingAndSalting

	public Dictionary<string, byte[]> HashAndSalt(string password)
        {
            Dictionary<string, byte[]> hashingAndSalting = hashingAndSalting = new Dictionary<string, byte[]>();

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



        public string GenerateTemporaryPassword()
        {
              Random random = new Random();
             const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
              return new string(Enumerable.Repeat(chars, 10)
              .Select(s => s[random.Next(s.Length)]).ToArray());

        }


        public Company Decrypt(Company company , string password)
        {

            try
            {
                if (company.CompletePassword != null)
                {
                    using (var sha = new SHA256Managed())
                    {
                        byte[] passwordHash = Encoding.ASCII.GetBytes(password);
                        byte[] passwordSalt = new byte[passwordHash.Length + company.PasswordSalt.Length];
                        System.Buffer.BlockCopy(passwordHash, 0, passwordSalt, 0, passwordHash.Length);
                        System.Buffer.BlockCopy(company.PasswordSalt, 0, passwordSalt, passwordHash.Length, company.PasswordSalt.Length);

                        passwordSalt = sha.ComputeHash(passwordSalt);

                        if (passwordSalt.SequenceEqual(company.CompletePassword))
                        {
                            return company; 
                        }
                    }
                }
            } catch (Exception ex) { }
        

            return null;
        }





    }

}
