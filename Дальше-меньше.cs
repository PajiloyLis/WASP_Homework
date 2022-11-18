using System;

namespace task
{
    class Programm
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            for(int i=0; i <n; ++i)
            {
                for(int j=0; j<n; ++j)
                {
                    if (j > i)
                    {
                        Console.Write((n - j + i) + " ");
                    }
                    else
                    {
                        Console.Write((n - i + j) + " ");
                    }
                }
                Console.Write("\n");
            }
        }
    }
}