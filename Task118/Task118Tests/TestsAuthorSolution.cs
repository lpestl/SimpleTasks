using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Task118cs;
using Xunit;

namespace Task118Tests
{
    [Collection("Sequential")]
    public class TestsAuthorSolution
    {
        [Fact]
        public void Test00_TaskTest()
        {
            int[] values = { 1, 1, 0, 1 };
            Tuple<int, int>[] treeEdges =
            {
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(1, 3),
                new Tuple<int, int>(2, 4)
            };
            var answer = Program.GetMaxSumInTree(treeEdges, values);
            answer.Should().Be(2);
        }

        [Fact]
        public void Test01_MaxDifLayers()
        {
            int[] values = { 1, 0, 1000, 0, 1000, 1, 1 };
            Tuple<int, int>[] treeEdges =
            {
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(1, 3),
                new Tuple<int, int>(2, 4),
                new Tuple<int, int>(2, 5),
                new Tuple<int, int>(3, 6),
                new Tuple<int, int>(3, 7),
            };
            var answer = Program.GetMaxSumInTree(treeEdges, values);
            answer.Should().Be(2000);
        }

        [Fact]
        public void Test02_NegativeAmounts()
        {
            int[] values = { -1, -1, 0, -1 };
            Tuple<int, int>[] treeEdges =
            {
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(1, 3),
                new Tuple<int, int>(2, 4)
            };
            var answer = Program.GetMaxSumInTree(treeEdges, values);
            answer.Should().Be(0);

            int[] values2 = { -1, 0, -1000, 0, -1000, -1, -1 };
            Tuple<int, int>[] treeEdges2 =
            {
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(1, 3),
                new Tuple<int, int>(2, 4),
                new Tuple<int, int>(2, 5),
                new Tuple<int, int>(3, 6),
                new Tuple<int, int>(3, 7),
            };
            var answer2 = Program.GetMaxSumInTree(treeEdges2, values2);
            answer2.Should().Be(0);
        }

        [Fact]
        public void Test03_DiffAmounts()
        {
            int[] values = { -1, 1, 0, -1 };
            Tuple<int, int>[] treeEdges =
            {
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(1, 3),
                new Tuple<int, int>(2, 4)
            };
            var answer = Program.GetMaxSumInTree(treeEdges, values);
            answer.Should().Be(1);

            int[] values2 = { -1, 0, 1000, 0, -1000, -1, -1 };
            Tuple<int, int>[] treeEdges2 =
            {
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(1, 3),
                new Tuple<int, int>(2, 4),
                new Tuple<int, int>(2, 5),
                new Tuple<int, int>(3, 6),
                new Tuple<int, int>(3, 7),
            };
            var answer2 = Program.GetMaxSumInTree(treeEdges2, values2);
            answer2.Should().Be(1000);
        }

        [Fact]
        public void Test04_AroundSum()
        {
            int[] values = { 10, 50, 1, 10, 10, 10, 10 };
            Tuple<int, int>[] treeEdges =
            {
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(1, 3),
                new Tuple<int, int>(2, 4),
                new Tuple<int, int>(2, 5),
                new Tuple<int, int>(3, 6),
                new Tuple<int, int>(3, 7),
            };
            var answer = Program.GetMaxSumInTree(treeEdges, values);
            answer.Should().Be(70);
        }

        [Fact]
        public void Test05_NewTestFromAuthor()
        {
            int[] values = { 2, 1, 2, 1, 1 };
            var treeEdges = new Tuple<int, int>[]
            {
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(1, 3),
                new Tuple<int, int>(3, 4),
                new Tuple<int, int>(3, 5)
            };
            var answer = Program.GetMaxSumInTree(treeEdges, values);
            answer.Should().Be(4);
        }
    }
}
