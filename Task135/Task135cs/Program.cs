using System;

namespace Task135cs
{
    class Program
    {
        /// <summary>
        /// Еще один рекурсивный метод перебора всех возможных построений пирамиды
        /// </summary>
        /// <param name="remainderBlocks">количество оставшихся неиспользованных блоков</param>
        /// <param name="maxLayerLenght">максимальная длинна текущего слоя блоков</param>
        /// <param name="count">счетчик пирамид</param>
        static void CalcCurrentLayer(int remainderBlocks, int maxLayerLenght, ref ulong count)
        {
            // Если остаток или максимальная длинна слоя меньше нуля, то вернемся в место вызова функции
            if ((remainderBlocks < 0) || (maxLayerLenght < 0)) return;
            // Если остаток равен нулю
            if (remainderBlocks == 0)
                // значит пирамиду удалось построить
                count++;
            // иначе
            else
            {
                // Если попробовать положить слой и блоки еще остануться (или ровно закончатся)
                if (remainderBlocks - maxLayerLenght >= 0)
                    // То рекурсивно вызовем функцию, для того, чтобы положить следующий слой, который на еденицу меньше текущего
                    CalcCurrentLayer(remainderBlocks - maxLayerLenght, maxLayerLenght - 1, ref count);
                // Если длинну уменьшить на единицу
                if (maxLayerLenght - 1 > 0)
                    // То можно построить пирамиду с меньшим текущим слоем
                    CalcCurrentLayer(remainderBlocks, maxLayerLenght - 1, ref count);
            }
        }

        // Функция для запуска рекурсии
        static ulong CountPosiblePiramids(int count_block)
        {
            // инициализируем счетчик
            ulong count = 0;
            // запускаем рекурсию
            CalcCurrentLayer(count_block, count_block, ref count);
            // вернем результат
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
