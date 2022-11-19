using System;

namespace task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long n = Convert.ToInt64(Console.ReadLine());
            int m = Convert.ToInt32(Console.ReadLine());
            int k = Convert.ToInt32(Console.ReadLine());
            long mask1 = (((1 << 8) - 1) << (8 * (m - 1)));
            long mask2 = (((1 << 8) - 1) << (8 * (k - 1)));
            long m_byte = ((n & mask1) >> (8 * (m - 1)));
            long k_byte = ((n & mask2) >> (8 * (k - 1)));
            n &= (~mask1);
            n &= (~mask2);
            n += (k_byte << (8 * (m - 1))) + (m_byte << (8 * (k - 1)));
            Console.WriteLine(n);
        }
    }
}