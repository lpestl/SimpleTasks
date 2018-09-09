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

        public static Tuple<int, int[]> SharesBrutForce(int halfSum, List<int> unusedShares)
        {
            var unusedSum = unusedShares.Sum();
            var tupleAnswer = Tuple.Create(unusedSum, unusedShares.ToArray());
            var minDiff = Math.Abs(halfSum - unusedSum);
            if (unusedSum < halfSum)
                return tupleAnswer;
            for (var i = 0; i < unusedShares.Count; i++)
            {
                var newUnusedList = new List<int>();
                newUnusedList.AddRange(unusedShares);
                newUnusedList.RemoveAt(i);
                var checkNewAnswer = SharesBrutForce(halfSum, newUnusedList);
                if (minDiff > Math.Abs(halfSum - checkNewAnswer.Item1))
                {
                    minDiff = Math.Abs(halfSum - checkNewAnswer.Item1);
                    tupleAnswer = checkNewAnswer;
                }
            }

            return tupleAnswer;
        }

        private static Tuple<int[],int[]> CalculateDiversification(int[] shares)
        {
            var inputList = new List<int>();
            var secondShares = new List<int>();
            var half = shares.Sum() / 2;

            inputList.AddRange(shares);
            var optimalPart = SharesBrutForce(half, inputList);
            secondShares.AddRange(shares);
            foreach (var i in optimalPart.Item2)
                secondShares.Remove(i);

            return Tuple.Create(optimalPart.Item2, secondShares.ToArray());
        }
    }
}
