using System;
using System.Text;
namespace BaiTap3TL
{
    internal class Program
    {
        delegate int Operation(int x, int y);
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Operation sum = delegate (int x, int y)
            {
                return x + y;
            };
            int Tong = sum(5, 7);
            Console.WriteLine("Tổng của 5 và 7 là: " + Tong);
        }
        
    }
}
