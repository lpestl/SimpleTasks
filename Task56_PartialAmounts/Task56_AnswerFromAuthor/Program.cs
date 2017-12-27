using System;

public class Program
{
    public static int[,] GetPartlySumMatrix(int[,] matrix)
    {
        int[,] sumArr = new int[matrix.GetLength(0) + 1, matrix.GetLength(1) + 1];

        for (int i = 1; i <= matrix.GetLength(0); i++)
        {
            for (int j = 1; j <= matrix.GetLength(1); j++)
            {
                sumArr[i, j] = sumArr[i, j - 1] + sumArr[i - 1, j] - sumArr[i - 1, j - 1] + matrix[i - 1, j - 1];
            }
        }

        return sumArr;
    }

    public static void Main()
    {
        Console.WriteLine("@UniLecs");
        int[,] arr = new int[,]
        {
            { 1, 2, 3, 4, 5 },
            { 5, 4, 3, 2, 1 },
            { 2, 3, 1, 5, 4 }
        };

        int[,] resultArr = GetPartlySumMatrix(arr);

        for (int i = 1; i < resultArr.GetLength(0); i++)
        {
            for (int j = 1; j < resultArr.GetLength(1); j++)
            {
                Console.Write("{0} ", resultArr[i, j]);
            }
            Console.WriteLine();
        }
    }
}