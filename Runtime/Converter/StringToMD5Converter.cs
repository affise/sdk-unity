using System.Security.Cryptography;
using System.Text;

namespace AffiseAttributionLib.Converter
{
    public class StringToMD5Converter : IConverter<string, string>
    {
        private readonly MD5CryptoServiceProvider _md5Provider = new MD5CryptoServiceProvider();
        
        public string Convert(string from)
        {
            var hash = new StringBuilder();
            var bytes = _md5Provider.ComputeHash(new UTF8Encoding().GetBytes(from));

            foreach (var t in bytes)
            {
                hash.Append(t.ToString("x2"));
            }
            return hash.ToString();
        }
    }
}