using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace task9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
            Thread tg1 = new Thread(() => AddItems(queue));
            Thread tg2 = new Thread(() => ConsumeItems(queue));
            tg1.Start();
            tg2.Start();

            tg1.Join();
            tg2.Join();

            Console.WriteLine("Все операции завершены.");
        }
        static void AddItems(ConcurrentQueue<int> queue)
        {
            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
                Console.WriteLine($"Добавлено: {i}");
            }
        }
        static void ConsumeItems(ConcurrentQueue<int> queue)
        {
            while (true)
            {

                if (queue.TryDequeue(out int result))
                {
                    Console.WriteLine($"Извлечено: {result}");
                    Thread.Sleep(1000);
                }
                else
                {
                    break;
                }
            }

        }
    }
}
