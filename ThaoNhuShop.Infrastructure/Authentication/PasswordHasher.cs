using System.Text;
using System.Security.Cryptography;
namespace ThaoNhuShop.Infrastructure.Authentication
{
    public class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            SHA256 hash = SHA256.Create();
            var passwordBytes = Encoding.Default.GetBytes(password);
            var hashedPassword = hash.ComputeHash(passwordBytes);
            return Convert.ToHexString(hashedPassword);
        }
    }
}