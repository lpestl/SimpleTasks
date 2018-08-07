using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task115cs
{
    class Program
    {
        // Test
        static void Main(string[] args)
        {
            var k = 3; var fans = new[] {7, 12, 5};
            var answer = ColculateHotelsRooms(k, fans);
            Console.WriteLine($"{answer}");

            k = 5; fans = new[] {12, 15, 21};
            answer = ColculateHotelsRooms(k, fans);
            Console.WriteLine($"{answer}");
        }

        private static int ColculateHotelsRooms(int k, int[] fans)
        {
            var res = 0;
            foreach (var fan in fans)
            {
                // Разбиваем фанатов по командам
                var fansWithoutHousing = fan;
                // И заселяем их в комнаты до тех пор, пока все фанаты этой команды не будут заселены
                while (fansWithoutHousing > 0)
                {
                    fansWithoutHousing -= k;
                    // И считаем количество комнат
                    res++;
                }
            }

            return res;
        }
    }
}
