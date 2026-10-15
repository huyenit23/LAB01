using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB10
{
   public class SinhVien
        {
            public string MaSV { get; set; }
            public string HoTen { get; set; }
            public DateTime NgaySinh { get; set; }
            public double DiemTB { get; set; }

            public SinhVien(string maSV, string hoTen,
                            DateTime ngaySinh, double diemTB)
            {
                MaSV = maSV;
                HoTen = hoTen;
                NgaySinh = ngaySinh;
                DiemTB = diemTB;
            }

            public void HienThi()
            {
                Console.WriteLine("{0,-12}{1,-25}{2,-15}{3,10:F2}",
                    MaSV, HoTen, NgaySinh.ToString("dd/MM/yyyy"), DiemTB);
            }
        }

        internal class Program
        {
            static List<SinhVien> danhSach = new List<SinhVien>();

            static void Main(string[] args)
            {
                int chon;

                do
                {
                    Console.WriteLine("\n===== QUAN LY SINH VIEN =====");
                    Console.WriteLine("1. Them sinh vien");
                    Console.WriteLine("2. Sua sinh vien");
                    Console.WriteLine("3. Xoa sinh vien");
                    Console.WriteLine("4. Tim kiem sinh vien");
                    Console.WriteLine("5. Sap xep theo diem trung binh");
                    Console.WriteLine("6. Thong ke danh sach");
                    Console.WriteLine("7. Hien thi danh sach");
                    Console.WriteLine("0. Thoat");
                    Console.Write("Nhap lua chon: ");

                    if (!int.TryParse(Console.ReadLine(), out chon))
                    {
                        Console.WriteLine("Vui long nhap so!");
                        continue;
                    }

                    switch (chon)
                    {
                        case 1:
                            ThemSinhVien();
                            break;
                        case 2:
                            SuaSinhVien();
                            break;
                        case 3:
                            XoaSinhVien();
                            break;
                        case 4:
                            TimKiemSinhVien();
                            break;
                        case 5:
                            SapXepSinhVien();
                            break;
                        case 6:
                            ThongKe();
                            break;
                        case 7:
                            HienThiDanhSach();
                            break;
                        case 0:
                            Console.WriteLine("Da thoat chuong trinh!");
                            break;
                        default:
                            Console.WriteLine("Lua chon khong hop le!");
                            break;
                    }

                } while (chon != 0);
            }

            // 1. Them sinh vien
            static void ThemSinhVien()
            {
                Console.Write("Nhap ma sinh vien: ");
                string ma = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(ma))
                {
                    Console.WriteLine("Ma sinh vien khong duoc de trong!");
                    return;
                }

                if (danhSach.Any(sv =>
                    sv.MaSV.Equals(ma, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Ma sinh vien da ton tai!");
                    return;
                }

                Console.Write("Nhap ho ten: ");
                string ten = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(ten))
                {
                    Console.WriteLine("Ho ten khong duoc de trong!");
                    return;
                }

                Console.Write("Nhap ngay sinh (dd/MM/yyyy): ");
                DateTime ngaySinh;

                if (!DateTime.TryParseExact(
                    Console.ReadLine(), "dd/MM/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out ngaySinh))
                {
                    Console.WriteLine("Ngay sinh khong hop le!");
                    return;
                }

                Console.Write("Nhap diem trung binh (0-10): ");
                double diem;

                if (!double.TryParse(Console.ReadLine(), out diem)
                    || diem < 0 || diem > 10)
                {
                    Console.WriteLine("Diem phai tu 0 den 10!");
                    return;
                }

                danhSach.Add(new SinhVien(ma, ten, ngaySinh, diem));
                Console.WriteLine("Them sinh vien thanh cong!");
            }

            // 2. Sua sinh vien
            static void SuaSinhVien()
            {
                Console.Write("Nhap ma sinh vien can sua: ");
                string ma = Console.ReadLine().Trim();

                SinhVien sv = danhSach.FirstOrDefault(s =>
                    s.MaSV.Equals(ma, StringComparison.OrdinalIgnoreCase));

                if (sv == null)
                {
                    Console.WriteLine("Khong tim thay sinh vien!");
                    return;
                }

                Console.Write("Nhap ho ten moi: ");
                string ten = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(ten))
                {
                    Console.WriteLine("Ho ten khong duoc de trong!");
                    return;
                }

                Console.Write("Nhap ngay sinh moi (dd/MM/yyyy): ");
                DateTime ngaySinh;

                if (!DateTime.TryParseExact(
                    Console.ReadLine(), "dd/MM/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out ngaySinh))
                {
                    Console.WriteLine("Ngay sinh khong hop le!");
                    return;
                }

                Console.Write("Nhap diem trung binh moi (0-10): ");
                double diem;

                if (!double.TryParse(Console.ReadLine(), out diem)
                    || diem < 0 || diem > 10)
                {
                    Console.WriteLine("Diem phai tu 0 den 10!");
                    return;
                }

                sv.HoTen = ten;
                sv.NgaySinh = ngaySinh;
                sv.DiemTB = diem;

                Console.WriteLine("Cap nhat sinh vien thanh cong!");
            }

            // 3. Xoa sinh vien
            static void XoaSinhVien()
            {
                Console.Write("Nhap ma sinh vien can xoa: ");
                string ma = Console.ReadLine().Trim();

                SinhVien sv = danhSach.FirstOrDefault(s =>
                    s.MaSV.Equals(ma, StringComparison.OrdinalIgnoreCase));

                if (sv == null)
                {
                    Console.WriteLine("Khong tim thay sinh vien!");
                    return;
                }

                danhSach.Remove(sv);
                Console.WriteLine("Xoa sinh vien thanh cong!");
            }

            // 4. Tim kiem sinh vien
            static void TimKiemSinhVien()
            {
                Console.Write("Nhap ma hoac ten sinh vien can tim: ");
                string tuKhoa = Console.ReadLine().Trim();

                var ketQua = danhSach.Where(sv =>
                    sv.MaSV.IndexOf(tuKhoa,
                        StringComparison.OrdinalIgnoreCase) >= 0
                    || sv.HoTen.IndexOf(tuKhoa,
                        StringComparison.OrdinalIgnoreCase) >= 0
                ).ToList();

                if (ketQua.Count == 0)
                {
                    Console.WriteLine("Khong tim thay sinh vien!");
                    return;
                }

                InTieuDe();
                foreach (SinhVien sv in ketQua)
                    sv.HienThi();
            }

            // 5. Sap xep diem giam dan
            static void SapXepSinhVien()
            {
                danhSach = danhSach
                    .OrderByDescending(sv => sv.DiemTB)
                    .ToList();

                Console.WriteLine("Da sap xep theo diem giam dan!");
                HienThiDanhSach();
            }

            // 6. Thong ke
            static void ThongKe()
            {
                if (danhSach.Count == 0)
                {
                    Console.WriteLine("Danh sach sinh vien dang rong!");
                    return;
                }

                double diemTB = danhSach.Average(sv => sv.DiemTB);
                double caoNhat = danhSach.Max(sv => sv.DiemTB);
                double thapNhat = danhSach.Min(sv => sv.DiemTB);

                int gioi = danhSach.Count(sv => sv.DiemTB >= 8);
                int kha = danhSach.Count(sv =>
                    sv.DiemTB >= 6.5 && sv.DiemTB < 8);
                int trungBinh = danhSach.Count(sv =>
                    sv.DiemTB >= 5 && sv.DiemTB < 6.5);
                int yeu = danhSach.Count(sv => sv.DiemTB < 5);

                Console.WriteLine("\n===== THONG KE =====");
                Console.WriteLine("Tong so sinh vien: " + danhSach.Count);
                Console.WriteLine("Diem trung binh chung: " + diemTB.ToString("F2"));
                Console.WriteLine("Diem cao nhat: " + caoNhat);
                Console.WriteLine("Diem thap nhat: " + thapNhat);
                Console.WriteLine("Sinh vien gioi (>= 8): " + gioi);
                Console.WriteLine("Sinh vien kha (6.5 den < 8): " + kha);
                Console.WriteLine("Sinh vien trung binh (5 den < 6.5): " + trungBinh);
                Console.WriteLine("Sinh vien yeu (< 5): " + yeu);
            }

            // 7. Hien thi danh sach
            static void HienThiDanhSach()
            {
                if (danhSach.Count == 0)
                {
                    Console.WriteLine("Danh sach sinh vien dang rong!");
                    return;
                }

                InTieuDe();

                foreach (SinhVien sv in danhSach)
                    sv.HienThi();
            }

            static void InTieuDe()
            {
                Console.WriteLine(
                    "{0,-12}{1,-25}{2,-15}{3,10}",
                    "Ma SV", "Ho ten", "Ngay sinh", "Diem TB");

                Console.WriteLine(new string('-', 62));
            }
        }
    }

