using System;

namespace Task121cs
{
    class Program
    {
        // Перевод символов из нижнего регистра в верхний и обратно
        static string ReverteCapsLock(string message)
        {
            // Получаем массив символов из первоначальной строки
            var chars = message.ToCharArray();
            // Инициализируем конечную строку
            string outMessage = String.Empty;
            // Пройдемся по каждому символу
            foreach (var c in chars)
                // И если символ - это маленькая буква из латинского или русского алфавита
                if (((c >= 'a') && (c <= 'z')) || ((c >= 'а') && (c <= 'я')))
                    // То символы верхнего регистра в таблице символов ASCII находятся нумеруются индексом на 32 единицы меньшим
                    outMessage += (char)(c - 32);
                // И в случае с верхним регистром - аналогично
                else if (((c >= 'A') && (c <= 'Z')) || ((c >= 'А') && (c <= 'Я')))
                    outMessage += (char) (c + 32);
                // остальные символы оставляем такими, как они есть
                else outMessage += c;
            // Возвращаем исправленую строку
            return outMessage;
        }

        static void Main(string[] args)
        {
            string message1 = "cAPS LOCK. я ТЕБЯ ненавижу!";
            Console.WriteLine(ReverteCapsLock(message1));
        }
    }
}
