using System;
using System.Text;

class Program
{
    static void Main()
    {
        // Ключевое слово
        string keyword = "МИНСК";

        // Зашифрованное сообщение
        string encryptedText = "зчгы очхей, й зчгы гйък щчрейв";

        // Расшифрованное сообщение
        string decryptedText = DecryptTrisemus(encryptedText, keyword);

        // Вывод расшифрованного текста
        Console.WriteLine("Расшифрованное сообщение: " + decryptedText);
    }

    // Расшифрование методом Трисемуса
    static string DecryptTrisemus(string encryptedText, string keyword)
    {
        StringBuilder decryptedText = new StringBuilder();

        // Генерация алфавита для Трисемуса
        string alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

        // Формирование матрицы Трисемуса на основе ключевого слова
        string trisemusMatrix = keyword.ToUpper() + alphabet;

        // Перевод зашифрованного текста в верхний регистр
        encryptedText = encryptedText.ToUpper();

        foreach (char encryptedChar in encryptedText)
        {
            if (char.IsLetter(encryptedChar))
            {
                // Находим индекс символа в матрице Трисемуса
                int index = trisemusMatrix.IndexOf(encryptedChar);

                // Расшифровываем символ, учитывая размер матрицы
                char decryptedChar = trisemusMatrix[(index - 6 + trisemusMatrix.Length) % trisemusMatrix.Length];

                decryptedText.Append(decryptedChar);
            }
            else
            {
                // Если символ не буква, добавляем его в расшифрованный текст без изменений
                decryptedText.Append(encryptedChar);
            }
        }

        return decryptedText.ToString();
    }
}
