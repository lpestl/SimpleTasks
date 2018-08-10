using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task116cs
{
    public class OptimalWay
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
                    if (visited.Contains(j) || (graph[current, j] != 0)) continue;
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


    }
}
