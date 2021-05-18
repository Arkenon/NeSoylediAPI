using System;
using System.Linq;

namespace NeSoyledi.Api.Helpers
{
    public static class KeyGenerator
    {
        private static readonly Random random = new Random();

        public static string GenerateKey(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var result = new string(
                Enumerable.Repeat(chars, length)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
    }
}
