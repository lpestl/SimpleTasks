/*          02. Метод "Честный PacMan"          */

using System;

namespace Task133cs
{
    class Program
    {
        // Подсчет количества пройденное PacMan`ом, по честному как в задании
        public static ulong CalcPacManPath(int width, int height, int row, int column)
        {
            // Инициализация динамический переменных
            ulong count = 1 /* количество шагов (т.к. включительно - на стартовой позиции PacMan уже съел одну) */;
            short direction = 0 /* направление движения (1 - вправо, 0 - вниз, -1 - влево) */;
            int i = 1 /* текущий номер строки */; int j = 1 /* текущий номер столбца */;
            // До тех пор пока мы не дочтигнем заданных координат
            while (!((i == row) && (j == column)))
            {
                // координату столбца меняем в зависимости от направления.
                // Если мы достигли правой границы, то направление меняется на "вниз" (или "влево", если предыдущее было "вниз"), иначе
                // Если мы достигли левой границы, то направление меняем на "вниз" (или "вправо", если предыдущее было "вниз").
                // Ну а коротко, потому что поигрался с инкрементами/декрементами и сокращением условий if
                j += j == width ? --direction : j == 1 ? ++direction : direction;
                // координату строки меняем только тогда, когда направление = "вниз"
                i += Convert.ToInt32(direction == 0);
                // у увеличеваем шаг
                count++;
            }

            return count;
        }

        // Tests
        static void Main(string[] args)
        {
            int N = 3, M = 3, row = 1, column = 1;
            Console.WriteLine($"N x M = {N} x {M};");
            Console.WriteLine($"ROW x COLUMN = {row} x {column};");
            Console.WriteLine($"Answer = {CalcPacManPath(N, M, row, column)}\n");

            N = 3; M = 3; row = 1; column = 2;
            Console.WriteLine($"N x M = {N} x {M};");
            Console.WriteLine($"ROW x COLUMN = {row} x {column};");
            Console.WriteLine($"Answer = {CalcPacManPath(N, M, row, column)}\n");

            N = 3; M = 3; row = 1; column = 3;
            Console.WriteLine($"N x M = {N} x {M};");
            Console.WriteLine($"ROW x COLUMN = {row} x {column};");
            Console.WriteLine($"Answer = {CalcPacManPath(N, M, row, column)}\n");

            N = 3; M = 3; row = 2; column = 3;
            Console.WriteLine($"N x M = {N} x {M};");
            Console.WriteLine($"ROW x COLUMN = {row} x {column};");
            Console.WriteLine($"Answer = {CalcPacManPath(N, M, row, column)}\n");

            N = 3; M = 3; row = 2; column = 2;
            Console.WriteLine($"N x M = {N} x {M};");
            Console.WriteLine($"ROW x COLUMN = {row} x {column};");
            Console.WriteLine($"Answer = {CalcPacManPath(N, M, row, column)}\n");

            // Test from task
            N = 3; M = 3; row = 2; column = 1;
            Console.WriteLine($"N x M = {N} x {M};");
            Console.WriteLine($"ROW x COLUMN = {row} x {column};");
            Console.WriteLine($"Answer = {CalcPacManPath(N, M, row, column)}\n");

            N = 3; M = 3; row = 3; column = 1;
            Console.WriteLine($"N x M = {N} x {M};");
            Console.WriteLine($"ROW x COLUMN = {row} x {column};");
            Console.WriteLine($"Answer = {CalcPacManPath(N, M, row, column)}\n");

            N = 3; M = 3; row = 3; column = 2;
            Console.WriteLine($"N x M = {N} x {M};");
            Console.WriteLine($"ROW x COLUMN = {row} x {column};");
            Console.WriteLine($"Answer = {CalcPacManPath(N, M, row, column)}\n");

            N = 3; M = 3; row = 3; column = 3;
            Console.WriteLine($"N x M = {N} x {M};");
            Console.WriteLine($"ROW x COLUMN = {row} x {column};");
            Console.WriteLine($"Answer = {CalcPacManPath(N, M, row, column)}\n");
        }
    }
}
