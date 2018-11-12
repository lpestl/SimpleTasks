using System;
using System.Collections.Generic;
using System.Linq;

namespace Task138cs
{
    class Program
    {
        /*						Метод 01. Простые суммы						 */
        private static int[] SubArrayWithMaxAbsSum1(int[] inputArray)
        {
            // Почему бы не завести два массива для положительных и отрицательных?
            List<int> positive = new List<int>();
            List<int> negative = new List<int>();
            // И посчитаем их сумму
            long sumPositive = 0;
            long sumNegative = 0;
            // Пройдем по всем элементам массива
            foreach (var i in inputArray)
                // Если положительный элемент
                if (i > 0)
                {
                    // Добавим в массив и подсчитаем сумму
                    positive.Add(i);
                    sumPositive += i;
                }
                // Если он отрицательный
                else if (i < 0)
                {
                    // Добавим в подмассив и подсчитаем сумму
                    negative.Add(i);
                    sumNegative -= i;
                }
            // Вернем подмассив в зависимости от того, у которого сумма по модулю больше
            return sumPositive > sumNegative ? positive.ToArray() : negative.ToArray();
        }

        private static int[] SubArrayWithMaxAbsSum11(int[] inputArray)
        {
            // Почему бы не завести два массива для положительных и отрицательных?
            var positive = inputArray.Where(x => x > 0).ToArray();
            var negative = inputArray.Where(x => x < 0).ToArray();
            // Вернем подмассив в зависимости от того, у которого сумма по модулю больше
            return positive.Sum() > Math.Abs(negative.Sum()) ? positive : negative;
        }

        /*						Метод 02. Сумма - индикатор					   */
        private static int[] SubArrayWithMaxAbsSum2(int[] inputArray)
        {
            // Получаем сумму для всего массива
            var sum = inputArray.Sum();
            // Инициализируем вектор для возврата 
            List<int> outputArray = new List<int>();
            // выбираем элементы, которые дадут по модулю максимальную сумму
            foreach (var value in inputArray)
            {
                // Если общая сумма - положительна
                if (sum > 0)
                    // то и конечный подмассив надо строить из положительных элементов
                    if (value > 0)
                        outputArray.Add(value);
                // Аналочино - если сумма отрицательна
                if (sum < 0)
                    if (value < 0)
                        outputArray.Add(value);
            }
            // вернем подмассив
            return outputArray.ToArray();
        }

        private static int[] SubArrayWithMaxAbsSum21(int[] inputArray)
        {
            // Получаем сумму для всего массива
            var sum = inputArray.Sum();
            // Если общая сумма - положительна
            if (sum > 0)
                // Вернем подмассив положительных элементов
                return inputArray.Where(x => x > 0).ToArray();
            // Иначе - отрицательных
            return inputArray.Where(x => x < 0).ToArray();
        }

        /*						Метод 03. Неоптимальный					   */
        private static int[] SubArrayWithMaxAbsSum3(int[] inputArray)
        {
            // Заведем список для сумм
            List<long> sums = new List<long>();
            // И список списков для подмассивов
            List<List<int>> subLists = new List<List<int>>();
            // Максимальной суммой назначим первый элемент массива
            long max = inputArray[0];
            // Пройдем по всем элементам исходного массива
            for (int i = 0; i < inputArray.Length; i++)
            {
                // Назначим текущий элемент - началом подмассива и от него будем считать сумму
                sums.Add(inputArray[i]);
                subLists.Add(new List<int> { inputArray[i] });
                // Проверяем элементы исходного массива начиная со следующего и до конца
                for (int j = i+1; j < inputArray.Length; j++)
                    // Если сумма по модулю со следующим элементом увеличиться
                    if (Math.Abs(sums[i]) < Math.Abs(sums[i] + inputArray[j]))
                    {
                        // То увеличим сумму
                        sums[i] += inputArray[j];
                        // И добавим элемент в подмассив
                        subLists[i].Add(inputArray[j]);
                    }
                // Теперь вычисляем максимальную сумму по модулю и индекс
                if (Math.Abs(sums[i]) > Math.Abs(max))
                    max = sums[i];
            }
            // И возвращаем подмассив с максимальной суммой по модулю
            return subLists[sums.IndexOf(max)].ToArray();
        }

        private static void PrintArray(int[] inputArray)
        {
            Console.Write($"[ {inputArray.First()}");
            for (var i = 1; i < inputArray.Length; i++)
                Console.Write($", {inputArray[i]}");
            Console.WriteLine("]");
        }

        // Tests
        static void Main(string[] args)
        {
            // Test from task
            var inputArray = new[] { -1, 2, -1, 3, -4 };

            Console.Write("Input = ");
            PrintArray(inputArray);
            Console.Write("Answer = ");
            PrintArray(SubArrayWithMaxAbsSum1(inputArray));
            Console.WriteLine("");

            Console.Write("Input = ");
            PrintArray(inputArray);
            Console.Write("Answer = ");
            PrintArray(SubArrayWithMaxAbsSum11(inputArray));
            Console.WriteLine("");

            Console.Write("Input = ");
            PrintArray(inputArray);
            Console.Write("Answer = ");
            PrintArray(SubArrayWithMaxAbsSum2(inputArray));
            Console.WriteLine("");

            Console.Write("Input = ");
            PrintArray(inputArray);
            Console.Write("Answer = ");
            PrintArray(SubArrayWithMaxAbsSum21(inputArray));
            Console.WriteLine("");

            Console.Write("Input = ");
            PrintArray(inputArray);
            Console.Write("Answer = ");
            PrintArray(SubArrayWithMaxAbsSum3(inputArray));
            Console.WriteLine("");
        }
    }
}
