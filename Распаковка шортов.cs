using System;

namespace task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long number = Convert.ToInt64(Console.ReadLine());
            if (number < 0)
            {
                Console.WriteLine("Incorrect input.");
            }
            else
            {
                long mask = (1 << 16) - 1;
                Console.Write((number & mask) + " ");
                Console.Write(((number & (mask << 16))>>16) + " ");
                Console.Write(((number & (mask << 32))>>32) + " ");
                Console.Write(((number & (mask << 48))>>48) + " ");
            }
        }
    }
}