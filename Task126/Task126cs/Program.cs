using System;

namespace Task126cs
{
    class Program
    {
        // Самый надежный и самый "тяжелый способ" - перебор всех сочетаний алфавита и исключние тех, в которых есть подстрока
        private static uint NumberOfPosibleOption(char[] sourceAlphabet, int lengthOption, string exceptSubstring)
        {
            // Инициализируем счетчики
            uint count = 0, i = 0;
            // Инициализируем индексы для каждого символа (индекс - порядковый номер из алфавита)
            var indexes = new long[lengthOption];
            // массив символов для слова необходимой длинны 
            var lexema = new char[lengthOption];
            // Количество всех сочетаний символов
            var limit = Math.Pow(sourceAlphabet.Length, lengthOption);
            // Будем идти пока не переберем все
            while (i < limit)
            {
                // Индек номера символа
                var index = 0;
                // Переводим число i в число системы счисления длинны алфавита
                long division = i / sourceAlphabet.Length;
                long remainder = i % sourceAlphabet.Length;
                // И записываем значения по разрядам
                indexes[index++] = remainder;
                while (division >= sourceAlphabet.Length)
                {
                    remainder = division % sourceAlphabet.Length;
                    division = division / sourceAlphabet.Length;
                    indexes[index++] = remainder;
                }
                indexes[index] = division;
                // Теперь можем составить слово из текущего сочетания
                for (uint j = 0; j < lengthOption; j++)
                    lexema[j] = sourceAlphabet[indexes[j]];
                // Набор символов в строку
                string str = new string(lexema);
                // И проверим, содержит ли она подстроку
                if (!str.Contains(exceptSubstring))
                    // Если нет, то увеличиваем на один счетчик
                    count++;
                i++;
            }
            // Возвращаем количество
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

            // Test simple 2-2-1
            var alphabet02 = new[] { '0', '1' };
            var n02 = 2;
            var substring02 = "1";
            var answer02 = NumberOfPosibleOption(alphabet02, n02, substring02);
            Console.WriteLine("Alphabet: {'0', '1' }; N = 2; subdtring = \"1\"");
            Console.WriteLine(answer02);

            // Test simple 2-2-2
            var alphabet03 = new[] { '0', '1' };
            var n03 = 2;
            var substring03 = "11";
            var answer03 = NumberOfPosibleOption(alphabet03, n03, substring03);
            Console.WriteLine("Alphabet: {'0', '1' }; N = 2; subdtring = \"11\"");
            Console.WriteLine(answer03);
            
            // Test simple 2-3-1
            var alphabet04 = new[] { '0', '1' };
            var n04 = 3;
            var substring04 = "1";
            var answer04 = NumberOfPosibleOption(alphabet04, n04, substring04);
            Console.WriteLine("Alphabet: {'0', '1' }; N = 3; subdtring = \"1\"");
            Console.WriteLine(answer04);

            // Test simple 2-3-2
            var alphabet05 = new[] { '0', '1' };
            var n05 = 3;
            var substring05 = "11";
            var answer05 = NumberOfPosibleOption(alphabet05, n05, substring05);
            Console.WriteLine("Alphabet: {'0', '1' }; N = 3; subdtring = \"11\"");
            Console.WriteLine(answer05);

            // Test simple 2-3-3
            var alphabet06 = new[] { '0', '1' };
            var n06 = 3;
            var substring06 = "111";
            var answer06 = NumberOfPosibleOption(alphabet06, n06, substring06);
            Console.WriteLine("Alphabet: {'0', '1' }; N = 3; subdtring = \"111\"");
            Console.WriteLine(answer06);
            
            // Test simple 2-4-1
            var alphabet07 = new[] { '0', '1' };
            var n07 = 4;
            var substring07 = "1";
            var answer07 = NumberOfPosibleOption(alphabet07, n07, substring07);
            Console.WriteLine("Alphabet: {'0', '1' }; N = 4; subdtring = \"1\"");
            Console.WriteLine(answer07);
            
            // Test simple 2-4-2
            var alphabet08 = new[] { '0', '1' };
            var n08 = 4;
            var substring08 = "11";
            var answer08 = NumberOfPosibleOption(alphabet08, n08, substring08);
            Console.WriteLine("Alphabet: {'0', '1' }; N = 4; subdtring = \"11\"");
            Console.WriteLine(answer08);
            
            // Test simple 2-4-3
            var alphabet09 = new[] { '0', '1' };
            var n09 = 4;
            var substring09 = "111";
            var answer09 = NumberOfPosibleOption(alphabet09, n09, substring09);
            Console.WriteLine("Alphabet: {'0', '1' }; N = 4; subdtring = \"111\"");
            Console.WriteLine(answer09);
            
            // Test simple 2-4-4
            var alphabet10 = new[] { '0', '1' };
            var n10 = 4;
            var substring10 = "1111";
            var answer10 = NumberOfPosibleOption(alphabet10, n10, substring10);
            Console.WriteLine("Alphabet: {'0', '1' }; N = 4; subdtring = \"1111\"");
            Console.WriteLine(answer10);
        }

    }
}
