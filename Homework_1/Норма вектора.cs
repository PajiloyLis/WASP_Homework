using System;

namespace task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split();
            int n = Convert.ToInt32(nums[0]), p = Convert.ToInt32(nums[1]);
            nums = Console.ReadLine().Split();
            int[] array = new int[nums.Length];
            for(int i=0; i<nums.Length; ++i)
            {
                array[i] = Convert.ToInt32(nums[i]);
            }
            double sum = 0;
            for(int i=0; i<array.Length; ++i)
            {
                sum += Math.Pow(array[i], p);
            }
            sum = Math.Pow(sum, 1.0 / p);
            Console.WriteLine(sum);
        }
    }
}