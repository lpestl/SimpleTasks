using System;

namespace Task135cs
{
    class Program
    {
        static void CalcCurrentLayer(int remainderBlocks, int lastLayerLenght, ref ulong count)
        {
            if ((remainderBlocks < 0) || (lastLayerLenght < 0d)) return;
            if (remainderBlocks == 0)
                count++;
            else
            {
                if (remainderBlocks - lastLayerLenght >= 0)
                    CalcCurrentLayer(remainderBlocks - lastLayerLenght, lastLayerLenght - 1, ref count);
                if (lastLayerLenght - 1 > 0)
                    CalcCurrentLayer(remainderBlocks, lastLayerLenght - 1, ref count);
            }
        }

        static ulong CountPosiblePiramids(int count_block)
        {
            ulong count = 0;
            CalcCurrentLayer(count_block, count_block, ref count);
            return count;
        }

        static void Main(string[] args)
        {
            // Tests from task
            Console.WriteLine($"N = {3}; Answer = {CountPosiblePiramids(3)}");
            Console.WriteLine($"N = {5}; Answer = {CountPosiblePiramids(5)}");
            Console.WriteLine($"N = {6}; Answer = {CountPosiblePiramids(6)}");
            // Other Tests
            Console.WriteLine($"N = {7}; Answer = {CountPosiblePiramids(7)}");
            Console.WriteLine($"N = {8}; Answer = {CountPosiblePiramids(8)}");
            Console.WriteLine($"N = {9}; Answer = {CountPosiblePiramids(9)}");
            Console.WriteLine($"N = {10}; Answer = {CountPosiblePiramids(10)}");
            Console.WriteLine($"N = {20}; Answer = {CountPosiblePiramids(20)}");
            Console.WriteLine($"N = {30}; Answer = {CountPosiblePiramids(30)}");
            Console.WriteLine($"N = {40}; Answer = {CountPosiblePiramids(40)}");
            Console.WriteLine($"N = {50}; Answer = {CountPosiblePiramids(50)}");
            Console.WriteLine($"N = {60}; Answer = {CountPosiblePiramids(60)}");
            Console.WriteLine($"N = {70}; Answer = {CountPosiblePiramids(70)}");
            Console.WriteLine($"N = {80}; Answer = {CountPosiblePiramids(80)}");
            Console.WriteLine($"N = {90}; Answer = {CountPosiblePiramids(90)}");
            Console.WriteLine($"N = {100}; Answer = {CountPosiblePiramids(100)}");
            // Test fro chat
            Console.WriteLine($"N = {42}; Answer = {CountPosiblePiramids(42)}");
        }
    }
}
