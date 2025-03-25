//8. Работа с параллельными вычислениями с использованием Parallel.For
//Задание:
//Напишите программу, которая выполняет параллельную обработку массива чисел от 1 до 1000 с использованием Parallel.For.
//Каждое число в массиве должно быть умножено на 2. Выведите на экран измененные элементы массива.
using System;
using System.Threading.Tasks;

namespace task8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] num = new int[1000];
            for (int i = 0; i < num.Length; i++) 
            {
                num[i] = i + 1;
            }
            Parallel.For(0, num.Length, i =>
            {
                num[i] = i * 2;
            });
    
            foreach (var number in num)
            {
                Console.Write(number + " ");
            }
        }
    }
}
