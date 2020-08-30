using System.Security.Cryptography;
using System.Text;

namespace GitRepositoryAPI.Helpers
{
    public static class HashHelper
    {
        public static string ComputeHash(string password)
        {
            byte[] passwordStream = Encoding.ASCII.GetBytes(password);
            byte[] passwordEncryptStream = new MD5CryptoServiceProvider().ComputeHash(passwordStream);
            return ByteArrayToString(passwordEncryptStream);
        }

        public static bool IsValidHash(string hashedPassword, string password)
        {
            byte[] passwordStream = Encoding.ASCII.GetBytes(password);
            byte[] passwordEncryptStream = new MD5CryptoServiceProvider().ComputeHash(passwordStream);
            return hashedPassword == ByteArrayToString(passwordEncryptStream);
        }
        private static string ByteArrayToString(byte[] inputStream)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(inputStream.Length);
            for (i = 0; i < inputStream.Length; i++)
            {
                sOutput.Append(inputStream[i].ToString("X2"));
            }
            return sOutput.ToString();
        }
    }
}
