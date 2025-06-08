using System.Collections;
using System.Text;

namespace BaiTap2lab2
{
    struct MatHang
    {
        public int MaMH;
        public string TenMH;
        public int SoLuong;
        public float DonGia;
        public MatHang(int MaMH, string TenMH, int SoLuong, float DonGia)
        {
            this.MaMH = MaMH;
            this.TenMH = TenMH;
            this.SoLuong = SoLuong;
            this.DonGia = DonGia;
        }
        public float ThanhTien()
        {
            return SoLuong * DonGia;
        }
        public override string ToString()
        {
            return $"Mã MH: {MaMH}, Tên MH: {TenMH}, Số Lượng: {SoLuong}, Đơn Giá: {DonGia}, Thành Tiền: {ThanhTien()}";
        }
    }
    internal class Program
    {
       
        static void ThemMatHang(Hashtable danhsach, MatHang m)
        {
            danhsach.Add(m.MaMH, m);
        }

        static bool TimMatHang(Hashtable danhsach, int MaMH)
        {
            return danhsach.ContainsKey(MaMH);
        }

        static void XoaMatHang(Hashtable danhsach, int MaMH)
        {
            if (TimMatHang(danhsach, MaMH))
                danhsach.Remove(MaMH);
        }

        static void XuatDanhSach(Hashtable danhsach)
        {
            foreach (DictionaryEntry item in danhsach)
            {
                MatHang m = (MatHang)item.Value;
                Console.WriteLine(m.ToString());
            }
        }
        static MatHang NhapMatHang()
        {
            Console.Write("Nhập mã mặt hàng: ");
            int ma = int.Parse(Console.ReadLine());
            Console.Write("Nhập tên mặt hàng: ");
            string ten = Console.ReadLine();
            Console.Write("Nhập số lượng: ");
            int soluong = int.Parse(Console.ReadLine());
            Console.Write("Nhập đơn giá: ");
            float dongia = float.Parse(Console.ReadLine());
            return new MatHang(ma, ten, soluong, dongia);
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Hashtable hashtable = new Hashtable();

            while (true)
            {
                Console.WriteLine("\n========= MENU =========");
                Console.WriteLine("1. Nhập danh sách mặt hàng");
                Console.WriteLine("2. Xuất danh sách mặt hàng");
                Console.WriteLine("3. Tìm theo mã mặt hàng và xóa nếu có");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn: ");
                string chon = Console.ReadLine();

                switch (chon)
                {
                    case "1":
                    {
                        while (true)
                        {
                            MatHang m = NhapMatHang();
                            ThemMatHang(hashtable, m);
                            Console.Write("Tiêp tục nhập? (Y/N):");
                            string tiep = Console.ReadLine().ToLower();
                            if (tiep != "Y") break;
                        }
                        break;
                    }
                    case "2":
                    {
                        Console.WriteLine("--- Danh Sách Mặt Hàng ---");
                        XuatDanhSach(hashtable);
                        break;
                    }                    
                    case "3":
                    {
                        Console.Write("Nhập mã mặt hàng cần tìm: ");
                        int maTim = int.Parse(Console.ReadLine());
                        if(TimMatHang(hashtable, maTim))
                        {
                            Console.WriteLine("Đã tìm thấy mặt hàng:");
                            Console.WriteLine(((MatHang)hashtable[maTim]).ToString());
                            XoaMatHang(hashtable, maTim);
                            Console.WriteLine("Mặt hàng đã được xóa.");
                        }
                        else
                        {
                            Console.WriteLine("Không tìm thấy mặt hàng.");
                        }
                        break;
                    }
                    case "0":
                        return;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ");
                        break;                       
                }
            }
        }
    }
}
