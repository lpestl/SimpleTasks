using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task126cs
{
    class Program
    {
        private static uint NumberOfPosibleOption(char[] sourceAlphabet, int lengthOption, string exceptSubstring)
        {
            var answer = Math.Pow(sourceAlphabet.Length, lengthOption);
            var indexes = new uint[lengthOption];
            uint i = 0;
            while (i < answer) 
            {

            }
            return 0;
        }

        static void Main(string[] args)
        {
            // Test from task
            var alphabet01 = new[]{'1', '2', '3'};
            var n01 = 3;
            var substring01 = "12";
            var answer01 = NumberOfPosibleOption(alphabet01, n01, substring01);
            Console.WriteLine("Alphabet: {'1', '2', '3' }; N = 3; subdtring = \"12\"");
            Console.WriteLine(answer01);

            // Test simple
            var alphabet02 = new[] { '0', '1' };
            var n02 = 2;
            var substring02 = "1";
            var answer02 = NumberOfPosibleOption(alphabet02, n02, substring02);
            Console.WriteLine("Alphabet: {'0', '1' }; N = 2; subdtring = \"1\"");
            Console.WriteLine(answer02);
        }

    }
}
