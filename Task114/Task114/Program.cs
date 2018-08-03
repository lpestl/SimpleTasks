using System;

namespace Task114
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1, 5, 13, 29, 49, 81, 113, 149, 197, 253, 317 (последовательность A000328 в OEIS).
            for (var i = 1; i <= 10; i++)
                Console.WriteLine($"Radius = {i}; Answer = {NumberOfIntPoints(i)}");

            Console.ReadKey();
        }

        // Количество целочисленных точек внутри круга
        static int NumberOfIntPoints(int radius)
        {
            // счетчик
            var res = 0;
            // в цикле считаем количество целочисленных точек внутри одной четверти круга, (!!!) не лежащих на его осях (поэтому считаем не с нуля, а с единицы)
            for (var x = 1; x <= radius; x++)
                for (var y = 1; y <= radius; y++)
                    if ((x * x + y * y) <= radius * radius)
                        res++;
                    else break;
            // Результат умножаем на количество четвертей у круга, 
            // добавляем количество точек лежащих на осях в четыре стороны от центра,
            // и добавляем центр окружности (по условиям задачи он целочисленный)
            return 1 + 4 * radius + 4 * res;
        }
    }
}
