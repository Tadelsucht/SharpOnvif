﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace SharpOnvifCommon.Security
{
    public static class DigestHelpers
    {
        public static string CalculateNonce(int length = 32)
        {
            var byteArray = new byte[length];
            using (var rnd = RandomNumberGenerator.Create())
            {
                rnd.GetBytes(byteArray);
            }
            return Convert.ToBase64String(byteArray);
        }

        public static string DateTimeToString(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
        }

        public static string CreateHashedPassword(string nonce, DateTime created, string password)
        {
            return CreateHashedPassword(nonce, DateTimeToString(created), password);
        }

        public static string CreateHashedPassword(string nonce, string created, string password)
        {
            var nonceBytes = Convert.FromBase64String(nonce);
            var createdBytes = Encoding.UTF8.GetBytes(created);
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var combined = new byte[createdBytes.Length + nonceBytes.Length + passwordBytes.Length];

            Buffer.BlockCopy(nonceBytes, 0, combined, 0, nonceBytes.Length);
            Buffer.BlockCopy(createdBytes, 0, combined, nonceBytes.Length, createdBytes.Length);
            Buffer.BlockCopy(passwordBytes, 0, combined, nonceBytes.Length + createdBytes.Length, passwordBytes.Length);

            using (var sha = SHA1.Create())
            {
                return Convert.ToBase64String(sha.ComputeHash(combined));
            }
        }
    }
}
