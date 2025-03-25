///7. Применение Task.WhenAll для ожидания завершения всех задач
//Задание:
//Напишите программу, которая выполняет 5 асинхронных операций, каждая из которых задерживает выполнение на случайное количество времени от 1 до 5 секунд.
//Используйте Task.WhenAll для ожидания завершения всех задач. После завершения выведите на экран сообщение "Все операции завершены".
using System;
using System.Threading.Tasks;

namespace task7
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var tasks = Enumerable.Range(1, 5)
                                  .Select(i => DisplayInfo(i))
                                  .ToArray();
            await Task.WhenAll(tasks);
            Console.WriteLine("Все операции завершены.");
        }
        static async Task DisplayInfo(int taskid)
        {
            Random rnd = new Random();
            int delay = rnd.Next(1000, 5000);
            Console.WriteLine($"Операция {taskid} началась. Задержка: {delay / 1000} секунд.");
            await Task.Delay(delay);
            Console.WriteLine($"Операция {taskid} завершена.");
        }
    }
}
