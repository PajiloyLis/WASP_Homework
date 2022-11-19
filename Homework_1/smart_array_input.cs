using System;
using System.Diagnostics;

namespace smart_array_input
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] nums = Console.ReadLine().Split();
            int[] array = new int[n];
            for(int i=0; i<n; ++i)
            {
                array[i] = Convert.ToInt32(nums[i]);
            }
            nums = Console.ReadLine().Split(':');
            int step = Convert.ToInt32(nums[2]);
            int start = Convert.ToInt32(nums[0]), end = Convert.ToInt32(nums[1]);
            if (step < 0)
            {
                for(int i=end; i>=start; i += step)
                {
                    Console.Write(array[i] + " ");
                }
            }
            else
            {
                for (int i = start; i <= end; i += step)
                {
                    Console.Write(array[i] + " ");
                }
            }            
        }
    }
}