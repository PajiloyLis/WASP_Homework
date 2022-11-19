using System;

namespace k_th_minimum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[n];
            string[] nums = Console.ReadLine().Split();
            for(int i=0; i<nums.Length; i++)
            {
                array[i] = Convert.ToInt32(nums[i]);
            }
            int k = Convert.ToInt32(Console.ReadLine());
            Array.Sort(array);
            Console.WriteLine(array[k - 1]);
        }
    }
}