using System;
using System.Text;

namespace Services.Helpers
{
    public class URLShortener : IURLShortener
    {
        private readonly char[] ALPHABET = new char[]
        {
            '2', '3', '4', '5', '6', '7', '8', '9', 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'm', 'n', 'p', 'q', 'r',
            's', 't', 'v', 'w', 'x', 'y', 'z', 'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S',
            'T', 'V', 'W', 'X', 'Y', 'Z', '-', '_'
        };
        private int BASE => ALPHABET.Length;

        public string Encode(long number)
        {
            var str = new StringBuilder();
            while (number > 0)
            {
                str.Insert(0, ALPHABET[number % BASE]);
                number = number / BASE;
            }
            return str.ToString();
        }

        public long Decode(string str)
        {
            int num = 0;
            foreach (char chr in str)
                num = num * BASE + Array.IndexOf(ALPHABET,chr);

            return num;
        }
    }
}