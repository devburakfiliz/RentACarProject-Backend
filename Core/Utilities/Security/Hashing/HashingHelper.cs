using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash
            (string password, out byte[] passwordHash, out byte[] passwordSalt) // bir password verıcez ve verılen ıkı degerı dısarı cıakran bır yapı tasarlıyoruz
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)  //kullanıcın gırdıgı paraloyı Dogrulama
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++) //hesaplanan hasın tum degerlerını tek tek dolaş
                {
                    if (computedHash[i] != passwordHash[i]) // eğerki benım computedhashımın i nin ci değeri veri tabanındaki hashın i ninci değerine eşit değilse  false
                    {
                        return false;
                    }
                }
                return true; // eşleşirse true
            }

        }

       
    }
}
