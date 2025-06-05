using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text; 
using System.Threading.Tasks;

namespace BaiTap3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Queue<string> khachhang = new Queue<string>();
            khachhang.Enqueue("Hoàng Anh");
            khachhang.Enqueue("Đăng Khoa");
            khachhang.Enqueue("Thanh Thảo");
            khachhang.Enqueue("Tấn Dũng");
            khachhang.Enqueue("Hồng Phúc");

            
            Console.WriteLine("Hàng đợi kết thúc: " + khachhang.Dequeue());
            Console.WriteLine("Hàng đợi kết thúc: " + khachhang.Dequeue());

            Console.WriteLine("Khách hàng còn lại:");
            foreach (var ten in khachhang) 
                Console.WriteLine(ten);
            Console.ReadLine();
        }
    }
}
