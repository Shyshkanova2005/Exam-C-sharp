///2. Асинхронная операция с использованием async и await Задание:
//Напишите консольное приложение, которое выполняет две асинхронные операции: одна возвращает число через 2 секунды, другая — через 3 секунды. 
//После завершения обеих операций выведите их результаты на экран.

using System;
using System.Threading.Tasks;

namespace task2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Task<int> task1 = GetNumber(1, 2000);
            Task<int> task2 = GetNumber(2, 3000);

            int result1 = await task1;
            int result2 = await task2;

            Console.WriteLine($"Результат первой операции: {result1}");
            Console.WriteLine($"Результат второй операции: {result2}");
        }
        static async Task<int> GetNumber(int number, int delay)
        {
            await Task.Delay(delay);
            return number;
        }
    }
}
