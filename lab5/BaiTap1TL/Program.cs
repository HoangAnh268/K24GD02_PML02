using System.Text;

namespace BaiTap1TL
{
    internal class Program
    {
        delegate int SquareCube(int x);
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            SquareCube Sq = HinhVuong;
            Console.WriteLine("Bình phương của 3: " + Sq(3));
            SquareCube Cb = HinhLapPhuong;
            Console.WriteLine("Lập phương của 3: " + Cb(3));
        }
        public static int HinhVuong(int x)
        {
            return x * x;
        }
        public static int HinhLapPhuong(int x) 
        {
            return x * x * x;
        }
    }
}
