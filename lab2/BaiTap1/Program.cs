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
            Console.WriteLine("=== List<int> Các chữ số từ 1 - 10 sau khi bị xóa các số chẵn ===");
            List<int> numbers = new List<int>();
            for (int i = 1; i <= 10; i++)
            {
                numbers.Add(i);
            }

            numbers.RemoveAll(numbers => numbers %2 ==0);

            foreach (var number in numbers)
            { 
                Console.WriteLine(number);
            }
            
        }
    }
}
