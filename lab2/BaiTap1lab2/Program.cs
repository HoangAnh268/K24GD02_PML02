using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text; 
using System.Threading.Tasks;
namespace BaiTap1lab2
{
    internal class Program
    {
        public static void RandomNum(int num)
        {
            List<int> numbers = new List<int>();
            Random random = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < num; i++)
            {
                int value = random.Next(100);
                numbers.Add(value);
            }
            Console.WriteLine("\nDãy số ngẫu nhiên lúc đầu:");
            foreach(var n in numbers)
                Console.Write(n + " ");

            numbers.Sort();

            Console.WriteLine("\n\nDãy số sau khi sắp xếp tăng dần:");
            foreach (int n in numbers)
                Console.Write(n + " ");
        }
    
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Nhập số lượng phần từ n > 0: ");
            int n = int.Parse(Console.ReadLine());

            if(n > 0)
            {
                RandomNum(n);
            }    
            else
            {
                Console.WriteLine("Giá trị n không hợp lệ");
            }    
            Console.ReadLine();
        }
    }
}
