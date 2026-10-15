using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHUONG2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<SinhVien> ds = new List<SinhVien>();
            ds.Add(new SinhVien("SV01", "Nguyễn An", new DateTime(2005, 5, 12), 8.2));
            ds.Add(new SinhVien("SV02", "Trần Bình", new DateTime(2005, 9, 3), 6.8));
            foreach (SinhVien sv in ds) sv.HienThi();
            Console.Write("Mã cần tìm: ");
            string ma = Console.ReadLine();
            SinhVien ketQua = ds.Find(x => x.MaSV.Equals(ma,
            StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(ketQua == null ? "Không tìm thấy" : ketQua.HoTen);
        }
    }
}
