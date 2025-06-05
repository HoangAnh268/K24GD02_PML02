using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text; 
using System.Threading.Tasks;
namespace BaiTap2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Dictionary<string, double> sanpham = new Dictionary<string, double>();
            sanpham.Add("Cocacola", 13000);
            sanpham.Add("Pepsi", 12000);
            sanpham.Add("Lavi", 8000);
            sanpham.Add("Sting", 11000);
            sanpham.Add("Aquafina", 10000);
            if (sanpham.ContainsKey("Cocacola"))
                sanpham["Cocacola"] = 15000;

            sanpham.Remove("Lavi");

            foreach (var item in sanpham)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
        }
    }
}
