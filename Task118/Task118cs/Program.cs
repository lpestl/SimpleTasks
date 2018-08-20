using System;
using System.Collections.Generic;
using System.Linq;

namespace Task118cs
{
    public class Tree
    {
        private class Node
        {
            // Индекс нода
            public int Index { get; set; }
            // Значение нода
            public int Value { get; set; }
            // Список связанных (соседних) нодов
            public List<Node> BoundedNodes { get; set; }
        }
        // Список всех нодов
        private readonly List<Node> _verhies = new List<Node>();
        private static Tree _instance;

        private Tree(int[] values, int[,] edges)
        {
            // Проходим по всем вершинам и создаем для них объекты класса Node
            for(var i = 0; i < values.Length; i++)
                _verhies.Add(new Node { Index = i, Value = values[i], BoundedNodes = new List<Node>()});
            // И по всем ребрам, добавляя записи о связанных нодах для текущего
            for (var i = 0; i < values.Length; i++)
                for (var j = 0; j < edges.GetLength(0); j++)
                    // Не важно в какую сторону
                    if (edges[j,0] == i+1) 
                        _verhies[i].BoundedNodes.Add(_verhies[edges[j,1] - 1]);
                    else if (edges[j,1] == i+1)
                        _verhies[i].BoundedNodes.Add(_verhies[edges[j,0] - 1]);
        }
        
        public static int? CalculateMaxSumUnboundVerhies(int[] values, int[,] edges)
        {
            // Собираем дерево
            _instance = new Tree(values, edges);
            // Сумма пустого множества будет равна null: подрорбнее в чате UniLecs
            int? sum = null;
            // Пройдем по всем нодам
            foreach (var firrstNode in _instance._verhies)
            {
                // Создаем множество и добавляем в него текущий ноду
                var setI = new List<Node> {firrstNode};
                if (!sum.HasValue)
                    sum = firrstNode.Value;
                // Теперь найдем и добавим все несвязанные ноды с элементами из множдества setI
                foreach (var potentialNode in _instance._verhies)
                {
                    // Если нод уже есть во множестве - то пропускаем его
                    if (setI.Find(x => x.Index == potentialNode.Index) != null)
                        continue;
                    // Если хоть один связанный нод уже есть во множестве - тоже пропускаем его
                    var bounded = false;
                    foreach (var node in setI)
                        if (potentialNode.BoundedNodes.Find(x => x.Index == node.Index) != null)
                        {
                            bounded = true;
                            break;
                        }
                    if (bounded) continue;
                    // Создадим список нодов, который будут содержать ноды, дети которых не связаны ни с одним нодом из множества
                    var children = new List<Node>();
                    // Сначала добавим все связанные ноды
                    children.AddRange(potentialNode.BoundedNodes);
                    foreach (var node in setI)
                    {
                        // Найдем досерние ноды, которые имеют детей связанных хоть с одним объектом из множества
                        var boundedChild = children.Find(x => x.BoundedNodes.Find(y => y.Index == node.Index) != null);
                        if (boundedChild != null)
                            // И если такие есть - то удаляем их из списка
                            children.Remove(boundedChild);
                    }

                    var sumChildren = children.Sum(x => x.Value);
                    // Важное дополнение: если рассматриваемый нод или его дети не увеличивают сумм, то не добавляем во множество ничего
                    if ((sum + potentialNode.Value > sum) || (sum + sumChildren > sum))
                    {
                        // Если значение текущего нода больше суммы значений его не связанных детей
                        if (potentialNode.Value >= sumChildren)
                            // то добавляем сам нод во множество
                            setI.Add(potentialNode);
                        else
                            // Иначе, добавляем его не связанных детей
                            setI.AddRange(children);
                    }
                }
                // Если сумма в текущем множестве больше ранее посчитанной суммы
                if (sum < setI.Sum(x => x.Value))
                    // то обновим сумму
                    sum = setI.Sum(x => x.Value);
            }
            return sum;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Тест 1
            int[] values1 = {1, 1, 0, 1};
            int[,] edges1 = { { 1, 2}, { 1, 3}, { 2, 4} };
            var answer1 = Tree.CalculateMaxSumUnboundVerhies(values1, edges1);
            Console.WriteLine(answer1);
            
            // Тест 2
            int[] values2 = { 1, 0, 1000, 0, 1000, 1, 1 };
            int[,] edges2 = { { 1, 2 }, { 1, 3 }, { 2, 4 }, { 2, 5 }, { 3, 6 }, { 3, 7 } };
            var answer2 = Tree.CalculateMaxSumUnboundVerhies(values2, edges2);
            Console.WriteLine(answer2);
        }
    }
}
