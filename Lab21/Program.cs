using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab21
{
    class Program
    {
        private static int[,] Garneder;
        private static int TheGardener1;
        private static int TheGardener2;
        static object loker = new object();
        static void Main()
        {
            Console.WriteLine("Введите сторону участка");
            int Side = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Садовники приступили к работе.");
            TheGardener1 = Side;
            TheGardener2 = Side;
            Garneder = new int[Side, Side];
            Thread TheGardenerWork1 = new Thread(Sad1);
            Thread TheGardenerWork2 = new Thread(Sad2);
            TheGardenerWork1.Start();
            TheGardenerWork2.Start();
            Console.ReadKey();
        }
        private static void Sad1()
        {
            lock (loker)
                for (int i = 0; i < TheGardener2; i++)
                {
                    for (int j = 0; j < TheGardener1; j++)
                    {
                        if (Garneder[i, j] == 0)
                            Garneder[i, j] = 1;
                        Console.Write(Garneder[i, j] + " ");
                        Console.WriteLine();
                        Thread.Sleep(100);
                    }
                }
        }
        private static void Sad2()
        {
            for (int i = TheGardener1 - 1; i > 0; i--)
            {
                for (int j = TheGardener2 - 1; j > 0; j--)
                {
                    if (Garneder[j, i] == 0)
                        Garneder[j, i] = 2;
                    Console.Write(Garneder[i, j] + " ");
                    Thread.Sleep(100);
                }
            }
        }
        }
}
