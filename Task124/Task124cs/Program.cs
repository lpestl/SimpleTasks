using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task124cs
{
    class Program
    {
        // Рекурсивный метод для перебора всех возможных наборов сумм подмасивов
        // Первый параметр - для сравнения с точной половиной суммы основного массива
        // Второй параметр - коллекция оставшихся неиспользованных элементов массива
        public static Tuple<int, int[]> SharesBrutForce(int halfSum, List<int> unusedShares)
        {
            // Пара для значения суммы и массива неиспользованных элементов
            var tupleAnswerMin = Tuple.Create(unusedShares.Sum(), unusedShares.ToArray());
            // Если сумма неиспользованных элементов стала меньше половины суммы изначального массива
            if (tupleAnswerMin.Item1 < halfSum)
                // То вернем этот набор данных
                return tupleAnswerMin;
            // Пройдем по всем неиспользованным элементам
            for (var i = 0; i < unusedShares.Count; i++)
            {
                // Сделаем копию массива
                var newUnusedList = new List<int>();
                newUnusedList.AddRange(unusedShares);
                // И удалим текущий элемент
                newUnusedList.RemoveAt(i);
                // Проверим сумму оставшихся элементов
                var checkNewAnswer = SharesBrutForce(halfSum, newUnusedList);
                // Если она меньше минимальной
                if (Math.Abs(halfSum - tupleAnswerMin.Item1) > Math.Abs(halfSum - checkNewAnswer.Item1))
                    // То назначим текущую минимальной
                    tupleAnswerMin = checkNewAnswer;
            }
            // И вернем значение суммы одной части и массив этой части, который даст минимальную разницу с оставшейся частью исходного массива
            return tupleAnswerMin;
        }

        // Вычислить почти равнозначные части массива 
        public static Tuple<int[], int[]> CalculateDiversification(int[] shares)
        {
            // Заведем две коллекции для передачи в рекурсивную функцию
            var inputList = new List<int>();
            inputList.AddRange(shares);
            // И для хранения второй равновесной части массива
            var secondShares = new List<int>();
            // вычислим половину суммы
            var half = shares.Sum() / 2;
            // Рекурсивно вычисляем оптимальную часть из основнога массива
            var optimalPart = SharesBrutForce(half, inputList);
            // И вторую часть, исключив из основного массиыва первую часть
            secondShares.AddRange(shares);
            foreach (var i in optimalPart.Item2)
                secondShares.Remove(i);
            // И вернем ответ
            return Tuple.Create(optimalPart.Item2, secondShares.ToArray());
        }
        static void Main(string[] args)
        {
            // Test01: from task
            var shares01 = new[] {1, 2, 3, 3};
            var answer01 = CalculateDiversification(shares01);
            Console.WriteLine($"FirstShares = \"{string.Join(",", answer01.Item1)}\", FirstTotalValue = {answer01.Item1.Sum()}");
            Console.WriteLine($"SecondShares = \"{string.Join(",", answer01.Item2)}\", SecondTotalValue = {answer01.Item2.Sum()}");
            Console.WriteLine();

            // Test02: from chat
            var shares02 = new[] {4, 5, 6, 7, 8};
            var answer02 = CalculateDiversification(shares02);
            Console.WriteLine($"FirstShares = \"{string.Join(",", answer02.Item1)}\", FirstTotalValue = {answer02.Item1.Sum()}");
            Console.WriteLine($"SecondShares = \"{string.Join(",", answer02.Item2)}\", SecondTotalValue = {answer02.Item2.Sum()}");
            Console.WriteLine();

            // Test03: from chat
            var shares03 = new[] { 10, 16, 82, 69, 69, 53, 13, 12, 96, 23 };
            var answer03 = CalculateDiversification(shares03);
            Console.WriteLine($"FirstShares = \"{string.Join(",", answer03.Item1)}\", FirstTotalValue = {answer03.Item1.Sum()}");
            Console.WriteLine($"SecondShares = \"{string.Join(",", answer03.Item2)}\", SecondTotalValue = {answer03.Item2.Sum()}");
            Console.WriteLine();
        }
    }
}
