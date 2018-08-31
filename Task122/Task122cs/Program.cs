using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task122cs
{
    struct MaxSumSubMatrixData
    {
        public long MaxSum;
        public int IStart;
        public int JStart;
        public int IEnd;
        public int JEnd;
    }


    class Program
    {
        static void Main(string[] args)
        {
            var matrix01 = new [,]
            {
                {-1,  -2,   -3},
                { 1,   1,   -4},
                { 1,   1,   -5}
            };

            var answer01 = GetSubMatrixWithMaxSum(matrix01);
            Console.WriteLine($"MaxSum = {answer01.MaxSum}");
            Console.WriteLine($"SubMatrix Coordinate: ({answer01.IStart + 1}, {answer01.JStart + 1}) - ({answer01.IEnd + 1}, {answer01.JEnd + 1})");
        }

        public static MaxSumSubMatrixData GetSubMatrixWithMaxSum(int[,] matrix)
        {
            MaxSumSubMatrixData result = new MaxSumSubMatrixData { IStart = -1, JStart = -1, IEnd = -1, JEnd = -1 };

            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    MaxSumSubMatrixData sumSubMatrix = new MaxSumSubMatrixData { IStart = i, JStart = j};
                    for (var i_end = i; i_end < matrix.GetLength(0); i_end++)
                    {
                        for (var j_end = j; j_end < matrix.GetLength(1); j_end++)
                        {
                            MaxSumSubMatrixData currentSum = new MaxSumSubMatrixData { IStart = i, JStart = j, IEnd = i_end, JEnd = j_end };
                            for (var rowIndex = i; rowIndex <= i_end; rowIndex++)
                            {
                                for (var columnIndex = j; columnIndex <= j_end; columnIndex++)
                                {
                                    currentSum.MaxSum += matrix[rowIndex, columnIndex];
                                }
                            }

                            if (currentSum.MaxSum > sumSubMatrix.MaxSum)
                                sumSubMatrix = currentSum;
                        }
                        
                    }

                    if (sumSubMatrix.MaxSum > result.MaxSum)
                        result = sumSubMatrix;
                }
            }

            return result;
        }
    }
}
