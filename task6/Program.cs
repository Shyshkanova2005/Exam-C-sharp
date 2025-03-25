//6. Реализация блокировки с использованием SemaphoreSlim
/Задание:
//Создайте программу, которая имитирует работу 10 потоков, каждый из которых выполняет некоторую операцию с задержкой в 1 секунду.
//Используйте SemaphoreSlim для того, чтобы одновременно выполнялось не более 3 потоков. После завершения работы всех потоков выведите "Все потоки завершены".
using System;
using System.Threading;
using System.Collections.Generic;

namespace task6
{
    internal class Program
    {
        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(3);
        private static int resource = 0;

        static void Main(string[] args)
        {
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < 10; i++) 
            {
                Thread thread = new Thread(AccessResource);
                thread.Name = $"Поток {i + 1}";
                thread.Start();
            }
            foreach (var thread in threads)
            {
                thread.Join();
            }
         
        }
        static void AccessResource()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}");
            semaphore.Wait();
            try
            {
                resource++;
                Console.WriteLine($"{Thread.CurrentThread.Name} получил доступ к ресурсу. Текущий ресурс: {resource}");
                Thread.Sleep(1000); 
            }
            finally
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} освобождает доступ к ресурсу.");
                semaphore.Release();
            }
            Console.WriteLine("Все потоки завершены.");

        }
    }
}
