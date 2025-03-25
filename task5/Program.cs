//5. Использование Monitor для синхронизации
//Задание:
//Напишите программу, которая создает 3 потока. Каждый поток должен поочередно захватывать и освобождать монитор для общего ресурса (например, строки)
//используя методы Monitor.Enter и Monitor.Exit. Убедитесь, что потоки не выполняются одновременно. Выведите на экран, в каком порядке выполнялись потоки.
using System;
using System.Threading;

namespace task5
{
    internal class Program
    {
        private static readonly object monitorObject = new object();
        static void Main(string[] args)
        {
            Thread tg1 = new Thread(() => DispalyInfo("Поток 1"));
            Thread tg2 = new Thread(() => DispalyInfo("Поток 2"));
            Thread tg3 = new Thread(() => DispalyInfo("Поток 3"));

            tg1.Start();
            tg2.Start();
            tg3.Start();

            tg1.Join(); 
            tg2.Join();
            tg3.Join();

            Console.WriteLine("Все потоки завершены.");
        }
        static void DispalyInfo(string monitorName) 
        {
            for (int i = 0; i < 3; i++) 
            {
                Monitor.Enter(monitorObject);
                try
                {
                    Console.WriteLine($"{monitorName} захватил монитор.");
                }
                finally
                {
                    Monitor.Exit(monitorObject);
                }
                Thread.Sleep(400);
            }
        }
    }
}
