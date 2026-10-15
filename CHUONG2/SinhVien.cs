
using System;

namespace CHUONG2
{
    public class SinhVien
    {
        // 1. Khai báo thuộc tính và đóng gói dữ liệu
        public string MaSV { get; set; }

        private string _hoTen;
        public string HoTen
        {
            get { return _hoTen; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Họ tên không được rỗng.");

                _hoTen = value.Trim();
            }
        }

        public DateTime NgaySinh { get; set; }

        private double _diemTB;
        public double DiemTB
        {
            get { return _diemTB; }
            set
            {
                if (value < 0 || value > 10)
                    throw new ArgumentOutOfRangeException(
                        nameof(DiemTB), "Điểm phải từ 0 đến 10.");

                _diemTB = value;
            }
        }

        // 2. Constructor mặc định
        public SinhVien()
        {
            MaSV = "Chưa có";
            HoTen = "Chưa có";
            NgaySinh = DateTime.Today;
            DiemTB = 0;
        }

        // 3. Constructor có tham số
        public SinhVien(string maSV, string hoTen,
                        DateTime ngaySinh, double diemTB)
        {
            MaSV = maSV;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            DiemTB = diemTB;
        }

        // 4. Hiển thị thông tin sinh viên
        public void HienThi()
        {
            Console.WriteLine(
                "{0} - {1} - {2:dd/MM/yyyy} - {3:N2}",
                MaSV, HoTen, NgaySinh, DiemTB);
        }

        // 5. Tính tuổi
        public int TinhTuoi()
        {
            int tuoi = DateTime.Today.Year - NgaySinh.Year;

            if (NgaySinh.Date > DateTime.Today.AddYears(-tuoi))
                tuoi--;

            return tuoi;
        }

        // 6. Xếp loại học lực
        public string XepLoai()
        {
            if (DiemTB >= 9) return "Xuất sắc";
            if (DiemTB >= 8) return "Giỏi";
            if (DiemTB >= 6.5) return "Khá";
            if (DiemTB >= 5) return "Trung bình";

            return "Yếu";
        }
    }
}
