using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB08
{
        public class NhanVien
        {
            // 1. Khai bao thuoc tinh
            public string MaNV { get; set; }
            public string HoTen { get; set; }
            public double LuongCoBan { get; set; }
            public double HeSoLuong { get; set; }
            public double PhuCap { get; set; }

            // 2. Ham khoi tao
            public NhanVien(string maNV, string hoTen,
                            double luongCoBan, double heSoLuong,
                            double phuCap)
            {
                MaNV = maNV;
                HoTen = hoTen;
                LuongCoBan = luongCoBan;
                HeSoLuong = heSoLuong;
                PhuCap = phuCap;
            }

            // 3. Tinh luong
            public double TinhLuong()
            {
                return LuongCoBan * HeSoLuong + PhuCap;
            }

            // 4. Kiem tra du lieu
            public bool KiemTraDuLieu()
            {
                return !string.IsNullOrWhiteSpace(MaNV)
                    && !string.IsNullOrWhiteSpace(HoTen)
                    && LuongCoBan > 0
                    && HeSoLuong > 0
                    && PhuCap >= 0;
            }

            // 5. In thong tin nhan vien
            public void HienThi()
            {
                Console.WriteLine(
                    "{0,-10}{1,-20}{2,15:N0}{3,10:N2}{4,15:N0}{5,18:N0}",
                    MaNV, HoTen, LuongCoBan, HeSoLuong,
                    PhuCap, TinhLuong());
            }
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                // Tao danh sach nhan vien
                NhanVien[] ds = new NhanVien[]
                {
                new NhanVien("NV01", "Nguyen Van A", 5000000, 2.0, 500000),
                new NhanVien("NV02", "Tran Thi B", 6000000, 1.8, 700000),
                new NhanVien("NV03", "Le Van C", 4500000, 1.5, 300000)
                };

                // In bang luong
                Console.WriteLine("BANG LUONG NHAN VIEN");
                Console.WriteLine(new string('-', 90));

                Console.WriteLine(
                    "{0,-10}{1,-20}{2,15}{3,10}{4,15}{5,18}",
                    "Ma NV", "Ho ten", "Luong co ban",
                    "He so", "Phu cap", "Tong luong");

                Console.WriteLine(new string('-', 90));

                double tongLuong = 0;

                foreach (NhanVien nv in ds)
                {
                    if (nv.KiemTraDuLieu())
                    {
                        nv.HienThi();
                        tongLuong += nv.TinhLuong();
                    }
                    else
                    {
                        Console.WriteLine("Du lieu nhan vien khong hop le!");
                    }
                }

                Console.WriteLine(new string('-', 90));
                Console.WriteLine("Tong luong phai tra: {0:N0} dong", tongLuong);

                Console.ReadKey();
            }
        }
    }


