using System;

namespace task
{
    class Programm
    {
        static void Main(string[] args)
        {
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int c = a + b;
            int len = 0;
            while (c != 0)
            {
                len++;
                c /= 2;
            }
            c = a + b;
            for(int i=len-1; i>=0; --i)
            {
                Console.Write((a & (1<<i))>>i);
            }
            Console.Write("\n");
            for (int i = len - 1; i >= 0; --i)
            {
                Console.Write((b & (1 << i))>>i);
            }
            Console.Write("\n"); 
            for (int i = 0; i < len; ++i)
            {
                Console.Write('.');
            }
            Console.Write("\n");
            for (int i = len-1; i >= 0; --i)
            {
                Console.Write((c & (1 << i)) >> i);
            }
            Console.Write("\n");
        }
    }
}