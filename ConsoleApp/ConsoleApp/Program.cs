using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            string? text;
            do
            {                
                Console.Write("Введите произвольный текст: ");
                text = Console.ReadLine();                
            }
            while (text == null || text == "");
                        
            string? dimStr;
            do
            {
                Console.Write("Введите целое число от 1 до 6 - размерность таблицы: ");
                dimStr = Console.ReadLine();
            }
            while (!int.TryParse(dimStr, out int dim) || dim<1 || dim>6 );            
            
            int tableDimension = int.Parse(dimStr);
                        
        }
    }
}
