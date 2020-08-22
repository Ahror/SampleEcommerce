using System;
using System.Text;

namespace SampleEcommerce.Moblie.Helper
{
    public static class Base64Conversions
    {
        public static string EncryptString(this string text)
        {
            if (text == null) return null;

            var plainTextBytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string DecryptString(this string encodedText)
        {
            if (encodedText == null) return null;

            var base64EncodedBytes = Convert.FromBase64String(encodedText);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
