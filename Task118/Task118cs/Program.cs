using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task118cs
{
    public static class Tree
    {
        private static List<int> GetBoundedVerhies(int index, int[,] edges)
        {
            var bounded = new List<int>();
            for (var i = 0; i < edges.GetLength(0); i++)
            {
                if (edges[i,0] == index)
                    bounded.Add(edges[i,1]);
                if (edges[i,1] == index)
                    bounded.Add(edges[i,0]);
            }

            return bounded;
        }

        public static int CalculateMaxSumUnboundVerhies(int[] values, int[,] edges)
        {
            var tree = new List<List<int>>();
            for (var i = 0; i < values.Length; i++)
            {
                tree.Add(GetBoundedVerhies(i+1, edges));
            }
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
