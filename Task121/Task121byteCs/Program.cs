using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task121byteCs
{
    public static class StringHelper
    {
        public static string ToMirrorRegister(this string str)
        {
            var chars = str.ToCharArray();
            for(var i = 0; i < chars.Length; i++)
            {
                if (((chars[i] >= 0x61) && (chars[i] <= 0x7A)) || ((chars[i] >= 0x430) && (chars[i] <= 0x44F)))
                    chars[i] = (char) (chars[i] - 0x20);
                else if (((chars[i] >= 0x41) && (chars[i] <= 0x5A)) || ((chars[i] >= 0x410) && (chars[i] <= 0x42F)))
                    chars[i] = (char) (chars[i] + 0x20);
            }
            return new string(chars);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Test 1
            string message = "cAPS LOCK. я ТЕБЯ ненавижу!";
            Console.WriteLine(message.ToMirrorRegister());

            // Test 2
            Console.WriteLine("еЩЁ ОДНА кРиВаЯ СТРОКА".ToMirrorRegister());
        }
    }
}
