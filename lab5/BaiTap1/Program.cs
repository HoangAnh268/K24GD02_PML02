using System.Text;

namespace BaiTap1
{
    internal class Program
    {
        delegate double PhepTinh(double x, double y);
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            PhepTinh Tong = TinhTong;
            Console.WriteLine("Tổng của x và y: " + Tong(10, 5));
            PhepTinh Hieu = TinhHieu;
            Console.WriteLine("Hiệu của x và y: " + Hieu(50, 15));
            PhepTinh Tich = TinhTich;
            Console.WriteLine("Tích của x và y: " + Tich(30, 2));
            PhepTinh Thuong = TinhThuong;
            Console.WriteLine("Thương của x và y: " + Thuong(50, 10));
            Console.ReadLine();
        }
        public static double TinhTong(double x, double y)
        {
            return x + y;
        }
        public static double TinhHieu(double x, double y)
        {
            return x - y;
        }
        public static double TinhTich(double x, double y)
        {
            return x * y;
        }
        public static double TinhThuong(double x, double y)
        {
            return x / y;
        }
        
    }
}
