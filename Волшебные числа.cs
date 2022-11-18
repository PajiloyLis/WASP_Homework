using System;

namespace task
{
    class Programm
    {
        static void Main(string[] args)
        {
            for(int i=9; i>=1; --i)
            {
                for(int j=i-1; j>=0; --j)
                {
                    for(int k=j-1; k>=0; --k)
                    {
                        for(int q=k-1; q>=0; --q)
                        {
                            string ans = $"{i}{j}{k}{q}";
                            Console.WriteLine(ans);
                        }
                    }
                }
            }
        }
    }
}
