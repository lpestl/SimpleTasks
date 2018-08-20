using System;
using System.Collections.Generic;

public class Program
{
    static Dictionary<int, List<int>> treeNodes;
    static int[] treeData;

    // Здесь можно использовать обычный двумерный массив, но для удобства воспользуем обьектом Dictionary<int, List>
    // Формируем словарик: Вершина "ключ" -> Список вершин с ктр "вершина-ключ" имеет ребра
    static Dictionary<int, List<int>> GetTreeNodeDict(Tuple<int, int>[] edges)
    {
        var treeNodes = new Dictionary<int, List<int>>();
        for (int i = 0; i < edges.Length; i++)
        {
            int firstNode = edges[i].Item1 - 1;
            int secondNode = edges[i].Item2 - 1;
            if (!treeNodes.ContainsKey(firstNode))
            {
                treeNodes.Add(firstNode, new List<int>() { secondNode });
            }
            else
            {
                treeNodes[firstNode].Add(secondNode);
            }

            if (!treeNodes.ContainsKey(secondNode))
            {
                treeNodes.Add(secondNode, new List<int>() { firstNode });
            }
            else
            {
                treeNodes[secondNode].Add(firstNode);
            }
        }
        return treeNodes;
    }

    public static int GetMaxSumInTree(Tuple<int, int>[] edges, int[] value)
    {
        int nodeCount = value.Length;
        // сумма на дереве по 1му правилу: считаем сумму на дереве учитывая текущую вершину
        int[] firstSum = new int[nodeCount];

        // сумма на дереве по 1му правилу: считаем сумму на дереве НЕ учитывая текущую вершину
        int[] secondSum = new int[nodeCount];
        treeNodes = GetTreeNodeDict(edges);
        treeData = value;

        // Запускаем поиск в глубину на дереве из вершины 1 (нумерация с нуля)
        Dfs(firstSum, secondSum, 0);

        // для вершины 1 берем макс. из сумм
        return Math.Max(firstSum[0], secondSum[0]);
    }

    static void Dfs(int[] firstSum, int[] secondSum, int v, int parent = -1)
    {
        firstSum[v] = treeData[v]; // учитываем текущую вершину
        secondSum[v] = 0;   // не учитываем текущую вершину

        // для текущей вершины v просматриваем все дочерние вершины (вершины ктр соединены ребром!)
        foreach (var node in treeNodes[v])
        {
            // берем только дочерние вершины (всех предков мы уже посмотрели)
            if (node != parent)
            {
                // запускаем функцию для дочерней вершины node, родитель - v
                Dfs(firstSum, secondSum, node, v);

                // Тонкий момент: по условию задачи мы не можем брать соседние вершины (те ктр соединены ребром),
                // то для firstSum мы будем учитывать уже "внуков" (или дочерние элементы для node), 
                // а саму вершину node не учитываем. А для secondSum уже все наоборот!
                firstSum[v] += secondSum[node];
                secondSum[v] += Math.Max(firstSum[node], secondSum[node]);
            }
        }
    }

    public static void Main()
    {
        Console.WriteLine("UniLecs");

        // тут можно было использовать двумерный массив,
        // но для удобства воспользуемся типом Tuple 
        Tuple<int, int>[] treeEdges =
        {
            new Tuple<int, int>(1, 2),
            new Tuple<int, int>(1, 3),
            new Tuple<int, int>(2, 4)
        };
        int[] value = new int[] { 1, 1, 0, 1 };
        Console.WriteLine(string.Format("Answer = {0}", GetMaxSumInTree(treeEdges, value))); // 2

        treeEdges = new Tuple<int, int>[]
        {
            new Tuple<int, int>(1, 2),
            new Tuple<int, int>(1, 3),
            new Tuple<int, int>(3, 4),
            new Tuple<int, int>(3, 5)
        };
        value = new int[] { 2, 1, 2, 1, 1 };
        Console.WriteLine(string.Format("Answer = {0}", GetMaxSumInTree(treeEdges, value))); // 4
    }
}