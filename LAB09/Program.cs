using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB09
{

        public class HinhChuNhat
        {
            // 1. Khai bao thuoc tinh
            private double chieuDai;
            private double chieuRong;

            public double ChieuDai
            {
                get { return chieuDai; }
                set
                {
                    if (value > 0)
                        chieuDai = value;
                    else
                        throw new ArgumentException("Chieu dai phai lon hon 0!");
                }
            }

            public double ChieuRong
            {
                get { return chieuRong; }
                set
                {
                    if (value > 0)
                        chieuRong = value;
                    else
                        throw new ArgumentException("Chieu rong phai lon hon 0!");
                }
            }

            // 2. Constructor
            public HinhChuNhat(double dai, double rong)
            {
                ChieuDai = dai;
                ChieuRong = rong;
            }

            // 3. Tinh chu vi
            public double TinhChuVi()
            {
                return (ChieuDai + ChieuRong) * 2;
            }

            // 4. Tinh dien tich
            public double TinhDienTich()
            {
                return ChieuDai * ChieuRong;
            }

            // 5. Hien thi ket qua
            public void HienThi()
            {
                Console.WriteLine("Chieu dai: " + ChieuDai);
                Console.WriteLine("Chieu rong: " + ChieuRong);
                Console.WriteLine("Chu vi: " + TinhChuVi());
                Console.WriteLine("Dien tich: " + TinhDienTich());
            }
        }

        internal class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    HinhChuNhat hcn = new HinhChuNhat(10, 5);

                    hcn.HienThi();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Loi du lieu: " + ex.Message);
                }

                Console.ReadKey();
            }
        }
    }
