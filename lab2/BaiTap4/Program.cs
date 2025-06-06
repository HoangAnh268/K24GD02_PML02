using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text; 
using System.Threading.Tasks;

namespace BaiTap4
{
    internal class Program
    {
        static bool IsPalindrome(string str)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in str)
            {
                stack.Push(c);
            }
            foreach (char c in str)
            {
                if(c !=stack.Pop())
                    return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Nhập chuỗi: ");
            string str = Console.ReadLine(); 

            if (IsPalindrome(str))
                Console.WriteLine("Chuỗi là palindrome (đối xứng).");
            else
                Console.WriteLine("Chuỗi không là palindrome.");
        }
    }
}
