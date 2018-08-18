using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task118cs
{
    public class Tree
    {
        private struct Node
        {
            public int Index { get; set; }
            public int Value { get; set; }
            public List<Node> BoundedNodes { get; set; }
        }

        private readonly List<Node> _verhies = new List<Node>();
        private static Tree _instance;

        private Tree(int[] values, int[,] edges)
        {
            for(var i = 0; i < values.Length; i++)
                _verhies.Add(new Node { Index = i, Value = values[i], BoundedNodes = new List<Node>()});

            for (var i = 0; i < values.Length; i++)
                for (var j = 0; j < edges.GetLength(0); j++)
                    if (edges[j,0] == i+1) 
                        _verhies[i].BoundedNodes.Add(_verhies[edges[j,1] - 1]);
                    else if (edges[j,1] == i+1)
                        _verhies[i].BoundedNodes.Add(_verhies[edges[j,0] - 1]);
        }
        
        public static int CalculateMaxSumUnboundVerhies(int[] values, int[,] edges)
        {
            _instance = new Tree(values, edges);
            var sum = 0;
            for (var i = 0; i < _instance._verhies.Count; i++)
            {
                var sumI = 0;
                var setI = new List<Node>();
                for (var j = 0; j < _instance._verhies.Count; j++)
                {
                    if (setI.Contains(_instance._verhies[j]))
                        continue;
                    var bounded = false;
                    var children = new List<Node>();
                    foreach (var node in setI)
                        if (_instance._verhies[j].BoundedNodes.Contains(node))
                        {
                            bounded = true;
                            break;
                        }

                }
            }
            return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] values1 = {1, 1, 0, 1};
            int[,] edges1 = { { 1, 2}, { 1, 3}, { 2, 4} };
            var answer1 = Tree.CalculateMaxSumUnboundVerhies(values1, edges1);
            Console.WriteLine(answer1);
            
            int[] values2 = { 1, 0, 1000, 0, 1000, 1, 1 };
            int[,] edges2 = { { 1, 2 }, { 1, 3 }, { 2, 4 }, { 2, 5 }, { 3, 6 }, { 3, 7 } };
            var answer2 = Tree.CalculateMaxSumUnboundVerhies(values2, edges2);
            Console.WriteLine(answer2);
        }
    }
}
