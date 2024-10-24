using System; // Подключаем пространство имен System, которое содержит базовые классы и структуры языка C#

class Program
{
    // Метод для генерации матрицы Playfair по ключу
    static char[,] GeneratePlayfairMatrix(string key)
    {
        // Алфавит без буквы 'J'
        string alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
        // Убираем дублирующиеся символы из ключа и приводим к верхнему регистру
        key = new string(key.Distinct().ToArray()).ToUpper();
        // Создаем новый алфавит, исключая символы из ключа
        alphabet = new string(alphabet.Except(key).ToArray()) + key;
        // Создаем матрицу 5x5
        char[,] matrix = new char[5, 5];
        int index = 0;

        // Заполняем матрицу символами из нового алфавита
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                matrix[i, j] = alphabet[index];
                index++;
            }
        }
        // Возвращаем сформированную матрицу
        return matrix;
    }

    // Метод для подготовки сообщения перед шифрованием
    static string PrepareMessage(string message)
    {
        // Приводим сообщение к верхнему регистру, заменяем 'J' на 'I' и убираем пробелы
        message = message.ToUpper().Replace("J", "I").Replace(" ", "");
        string preparedMessage = "";
        for (int i = 0; i < message.Length; i += 2)
        {
            // Если символы одинаковые или текущая пара заканчивается, добавляем 'X'
            if (i == message.Length - 1 || message[i] == message[i + 1])
            {
                preparedMessage += message[i] + "X";
                i--;
            }
            else
            {
                // Иначе добавляем текущую пару символов
                preparedMessage += message[i] + message[i + 1];
            }
        }
        // Возвращаем подготовленное сообщение
        return preparedMessage;
    }

    // Метод для шифрования методом Playfair
    static string EncryptPlayfairCipher(string message, char[,] matrix)
    {
        string encryptedMessage = "";
        for (int i = 0; i < message.Length; i += 2)
        {
            char char1 = message[i];
            char char2 = message[i + 1];
            int row1 = 0, col1 = 0, row2 = 0, col2 = 0;

            // Находим координаты символов в матрице
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if (matrix[row, col] == char1)
                    {
                        row1 = row;
                        col1 = col;
                    }
                    if (matrix[row, col] == char2)
                    {
                        row2 = row;
                        col2 = col;
                    }
                }
            }

            int newRow1, newCol1, newRow2, newCol2;
            // Если символы находятся в одной строке, сдвигаем их вправо
            if (row1 == row2)
            {
                newRow1 = row1;
                newRow2 = row2;
                newCol1 = (col1 + 1) % 5;
                newCol2 = (col2 + 1) % 5;
            }
            // Если символы находятся в одном столбце, сдвигаем их вниз
            else if (col1 == col2)
            {
                newCol1 = col1;
                newCol2 = col2;
                newRow1 = (row1 + 1) % 5;
                newRow2 = (row2 + 1) % 5;
            }
            // Если символы образуют прямоугольник, меняем их местами внутри прямоугольника
            else
            {
                newRow1 = row1;
                newRow2 = row2;
                newCol1 = col2;
                newCol2 = col1;
            }

            // Добавляем зашифрованные символы к результату
            encryptedMessage += matrix[newRow1, newCol1] + "" + matrix[newRow2, newCol2];
        }
        // Возвращаем зашифрованное сообщение
        return encryptedMessage;
    }

    static void Main()
    {
        // Печатаем приглашение к вводу сообщения и ключа
        Console.WriteLine("Enter your message: ");
        string message = Console.ReadLine();

        Console.WriteLine("Enter the key: ");
        string key = Console.ReadLine();

        // Генерируем матрицу Playfair на основе ключа
        char[,] matrix = GeneratePlayfairMatrix(key);
        // Подготавливаем сообщение для шифрования
        string preparedMessage = PrepareMessage(message);
        // Шифруем сообщение и выводим результат
        string encryptedMessage = EncryptPlayfairCipher(preparedMessage, matrix);
        Console.WriteLine("Encrypted message: " + encryptedMessage);
    }
}
