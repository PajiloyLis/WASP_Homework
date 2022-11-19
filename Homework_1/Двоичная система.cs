using System;
using System.Runtime.InteropServices;

namespace task
{
    class Programm
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string ans = "";
            for(int i=0; ;++i)
            {
                if ((1 << i) > n)
                {
                    break;
                }
                else
                {
                    ans = ((n>>i)&1) + ans;
                }
            }
            Console.WriteLine(ans);
        }
    }
}