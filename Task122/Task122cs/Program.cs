using System;

namespace Task122cs
{
/// ///////////////////////////////////////////////////////////////////////////////
/// Start solution
/// ///////////////////////////////////////////////////////////////////////////////

    // Структура для ответа
    struct MaxSumSubMatrixData
    {
        public long Sum;    // Максимальная сумма
        public int IStart;  // Индекс строки левого верхнего угла подматрицы
        public int JStart;  // Индекс столбца левого верхнего угла подматрицы
        public int IEnd;    // Индекс строки прового нижнего угла подматрицы (включительно)
        public int JEnd;    // Индекс строки правого нижнего угла подматрицы (включительно)
    }
    
    class Program
    {
        // функция для расчета максимальной суммы с перебором всех подматриц
        public static MaxSumSubMatrixData GetSubMatrixWithMaxSum(int[,] matrix)
        {
            // Инициализации переменной для хранения ответа (если матрица пустая, то индексы будут отрицательные)
            MaxSumSubMatrixData result = new MaxSumSubMatrixData { Sum = matrix[0,0], IStart = 0, JStart = 0, IEnd = 0, JEnd = 0 };
            // Возьмем за начало подматрицы каждый элемент из главной матрицы
            for (var i = 0; i < matrix.GetLength(0); i++)
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    // Инициализируем переменную для поиска максимальной суммы всех подматриц с началом в i,j
                    MaxSumSubMatrixData sumSubMatrix = new MaxSumSubMatrixData { Sum = matrix[i,j], IStart = i, JStart = j };
                    // Чтобы перебрать все подматрицы, мы должны перебрать все варианты правого нижнего угла матрицы от начала (i,j) до конта исходной матрицы
                    for (var i_end = i; i_end < matrix.GetLength(0); i_end++)
                        for (var j_end = j; j_end < matrix.GetLength(1); j_end++)
                        {
                            // Инициализируем переменную для хранения суммы текужей подматрицы
                            MaxSumSubMatrixData currentSum = new MaxSumSubMatrixData { IStart = i, JStart = j, IEnd = i_end, JEnd = j_end };
                            // И посчитаем эту сумму
                            for (var rowIndex = i; rowIndex <= i_end; rowIndex++)
                                for (var columnIndex = j; columnIndex <= j_end; columnIndex++)
                                    currentSum.Sum += matrix[rowIndex, columnIndex];
                            // Если текущая сумма больше максимальной суммы подматриц с началом в i,j
                            if (currentSum.Sum > sumSubMatrix.Sum)
                                // То назначаем текущую сумму максимальной для подматриц с началом i,j
                                sumSubMatrix = currentSum;
                        }
                    // Если максимальная сумма из множества подматриц с началом в i,j больше общей максимальной суммы
                    if (sumSubMatrix.Sum > result.Sum)
                        // То назначаем её общей максимальной суммой
                        result = sumSubMatrix;
                }
            // Максимальная сумма и координаты подматрицы найдены
            return result;
        }
/// ///////////////////////////////////////////////////////////////////////////////
/// End solution
/// ///////////////////////////////////////////////////////////////////////////////
/// 
/// ///////////////////////////////////////////////////////////////////////////////
/// Start Tests
/// ///////////////////////////////////////////////////////////////////////////////
        static void Main(string[] args)
        {
            // Test 01: From task
            var matrix01 = new [,]
            {
                {-1,  -2,   -3},
                { 1,   1,   -4},
                { 1,   1,   -5}
            };

            var answer01 = GetSubMatrixWithMaxSum(matrix01);
            Console.WriteLine($"MaxSum = {answer01.Sum}");
            Console.WriteLine($"SubMatrix Coordinate: ({answer01.IStart + 1}, {answer01.JStart + 1}) - ({answer01.IEnd + 1}, {answer01.JEnd + 1})");

            // Test 02: Null set (MaxSum should be 0)
            var matrix02 = new[,]
            {
                {-1, -1, -1}, 
                {-1, -1, -1}, 
                {-1, -1, -1}
            };
            var answer02 = GetSubMatrixWithMaxSum(matrix02);
            Console.WriteLine($"MaxSum = {answer02.Sum}");
            Console.WriteLine($"SubMatrix Coordinate: ({answer02.IStart + 1}, {answer02.JStart + 1}) - ({answer02.IEnd + 1}, {answer02.JEnd + 1})");

            // Test 03: From Task 8
            var matrix03 = new[,]{{-1, 10, -9, 5, 6, -10}};
            var answer03 = GetSubMatrixWithMaxSum(matrix03);
            Console.WriteLine($"MaxSum = {answer03.Sum}");
            Console.WriteLine($"SubMatrix Coordinate: ({answer03.IStart + 1}, {answer03.JStart + 1}) - ({answer03.IEnd + 1}, {answer03.JEnd + 1})");

            // Test 04: From Task 8. v2
            var matrix04 = new[,] {{1, 5, 7, -20, 3, 100, -250, 88, 33, 1, -40, 120}};
            var answer04 = GetSubMatrixWithMaxSum(matrix04);
            Console.WriteLine($"MaxSum = {answer04.Sum}");
            Console.WriteLine($"SubMatrix Coordinate: ({answer04.IStart + 1}, {answer04.JStart + 1}) - ({answer04.IEnd + 1}, {answer04.JEnd + 1})");

            Console.WriteLine("Press ESC to stop or other key for starting generate test matrix");
            if (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                // Start generate infiniti Tests
                Random rnd = new Random();
                do
                {
                    var height = rnd.Next(1, 15);
                    var width = rnd.Next(1, 15);
                    var matrix = new int[height, width];
                    for (var i = 0; i < height; i++)
                    {
                        for (var j = 0; j < width; j++)
                        {
                            matrix[i, j] = rnd.Next(-1000, 1000);
                            Console.Write($"\t{matrix[i, j]}");
                        }

                        Console.WriteLine();
                    }

                    var answer = GetSubMatrixWithMaxSum(matrix);
                    Console.WriteLine($"MaxSum = {answer.Sum}");
                    Console.WriteLine(
                        $"SubMatrix Coordinate: ({answer.IStart + 1}, {answer.JStart + 1}) - ({answer.IEnd + 1}, {answer.JEnd + 1})");
                    Console.WriteLine();
                    Console.WriteLine("Press ESC to stop");
                    Console.WriteLine();
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            }
        }
    }

/// ///////////////////////////////////////////////////////////////////////////////
/// End Tests
/// ///////////////////////////////////////////////////////////////////////////////
}
