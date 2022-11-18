using System;

namespace task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long a = Convert.ToInt64(Console.ReadLine());
            long b = Convert.ToInt64(Console.ReadLine());
            long c = Convert.ToInt64(Console.ReadLine());
            long d = Convert.ToInt64(Console.ReadLine());
            long res = 0;
            res = (d << 48) + (c << 32) + (b << 16) + a;
            Console.WriteLine(res);
        }
    }
}