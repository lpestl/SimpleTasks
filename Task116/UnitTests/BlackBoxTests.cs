using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using System.Text;
using System.Threading.Tasks;
using Task116cs;
using Xunit;

namespace UnitTests
{
    [Collection("Sequential")]
    public class BlackBoxTests
    {
        [Fact]
        public void Test00_FromTask()
        {
            var oilCoasts = new List<float>() { 5, 10, 1 };
            var trainRoads = new List<ulong[]>() { new ulong[]{1, 3}, new ulong[] {1, 2}, new ulong[]{3, 2}};
            var answer = OptimalWay.GetOptimalWay(oilCoasts, trainRoads);

            answer.Count.Should().Be(2);
            answer[0].Should().Be(1);
            answer[1].Should().Be(3);
        }
    }
}
