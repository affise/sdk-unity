using System.Text;

namespace AffiseAttributionLib.Converter
{
    public class ConverterToBase64 : IConverter<string, string>
    {
        public string Convert(string from)
        {
            var bytesToEncode = Encoding.UTF8.GetBytes(from);
            return System.Convert.ToBase64String(bytesToEncode);
        }
    }
}