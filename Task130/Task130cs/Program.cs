using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Task130cs
{
    class Program
    {
        // Счетчик количества разложений на слагаемые
        public static ulong Count;
        // Рекурсиваня функция, которая получает все разлодения от последнего слагаемого из списка Summands
        public static void GetPartitionsBy(int remainder, List<int> summands)
        {
            // Если остаток от суммы равен нулю
            if (remainder == 0)
            {
                // То текущий набор слагаемых - одно из разложений
                Count++;
                // Выводим его на экран сразу
                Console.Write(summands.First());
                for (var i = 1; i < summands.Count; i++)
                    Console.Write($"+{summands[i]}");
                Console.WriteLine(";");
                // И выходим из рекрсии
                return;
            }

            // Заводим новый список слагаемых
            var currentSummands = new List<int>();
            // Добавляем его из текщего неполного списка
            currentSummands.AddRange(summands);
            // И следующим слагаемым назначаем последнее слагаемое из списка если оно есть, иначе максимальное слагаемое будет равно остатку
            var nextSummand = summands.Count == 0 ? remainder : summands.Last();
            // Перебираем до тех пор, пока слагаемое больше нуля
            while (nextSummand > 0)
            {
                // Добавляем в список слагаемых, текущее слагаемое
                currentSummands.Add(nextSummand);
                // Если разница остатка с текущим слагаемым больше либо равно нулю
                if ((remainder - nextSummand) >= 0)
                    // Значит продолжаем рекурсиб и перебераем все следующие слагаемые
                    GetPartitionsBy(remainder - nextSummand, currentSummands);
                // Уберем из списка слагаемых последнее слагаемое
                currentSummands.RemoveAt(currentSummands.Count - 1);
                // И уменьшим его на единицу
                nextSummand--;
            }
        }

        // Функия для запуска рекурсии и поиска всех разложений
        public static void GetAllPartitions(int n)
        {
            // Обнуляем глобальный счетчик
            Count = 0;
            // Запускаем рекрсию
            GetPartitionsBy(n, new List<int>());
            // Подводим итог
            Console.WriteLine($"Count = {Count}");
            Console.WriteLine("-----------");
        }

        static void Main(string[] args)
        {
            // Tests
            var sw = new Stopwatch();
            sw.Start();
            //GetAllPartitions(1);
            //GetAllPartitions(2);
            //GetAllPartitions(3);
            //GetAllPartitions(4);
            //GetAllPartitions(5);
            //GetAllPartitions(6);
            //GetAllPartitions(7);
            //GetAllPartitions(8);
            //GetAllPartitions(9);
            //GetAllPartitions(10);
            //GetAllPartitions(11);
            //GetAllPartitions(12);
            //GetAllPartitions(13);
            //GetAllPartitions(14);
            //GetAllPartitions(15);
            // ...
            GetAllPartitions(30);
            // ...            
            //GetAllPartitions(50);
            //// ...            
            //GetAllPartitions(100);
            sw.Stop();
            Console.WriteLine($"Estimated runtime is {(sw.ElapsedMilliseconds / 1000) / 60 } m. {(sw.ElapsedMilliseconds / 1000) % 60} s. {sw.ElapsedMilliseconds % 1000} ms.");
        }
    }
}