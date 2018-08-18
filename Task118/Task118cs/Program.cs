using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task118cs
{
    public static class Tree
    {
        public static int CalculateMaxSumUnboundVerhies(int[] values, int[,] edges)
        {
            return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] values = {1, 1, 0, 1};
            int[,] edges = { { 1, 2}, { 1, 3}, { 2, 4} };
            var answer = Tree.CalculateMaxSumUnboundVerhies(values, edges);
            Console.WriteLine(answer);
        }
    }
}
