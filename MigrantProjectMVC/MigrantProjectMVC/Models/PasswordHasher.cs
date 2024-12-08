﻿using MigrantProjectMVC.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace MigrantProjectMVC.Models
{
    public class PasswordHasher : IPasswordHasher
    {
        public string GenerateHash(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public bool Verify(string password, string passwordHash)
        {
            var hash = GenerateHash(password);
            return hash == passwordHash;
        }
    }
}
