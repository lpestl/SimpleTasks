using System;

namespace Task133cs
{
    class Program
    {
        public static ulong CalcPacManPath(int width, int height, int row, int column)
        {
            ulong count = 1; short direction = 0;
            int i = 1; int j = 1;

            while (!((i == row) && (j == column)))
            {
                if (j == width) direction--;
                else if (j == 1) direction++;
                if (direction == 0) i++;
                j += direction;
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
