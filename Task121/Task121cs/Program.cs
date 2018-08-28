using System;

namespace Task121cs
{
    class Program
    {
        static string ReverteCapsLock(string message)
        {
            var chars = message.ToCharArray();
            string outMessage = String.Empty;
            foreach (var c in chars)
            {
                if (((c >= 'a') && (c <= 'z')) || ((c >= 'а') && (c <= 'я')))
                    outMessage += (char)(c - 32);
                else if (((c >= 'A') && (c <= 'Z')) || ((c >= 'А') && (c <= 'Я')))
                    outMessage += (char) (c + 32);
                else outMessage += c;
            }
            return outMessage;
        }

        static void Main(string[] args)
        {
            string message1 = "cAPS LOCK. я ЛЮБЛЮ ТЕБЯ!";
            Console.WriteLine(ReverteCapsLock(message1));
        }
    }
}
