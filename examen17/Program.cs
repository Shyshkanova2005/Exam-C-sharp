///1. Запуск нескольких потоков с использованием Thread
//Задание:
//Напишите консольное приложение, которое запускает 5 потоков, каждый из которых выводит на экран сообщение с задержкой в 1 секунду. После завершения работы всех потоков выведите на экран "Все потоки завершены".

using System;
using System.Threading;

namespace examen17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread tg1 = new Thread(() => DispalyInfo(1));
            Thread tg2 = new Thread(() => DispalyInfo(2));
            Thread tg3 = new Thread(() => DispalyInfo(3));
            Thread tg4 = new Thread(() => DispalyInfo(4));
            Thread tg5 = new Thread(() => DispalyInfo(5));

            tg1.Start();
            tg2.Start();
            tg3.Start();
            tg4.Start();
            tg5.Start();

            tg1.Join();
            tg2.Join();
            tg3.Join();
            tg4.Join();
            tg5.Join();

            static void DispalyInfo(int number)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Задача {number} выполняется");
            }

            Console.WriteLine("Все задачи выполнились");

        }
    }
}
