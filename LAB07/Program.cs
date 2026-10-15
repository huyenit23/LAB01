using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB07
{
        public class TaiKhoanNganHang
        {
            // 1. Khai bao thuoc tinh
            public string SoTaiKhoan { get; set; }
            public string TenChuTaiKhoan { get; set; }
            public double SoDu { get; private set; }

            // 2. Ham khoi tao
            public TaiKhoanNganHang(string soTK, string tenChuTK, double soDuBanDau)
            {
                SoTaiKhoan = soTK;
                TenChuTaiKhoan = tenChuTK;

                if (soDuBanDau >= 0)
                    SoDu = soDuBanDau;
                else
                    SoDu = 0;
            }

            // 3. Nap tien
            public bool NapTien(double soTien)
            {
                if (soTien <= 0)
                {
                    Console.WriteLine("So tien nap phai lon hon 0!");
                    return false;
                }

                SoDu += soTien;
                Console.WriteLine("Nap tien thanh cong!");
                return true;
            }

            // 4. Rut tien
            public bool RutTien(double soTien)
            {
                if (soTien <= 0)
                {
                    Console.WriteLine("So tien rut phai lon hon 0!");
                    return false;
                }

                if (soTien > SoDu)
                {
                    Console.WriteLine("So du khong du de rut tien!");
                    return false;
                }

                SoDu -= soTien;
                Console.WriteLine("Rut tien thanh cong!");
                return true;
            }

            // 5. Chuyen tien
            public bool ChuyenTien(TaiKhoanNganHang taiKhoanNhan,
                                   double soTien)
            {
                if (taiKhoanNhan == null)
                {
                    Console.WriteLine("Tai khoan nhan khong hop le!");
                    return false;
                }

                if (taiKhoanNhan == this)
                {
                    Console.WriteLine("Khong the chuyen tien cho chinh minh!");
                    return false;
                }

                if (soTien <= 0)
                {
                    Console.WriteLine("So tien chuyen phai lon hon 0!");
                    return false;
                }

                if (soTien > SoDu)
                {
                    Console.WriteLine("So du khong du de chuyen!");
                    return false;
                }

                SoDu -= soTien;
                taiKhoanNhan.SoDu += soTien;

                Console.WriteLine("Chuyen tien thanh cong!");
                return true;
            }

            // 6. Hien thi thong tin tai khoan
            public void HienThi()
            {
                Console.WriteLine("So tai khoan: " + SoTaiKhoan);
                Console.WriteLine("Ten chu tai khoan: " + TenChuTaiKhoan);
                Console.WriteLine("So du: " + SoDu);
            }
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                TaiKhoanNganHang tk1 =
                    new TaiKhoanNganHang("001", "Nguyen Van A", 1000000);

                TaiKhoanNganHang tk2 =
                    new TaiKhoanNganHang("002", "Tran Van B", 500000);

                // Nap tien
                tk1.NapTien(200000);

                // Rut tien
                tk1.RutTien(100000);

                // Chuyen tien tu tk1 sang tk2
                tk1.ChuyenTien(tk2, 300000);

                // Thu rut tien vuot qua so du
                tk1.RutTien(2000000);

                // Hien thi ket qua
                Console.WriteLine("\n--- TAI KHOAN 1 ---");
                tk1.HienThi();

                Console.WriteLine("\n--- TAI KHOAN 2 ---");
                tk2.HienThi();

                Console.ReadKey();
            }
        }
    }