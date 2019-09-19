using System;

namespace lab2
{
    class Program22
    {
        public static bool doSomething(int[] someVector)
        {
            int sum = 0, count = 0;


            foreach (var number in someVector)
            {
                if (number % 5 == 0 && number % 7 != 0)
                {
                    //Console.WriteLine(number);
                    sum += number;
                    count++;
                    
                }
            }

            if (count > 0)
            {
                Console.WriteLine("Сумма: " + sum);
                Console.WriteLine("Количество: " + count);
                return true;
            }
            else
            {
                Console.WriteLine("Таких элементов нет");
                return false;
            }

        }

        static void Main(string[] args)
        {
            int[] vector = new int[9] { -35, -5, 0, 10, 15, 34, 40, 51, 70 };
            doSomething(vector);
        }
    }
}
