﻿using System;
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
            var oilCoasts = new int[] { 5, 10, 1 };
            var trainRoads = new int[,] { {1, 3}, {1, 2}, {3, 2} };

            var a = OptimalWay.GetOptimalWay(oilCoasts, trainRoads);
            var answer = a.ToList();

            answer.Count.Should().Be(2);
            answer[0].Should().Be(1);
            answer[1].Should().Be(3);
        }

        [Fact]
        public void Test01_NullTest()
        {
            var oilCoasts = new int[] { 5 };
            var trainRoads = new int[,] { };

            var a = OptimalWay.GetOptimalWay(oilCoasts, trainRoads);
            var answer = a.ToList();

            answer.Count.Should().Be(0);
        }

        [Fact]
        public void Test02_FivePointGraph()
        {
            var oilCoasts = new int[] { 10, 20, 30, 40, 50 };
            var trainRoads = new int[,] { {1,2}, {1,3}, {1,4}, {2,4}, {3, 5}, {3, 4}, {4, 5} };

            var a = OptimalWay.GetOptimalWay(oilCoasts, trainRoads);
            var answer = a.ToList();

            answer.Count.Should().Be(3);
            answer[0].Should().Be(1);
            answer[1].Should().Be(3);
            answer[2].Should().Be(5);
        }

        [Fact]
        public void Test03_CircleGraph()
        {
            var oilCoasts = new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
            var trainRoads = new int[,] { {1,3}, {1,2}, {2,4}, {3,5}, {4,6}, {5,7}, {6,8}, {7,9}, {8, 10}, {9, 10} };

            var a = OptimalWay.GetOptimalWay(oilCoasts, trainRoads);
            var answer = a.ToList();

            answer.Count.Should().Be(6);
            answer[0].Should().Be(1);
            answer[1].Should().Be(2);
            answer[2].Should().Be(4);
            answer[3].Should().Be(6);
            answer[4].Should().Be(8);
            //answer[1].Should().Be(3);
            //answer[2].Should().Be(5);
            //answer[3].Should().Be(7);
            //answer[4].Should().Be(9);
            answer[5].Should().Be(10);
        }
    }
}
