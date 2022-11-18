using System;
using System.Runtime.InteropServices;

namespace task
{
    class Programm
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] fact = new int[n];
            for(int i=0; i<n; ++i)
            {
                if (i == 0)
                {
                    fact[i] = 1;
                }
                else
                {
                    fact[i] = fact[i - 1] * (i);
                }
            }
            for(int i = 0; i<n; ++i)
            {
                for(int j=0; j<=i; ++j)
                {
                    Console.Write(fact[i] / (fact[j] * fact[i - j]) + " ");
                }
                Console.Write("\n");
            }
        }
    }
}