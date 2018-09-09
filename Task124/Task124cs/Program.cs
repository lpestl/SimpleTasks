using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task124cs
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test01: from task
            var shares01 = new[] {1, 2, 3, 3};
            var answer01 = CalculateDiversification(shares01);
            Console.WriteLine($"FirstShares = \"{string.Join(",", answer01.Item1)}\", FirstTotalValue = {answer01.Item1.Sum()}");
            Console.WriteLine($"SecondShares = \"{string.Join(",", answer01.Item2)}\", SecondTotalValue = {answer01.Item2.Sum()}");

            // Test02: from chat
            var shares02 = new[] {4, 5, 6, 7, 8};
            var answer02 = CalculateDiversification(shares02);
            Console.WriteLine($"FirstShares = \"{string.Join(",", answer02.Item1)}\", FirstTotalValue = {answer02.Item1.Sum()}");
            Console.WriteLine($"SecondShares = \"{string.Join(",", answer02.Item2)}\", SecondTotalValue = {answer02.Item2.Sum()}");


            // Test03: from chat
            var shares03 = new[] { 10, 16, 82, 69, 69, 53, 13, 12, 96, 23 };
            var answer03 = CalculateDiversification(shares03);
            Console.WriteLine($"FirstShares = \"{string.Join(",", answer03.Item1)}\", FirstTotalValue = {answer03.Item1.Sum()}");
            Console.WriteLine($"SecondShares = \"{string.Join(",", answer03.Item2)}\", SecondTotalValue = {answer03.Item2.Sum()}");
        }

        public static void QuickSort(int[] array, int leftIndex, int rightIndex)
        {
            int i = leftIndex, j = rightIndex, x = array[(leftIndex + rightIndex)/2];
            do
            {
                while (array[i] > x)
                    i++;
                while (x > array[j])
                    j--;
                if (i <= j)
                {
                    var temp = array[i];
                    array[i++] = array[j];
                    array[j--] = temp;
                }
            } while (i <= j);
            if (leftIndex < j)
                QuickSort(array, leftIndex, j);
            if (i < rightIndex)
                QuickSort(array, i, rightIndex);
        }

        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
            Console.WriteLine($"{string.Join(", ", array)}");
        }

        private static Tuple<int[],int[]> CalculateDiversification(int[] shares)
        {
            var firstShares = new List<int>();
            var secondShares = new List<int>();
            QuickSort(shares);
            foreach (var share in shares)
            {
                if (firstShares.Sum() < secondShares.Sum()) 
                    firstShares.Add(share);
                else
                    secondShares.Add(share);
            }
            return Tuple.Create(firstShares.ToArray(), secondShares.ToArray());
        }
    }
}
