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
    }
}
