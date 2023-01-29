using System.Security.Cryptography;
using System.Text;

namespace DevSecOps.BackOffice.Domain.Models
{
    public class Hash
    {
        public string HashPassword(string password)
        {
            SHA256 hash = SHA256.Create();

            var passwordBytes = Encoding.Default.GetBytes(password);

            var hashedpassword = hash.ComputeHash(passwordBytes);

            return Convert.ToHexString(hashedpassword);

        }
    }
}
