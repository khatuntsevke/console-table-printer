using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ввод данных
            string? dimStr;
            do
            {
                Console.Write("Введите размерность таблицы (целое число от 1 до 6): ");
                dimStr = Console.ReadLine();
            }
            while (!int.TryParse(dimStr, out int dim) || dim < 1 || dim > 6);
            int tableDimension = int.Parse(dimStr);

            string? text;
            do
            {                
                Console.Write("Введите произвольный текст: ");
                text = Console.ReadLine();                
            }
            while (text == null || text == "");

            // Конфигурация таблицы
            var table = new OtusTable(text, tableDimension, maxRowSize: 40);

            // Вывод таблицы в консоль
            table.Print();
        }
    }
}
