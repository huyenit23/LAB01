using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB06
{
   
        public class SanPham
        {
            // 1. Khai bao thuoc tinh
            public string MaSP { get; set; }
            public string TenSP { get; set; }
            public double DonGia { get; set; }
            public int SoLuong { get; set; }

            // 2. Ham khoi tao
            public SanPham(string maSP, string tenSP, double donGia, int soLuong)
            {
                MaSP = maSP;
                TenSP = tenSP;
                DonGia = donGia;
                SoLuong = soLuong;
            }

            // 3. Tinh thanh tien
            public double ThanhTien()
            {
                return DonGia * SoLuong;
            }

            // 4. Kiem tra du lieu
            public bool KiemTraDuLieu()
            {
                return !string.IsNullOrWhiteSpace(MaSP)
                    && !string.IsNullOrWhiteSpace(TenSP)
                    && DonGia > 0
                    && SoLuong > 0;
            }

            // 5. Hien thi thong tin
            public void HienThi()
            {
                Console.WriteLine("Ma san pham: " + MaSP);
                Console.WriteLine("Ten san pham: " + TenSP);
                Console.WriteLine("Don gia: " + DonGia);
                Console.WriteLine("So luong: " + SoLuong);
                Console.WriteLine("Thanh tien: " + ThanhTien());
            }
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                SanPham sp = new SanPham("SP01", "But chi", 5000, 10);

                if (sp.KiemTraDuLieu())
                {
                    Console.WriteLine("Du lieu hop le!");
                    sp.HienThi();
                }
                else
                {
                    Console.WriteLine("Du lieu khong hop le!");
                }

                Console.ReadKey();
            }
        }
    }


