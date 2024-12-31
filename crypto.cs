using System;
using System.Security.Cryptography;
using System.Text;

namespace EncryptionVulnerabilityExample
{
    public class EncryptionVulnerability
    {
        public string HashPasswordMD5(string password)
        {
            // Insecure: Using the weak MD5 hash algorithm for password hashing
            using (MD5 md5 = MD5.Create())
            {
                // Convert the password string into a byte array
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                // Compute the hash
                byte[] hashBytes = md5.ComputeHash(passwordBytes);

                // Convert the byte array to a hex string (for storing the hash)
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }

        public static void Main(string[] args)
        {
            var encryptionVulnerability = new EncryptionVulnerability();
            string password = "mySecurePassword";

            // Hash the password using the insecure MD5 algorithm
            string hashedPassword = encryptionVulnerability.HashPasswordMD5(password);

            Console.WriteLine($"MD5 Hashed Password: {hashedPassword}");
        }
    }
}

