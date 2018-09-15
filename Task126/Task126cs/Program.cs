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
            uint count = 0;
            var indexes = new long[lengthOption];
            var lexema = new char[lengthOption];
            uint i = 0;
            var limit = Math.Pow(sourceAlphabet.Length, lengthOption);
            while (i < limit)
            {
                var index = 0;
                long division = i / sourceAlphabet.Length;
                long remainder = i % sourceAlphabet.Length;
                indexes[index++] = remainder;
                while (division >= sourceAlphabet.Length)
                {
                    remainder = division % sourceAlphabet.Length;
                    division = division / sourceAlphabet.Length;
                    indexes[index++] = remainder;
                }
                indexes[index] = division;

                for (uint j = 0; j < lengthOption; j++)
                    lexema[j] = sourceAlphabet[indexes[j]];

                string str = new string(lexema);
                if (!str.Contains(exceptSubstring))
                    count++;

                i++;
            }
            return count;
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
