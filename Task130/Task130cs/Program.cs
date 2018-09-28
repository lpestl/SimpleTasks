using System;
using System.Collections.Generic;
using System.Linq;

namespace Task130cs
{
    class Program
    {
        public static uint Count;

        public static void GetPartitionsBy(int result, int remainder, List<int> summands)
        {
            if (remainder == 0)
            {
                Count++;
                Console.Write(summands.First());
                for (var i = 1; i < summands.Count; i++)
                    Console.Write($"+{summands[i]}");
                Console.WriteLine(";");
                return;
            }

            var currentSummands = new List<int>();
            currentSummands.AddRange(summands);

            var nextSummand = summands.Count == 0 ? remainder : summands.Last();

            while (nextSummand > 0)
            {
                currentSummands.Add(nextSummand);
                if ((remainder - nextSummand) >= 0)
                    GetPartitionsBy(result, remainder - nextSummand, currentSummands);
                currentSummands.RemoveAt(currentSummands.Count - 1);
                nextSummand--;
            }
        }

        public static void GetAllPartitions(int n)
        {
            Count = 0;
            GetPartitionsBy(n, n, new List<int>());
            Console.WriteLine($"Count = {Count}");
            Console.WriteLine("-----------");
        }

        static void Main(string[] args)
        {
            // Tests
            GetAllPartitions(1);
            GetAllPartitions(2);
            GetAllPartitions(3);
            GetAllPartitions(4);
            GetAllPartitions(5);
            GetAllPartitions(6);
            GetAllPartitions(7);
            GetAllPartitions(8);
            GetAllPartitions(9);
            GetAllPartitions(10);
            GetAllPartitions(11);
            GetAllPartitions(12);
            GetAllPartitions(13);
            GetAllPartitions(14);
            GetAllPartitions(15);
            // ...
            GetAllPartitions(30);
            // ...            
            GetAllPartitions(50);
            // ...            
            GetAllPartitions(100);
        }
    }
}