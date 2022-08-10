using System.Security.Cryptography;
using System.Text;

namespace AffiseAttributionLib.Converter
{
    public class StringToSHA256Converter : IConverter<string, string>
    {
        public string Convert(string from) => GenerateSha256(from);

        static string GenerateSha256(string value)
        {
            var hash = new StringBuilder();
            var crypt = new SHA256Managed();
            var crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(value));
            foreach (var theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}