using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitap01
{
    internal class Program
    {
        public delegate double PhepTinh(double x, double y);
        static void Main(string[] args)
        {
            PhepTinh tinhTong = TinhTong;
            PhepTinh tinhHieu = TinhHieu;
            PhepTinh tinhTich = TinhTich;
            PhepTinh tinhThuong = TinhThuong;
            Console.WriteLine(tinhTong(5, 3));
            Console.WriteLine(tinhHieu(7, 2));
            Console.WriteLine(tinhTich(2, 4));
            Console.WriteLine(tinhThuong(9, 3));
            
        }
        static double TinhTong(double x, double y)
        {
            return x + y;
        }

       
        static double TinhHieu(double x, double y) => x - y;
        static double TinhTich(double x, double y) => x * y;
        static double TinhThuong(double x, double y) => x / y;
        
    }
}
