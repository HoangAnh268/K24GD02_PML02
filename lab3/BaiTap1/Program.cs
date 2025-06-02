using System;
using System.Collections.Generic;
using System.Linq; // Added for potential future LINQ usage, though not strictly needed for this fix
using System.Text; // Added for potential future StringBuilder usage, though not strictly needed for this fix
using System.Threading.Tasks; // Added for potential future async operations, though not strictly needed for this fix
namespace BaiTap1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== List<int>  các số từ 1 - 10===");
            List<int> numbers = new List<int>();
            for (int i = 1; i <= 10; i++) 
            {
                numbers.Add(i);
            }
            numbers.RemoveAll(n => n%2 == 0);

           
            Console.WriteLine("Các số chẵn sau khi bị xóa");
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();
        }
    }
}
