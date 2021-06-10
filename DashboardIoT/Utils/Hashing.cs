using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace DashboardIoT.Utils
{
	public static class Hashing
	{
		public static bool TryHash(string toEncrypt, out string encrypted, out string salt)
		{
			if (string.IsNullOrWhiteSpace(toEncrypt))
			{
                encrypted = null;
                salt = null;
				return false;
			}
            else
			{
                byte[] saltData = new byte[128 / 8];
                using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(saltData);
                }
                salt = Convert.ToBase64String(saltData);

                encrypted = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: toEncrypt,
                    salt: saltData,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8));

                return true;
            }
        }

        public static bool TryHash(string toEncrypt, string salt, out string encrypted)
        {
            if (string.IsNullOrWhiteSpace(toEncrypt) || string.IsNullOrWhiteSpace(salt))
            {
                encrypted = null;
                return false;
            }
            else
            {
                encrypted = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: toEncrypt,
                    salt: Convert.FromBase64String(salt),
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8));

                return true;
            }
        }
    }
}
