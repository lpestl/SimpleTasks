using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task51_AnswerFromTheAuthor
{
    class Program
    {
        public class WorkTime
        {
            public int FirstTime { get; set; }  // время упаковки заказа Алисой
            public int SecondTime { get; set; } // время доставки заказа Бобом
        }

        public static bool ComparePairs(WorkTime a, WorkTime b)
        {
            int minOfMin = Math.Min(Math.Min(a.FirstTime, a.SecondTime), Math.Min(b.FirstTime, b.SecondTime));
            if (minOfMin == a.FirstTime || minOfMin == b.SecondTime)
            {
                return false;
            }
            return true;
        }

        public static List<WorkTime> Sort(List<WorkTime> vector)
        {
            int i, j;
            for (i = 0; i < vector.Count; i++)
            {
                for (j = i + 1; j < vector.Count; j++)
                {
                    if (ComparePairs(vector[i], vector[j]))
                    {
                        var tmp = vector[i];
                        vector[i] = vector[j];
                        vector[j] = tmp;
                    }
                }
            }
            return vector;
        }

        public static int GetMinDeliveryTime(List<WorkTime> vector)
        {
            var newVector = Sort(vector);
            int sum = 0, a = 0;
            for (int i = 0; i < newVector.Count; i++)
            {
                a += vector[i].FirstTime;
                sum = Math.Max(a, sum) + vector[i].SecondTime;
            }
            return sum;
        }

        public static void Main()
        {
            Console.WriteLine("UniLecs");
            var vector = new List<WorkTime>()
        {
            new WorkTime() { FirstTime = 4, SecondTime = 5 },
            new WorkTime() { FirstTime = 4, SecondTime = 1 },
            new WorkTime() { FirstTime = 30, SecondTime = 4 },
            new WorkTime() { FirstTime = 6, SecondTime = 30 },
            new WorkTime() { FirstTime = 2, SecondTime = 3 }
        };
            Console.WriteLine(GetMinDeliveryTime(vector));
        }
    }
}
