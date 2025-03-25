//Задание 10
//Приложение считывает набор чисел с плавающей точкой из файла в список. Необходимо:
//Посчитать квадратный корень каждого числа.
//Результаты сохранить в отдельный файл.
//Для решения задачи используйте метод Parallel.ForEach.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace task10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string numberfile = "number.txt";
            string resultfile = "result.txt";

        
            List<double> numbers = ReadNumbersFromFile(numberfile);

          
            List<double> results = new List<double>(numbers.Count);

           
            Parallel.ForEach(numbers, number =>
            {
                double sq = Math.Sqrt(number); 
                results.Add(sq);
                
            });

          
            WriteResultsToFile(resultfile, results);

            Console.WriteLine("Результаты сохранены в файл.");
        }


        static List<double> ReadNumbersFromFile(string filePath)
        {
            List<double> numbers = new List<double>();
            try
            {
                
                foreach (var line in File.ReadLines(filePath))
                {
                    if (double.TryParse(line, out double number))
                    {
                        numbers.Add(number);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Ошибка при чтении файла.");
            }
            return numbers;
        }


        static void WriteResultsToFile(string filePath, List<double> results)
        {
            try
            {
               
                File.WriteAllLines(filePath, results.Select(result => result.ToString()));
            }
            catch
            {
                Console.WriteLine("Ошибка при записи в файл.");
            }
        }
    }
}
