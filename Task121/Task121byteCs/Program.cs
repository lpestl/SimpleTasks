using System;

namespace Task121byteCs
{
    // Статический класс - Helper
    public static class StringHelper
    {
        // Метод для типа string, который переводит нижний регистр в верхний и наоборот и возвращает новую исправленную строку
        public static string ToMirrorRegister(this string str)
        {
            // Преобразуем оригинальную строку в массив символов
            var chars = str.ToCharArray();
            // Пройдемся по каждому символу
            for(var i = 0; i < chars.Length; i++)
                // Символ мением на новое значение. ЕСЛИ он больше 'a' И меньше 'z' ИЛИ он больше 'а' И меньше 'я'
                chars[i] = (((chars[i] >= 0x61) && (chars[i] <= 0x7A)) || ((chars[i] >= 0x430) && (chars[i] <= 0x44F)))
                            // то меняем его на заглавный символ (заглавный символ меньше маленького в ASCII коде на 32)
                            ? (char) (chars[i] - 0x20)
                            // иначе ЕСЛИ он больше 'A' И меньше 'Z' ИЛИ он больше 'А' И меньше 'Я'
                            : (((chars[i] >= 0x41) && (chars[i] <= 0x5A)) || ((chars[i] >= 0x410) && (chars[i] <= 0x42F)))
                                // то меняем на заглавный
                                ? (char) (chars[i] + 0x20)
                                // иначе оставляем без изменений
                                : chars[i];
            return new string(chars);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Test 1
            string message = "cAPS LOCK. я ТЕБЯ ненавижу!";
            Console.WriteLine(message.ToMirrorRegister());

            // Test 2
            Console.WriteLine("еЩЁ ОДНА кРиВаЯ СТРОКА".ToMirrorRegister());
        }
    }
}
