using System;
using System.Threading;

//4. Синхронизация потоков с помощью lock
//Задание:
//Напишите программу, которая создает 5 потоков, каждый из которых выполняет инкремент общей переменной. Для синхронизации доступа к общей переменной используйте ключевое слово lock. После выполнения всех потоков выведите значение общей переменной.

namespace task4
{
    internal class Program
    {
         static object lockcounter = new object();
         static int sharedCounter = 0;

        static void Main(string[] args)
        {
            Thread[] tg = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                tg[i] = new Thread(IncrementCounter);
                tg[i].Start();
            }
            foreach (Thread thread in tg)
            {
                thread.Join();
            }
            Console.WriteLine($"Значение общей переменной после выполнения всех потоков: {sharedCounter}");
        }
    
        static void IncrementCounter() 
        {
            for(int i = 0;i < 5; i++)
            {
                lock (lockcounter)
                {
                    sharedCounter++;
                }
            }
           
        }
    }
}
