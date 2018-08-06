using System;

public class Program
{
    static int GetPointsOfCircle(int r)
    {
        int count = 0;
        for (int k = 0; k <= r; k++)
        {
            count += (int)(Math.Sqrt(r * r - k * k)); // округляем до меньшего целого значения
        }

        return 4 * count + 1; // 4 равные части круга + точка в центре
    }

    public static void Main()
    {
        Console.WriteLine("UniLecs");

        Console.WriteLine($"Answer = {GetPointsOfCircle(1)}");  // 5
        Console.WriteLine($"Answer = {GetPointsOfCircle(2)}");  // 13
        Console.WriteLine($"Answer = {GetPointsOfCircle(3)}");  // 29
        Console.WriteLine($"Answer = {GetPointsOfCircle(10)}"); // 317
    }
}