using System;
using System.Collections.Generic;
using System.Linq;

namespace Task116csDemo
{
    class Program
    {
        // Для решение этой задачи реализуем Алгоритм Дейкстры
        public static LinkedList<int> GetOptimalWay(int[] oilCosts, int[,] trainRoads)
        {
            // Создадим коллекцию для определения пути
            var way = new LinkedList<int>();
            if (oilCosts.Length <= 1) return way;

            // Построим матрицу графа. Цифрой 0 отметятся те пути, которых не существует
            var graph = new int[oilCosts.Length, oilCosts.Length];
            for (var i = 0; i < trainRoads.GetLength(0); i++)
            {
                // Записываем стоимость пути oilCost от населённого пункта trainRoads[i, 0] - 1 до trainRoads[i, 1] - 1
                graph[trainRoads[i, 0] - 1, trainRoads[i, 1] - 1] = oilCosts[trainRoads[i, 0] - 1];
                // И обратно стоимость oilCost от населённого пункта trainRoads[i, 1] - 1 до первоначального
                graph[trainRoads[i, 1] - 1, trainRoads[i, 0] - 1] = oilCosts[trainRoads[i, 1] - 1];
                // Дважды, потому что путь есть и туда и обратно, но только с разной стоимостью
            }

            // Всем вершинам графа кроме первой назначаем максимальный "вес" пути до этой вершины.
            // Максимальным весом обозначим стоимость всех путей из всех точек
            var maxWeight = oilCosts.Sum();
            var weights = new int[oilCosts.Length];
            // Создадим массив для хранения откуда дешевле всего добраться до населенного пункта
            var path = new int[oilCosts.Length];

            // В ходе поиска оптимальных путей до всех вершин графа эти веса будут изменятся в меньшую сторону
            for (var i = 1; i < oilCosts.Length; i++)
                weights[i] = maxWeight;

            // Создадим коллекцию для записи всех посещенных населенных пунктов
            var visited = new List<int>();
            // И текущим населенным пунктом является 1
            int current = 0;

            while (visited.Count < oilCosts.Length)
            {
                // Находим населенный пункт с минимальной стоимостью из еще не посещённых
                float min = weights.Sum();
                for (int i = 0; i < weights.Length; i++)
                {
                    // Если населенный пункт уже был посещен, то его не считаем при поиске минимума
                    if (visited.Contains(i))
                        continue;

                    if (min > weights[i])
                    {
                        min = weights[i];
                        current = i;
                    }
                }

                // Теперь рассмотрим все населенные пункты в которые из текущего есть путь, не содержащий вершин посредников. 
                for (var j = 0; j < oilCosts.Length; j++)
                {
                    // Если населенный пункт был посещен или в него нету пути, то мы его не рассматриваем
                    if (visited.Contains(j) || (graph[current, j] == 0)) continue;
                    if (weights[j] > weights[current] + graph[current, j])
                    {
                        weights[j] = weights[current] + graph[current, j];
                        // Записываем, что из текщего населенного пункта в рассматриваемый дешевле всего доехать
                        path[j] = current;
                    }
                }
                // После того как мы рассмотрели все населенные пункты, в которые есть прямой путь из текущего населенного пункта,
                // мы отмечаем его как посещенный
                visited.Add(current);
            }

            // Текущим назначим пункт назначения (конечный населенный пункт)
            current = oilCosts.Length - 1;
            way.AddFirst(new LinkedListNode<int>(current + 1));
            do
            {
                // В начало коллекции записываем тот населенный пункт, с которого дешевле всего добраться до текущего
                way.AddFirst(new LinkedListNode<int>(path[current] + 1));
                // И меняем текущий на предыдущий
                current = path[current];
            } while (current != 0);/*До тех пор пока не нашли первый населенный пункт*/

            return way;
        }

        // Tests
        static void Main(string[] args)
        {
            // Test из описания задачи
            var oilCoasts1 = new int[] { 5, 10, 1 };
            var trainRoads1 = new int[,] { { 1, 3 }, { 1, 2 }, { 3, 2 } };
            var answer1 = GetOptimalWay(oilCoasts1, trainRoads1);
            var a = answer1.ToList();
            for (var i = 0; i < a.Count; i++)
            {
                Console.Write($"{a[i]}");
                if (i != a.Count - 1) Console.Write("->");
            }
            Console.WriteLine();

            // Empty test
            var oilCoasts2 = new int[] { 0 };
            var trainRoads2 = new int[,] { };
            var answer2 = GetOptimalWay(oilCoasts2, trainRoads2);
            a = answer2.ToList();
            for (var i = 0; i < a.Count; i++)
            {
                Console.Write($"{a[i]}");
                if (i != a.Count - 1) Console.Write("->");
            }
            Console.WriteLine();

            // Test with 5 point
            var oilCoasts3 = new int[] { 10, 20, 30, 40, 50 };
            var trainRoads3 = new int[,] { { 1, 2 }, { 1, 3 }, { 1, 4 }, { 2, 4 }, { 3, 5 }, { 3, 4 }, { 4, 5 } };
            var answer3 = GetOptimalWay(oilCoasts3, trainRoads3);
            a = answer3.ToList();
            for (var i = 0; i < a.Count; i++)
            {
                Console.Write($"{a[i]}");
                if (i != a.Count - 1) Console.Write("->");
            }
            Console.WriteLine();

            // Test with 10 point
            var oilCoasts4 = new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
            var trainRoads4 = new int[,] { { 1, 3 }, { 1, 2 }, { 2, 4 }, { 3, 5 }, { 4, 6 }, { 5, 7 }, { 6, 8 }, { 7, 9 }, { 8, 10 }, { 9, 10 } };
            var answer4 = GetOptimalWay(oilCoasts4, trainRoads4);
            a = answer4.ToList();
            for (var i = 0; i < a.Count; i++)
            {
                Console.Write($"{a[i]}");
                if (i != a.Count - 1) Console.Write("->");
            }
            Console.WriteLine();

            var oilCoasts5 = new int[] {1, 200, 3, 4, 5, 6};
            var trainRoads5 = new int[,] {{1, 2}, {2, 6}, {3, 1}, {3, 4}, {4, 5}, {5, 6}, {2, 5}};
            var answer5 = GetOptimalWay(oilCoasts5, trainRoads5);
            a = answer5.ToList();
            for (var i = 0; i < a.Count; i++)
            {
                Console.Write($"{a[i]}");
                if (i != a.Count - 1) Console.Write("->");
            }
            Console.WriteLine();
        }
    }
}
