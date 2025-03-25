///3. Использование пула потоков с классом Task
//Задание:
//Напишите программу, которая выполняет 10 параллельных вычислений, каждое из которых состоит в суммировании чисел от 1 до 10000 (в каждом потоке). Используйте класс Task для управления потоками. После завершения всех задач выведите сумму всех результатов.
using System;
using System.Threading.Tasks;

namespace task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Task<int>> tasks = new List<Task<int>>();
            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Run(() => SumNum()));
            }

            Task.WaitAll(tasks.ToArray());

           
            int totalSum = tasks.Sum(task => task.Result);

            
            Console.WriteLine($"Сумма всех результатов: {totalSum}");

            static int SumNum() 
            {
                int sum = 0;
                for(int i = 0;i <= 1000; i++)
                {
                    sum += i;
                }
            return sum;
            }

        }
    }
}
