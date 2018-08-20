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
    public class SimpleTests
    {
        [Fact]
        public void Test00_TaskTest()
        {
            int[] values = { 1, 1, 0, 1 };
            int[,] edges = { { 1, 2 }, { 1, 3 }, { 2, 4 } };
            var answer = Tree.CalculateMaxSumUnboundVerhies(values, edges);
            answer.Should().Be(2);
        }

        [Fact]
        public void Test01_MaxDifLayers()
        {
            int[] values = {1, 0, 1000, 0, 1000, 1, 1};
            int[,] edges = {{1, 2}, {1, 3}, {2, 4}, {2, 5}, {3, 6}, {3, 7}};
            var answer = Tree.CalculateMaxSumUnboundVerhies(values, edges);
            answer.Should().Be(2000);
        }

        [Fact]
        public void Test02_NegativeAmounts()
        {
            int[] values = { -1, -1, 0, -1 };
            int[,] edges = { { 1, 2 }, { 1, 3 }, { 2, 4 } };
            var answer = Tree.CalculateMaxSumUnboundVerhies(values, edges);
            answer.Should().Be(0);

            int[] values2 = { -1, 0,-1000, 0, -1000, -1, -1 };
            int[,] edges2 = { { 1, 2 }, { 1, 3 }, { 2, 4 }, { 2, 5 }, { 3, 6 }, { 3, 7 } };
            var answer2 = Tree.CalculateMaxSumUnboundVerhies(values2, edges2);
            answer2.Should().Be(0);
        }

        [Fact]
        public void Test03_DiffAmounts()
        {
            int[] values = { -1, 1, 0, -1 };
            int[,] edges = { { 1, 2 }, { 1, 3 }, { 2, 4 } };
            var answer = Tree.CalculateMaxSumUnboundVerhies(values, edges);
            answer.Should().Be(1);

            int[] values2 = { -1, 0, 1000, 0, -1000, -1, -1 };
            int[,] edges2 = { { 1, 2 }, { 1, 3 }, { 2, 4 }, { 2, 5 }, { 3, 6 }, { 3, 7 } };
            var answer2 = Tree.CalculateMaxSumUnboundVerhies(values2, edges2);
            answer2.Should().Be(1000);
        }

        [Fact]
        public void Test04_AroundSum()
        {
            int[] values = { 10, 50, 1, 10, 10, 10, 10 };
            int[,] edges = { { 1, 2 }, { 1, 3 }, { 2, 4 }, { 2, 5 }, { 3, 6 }, { 3, 7 } };
            var answer = Tree.CalculateMaxSumUnboundVerhies(values, edges);
            answer.Should().Be(70);
        }

        [Fact]
        public void Test05_NewTestFromAuthor()
        {
            int[] values = {2, 1, 2, 1, 1};
            int[,] edges = {{1, 2}, {1, 3}, {3, 4}, {3, 5}};
            var answer = Tree.CalculateMaxSumUnboundVerhies(values, edges);
            answer.Should().Be(4);
        }

        [Fact]
        public void Test06_OnlyNegative()
        {
            int[] values = { -2, -1, -2, -1, -1 };
            int[,] edges = { { 1, 2 }, { 1, 3 }, { 3, 4 }, { 3, 5 } };
            var answer = Tree.CalculateMaxSumUnboundVerhies(values, edges);
            answer.Should().Be(-1);
        }
    }
}
