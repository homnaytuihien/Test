using System;
using System.Collections.Generic;
using System.Text;

struct MatHang
{
    public int MaMH;
    public string TenMH;
    public int SoLuong;
    public double DonGia;

    // Constructor
    public MatHang(int ma, string ten, int sl, double gia)
    {
        this.MaMH = ma;
        this.TenMH = ten;
        this.SoLuong = sl;
        this.DonGia = gia;
    }

    // Hàm tính thành tiền
    public double ThanhTien()
    {
        return SoLuong * DonGia;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;
        List<MatHang> danhSach = new List<MatHang>();
        string tiepTuc;

        // 1. Nhập danh sách mặt hàng
        do
        {
            Console.Write("Nhập mã mặt hàng: ");
            int ma = int.Parse(Console.ReadLine());

            Console.Write("Nhập tên mặt hàng: ");
            string ten = Console.ReadLine();

            Console.Write("Nhập số lượng mặt hàng: ");
            int sl = int.Parse(Console.ReadLine());

            Console.Write("Nhập đơn giá: ");
            double gia = double.Parse(Console.ReadLine());

            MatHang mh = new MatHang(ma, ten, sl, gia);
            danhSach.Add(mh);

            Console.Write("Tiếp tục nhập? (y/n): ");
            tiepTuc = Console.ReadLine().ToLower();
        } while (tiepTuc == "y");

        // 2. Xuất danh sách
        Console.WriteLine("\nDanh sách mặt hàng:");
        XuatDanhSach(danhSach);

        // 3. Tìm và xóa mặt hàng
        Console.Write("\nNhập mã mặt hàng và xóa: ");
        int maCanTim = int.Parse(Console.ReadLine());

        int index = danhSach.FindIndex(mh => mh.MaMH == maCanTim);
        if (index != -1)
        {
            danhSach.RemoveAt(index);
            Console.WriteLine($"Đã xóa mặt hàng có mã = {maCanTim}");
        }
        else
        {
            Console.WriteLine($"Không tìm thấy mặt hàng có mã = {maCanTim}");
        }

        // In lại danh sách sau khi xóa
        Console.WriteLine("\nDanh sách sau khi xóa:");
        XuatDanhSach(danhSach);
    }

    static void XuatDanhSach(List<MatHang> ds)
    {
        Console.WriteLine("Mã MH\tTên MH\t\tSố Lượng\tĐơn Giá\t\tThành Tiền");
        foreach (var mh in ds)
        {
            Console.WriteLine($"{mh.MaMH}\t{mh.TenMH}\t\t{mh.SoLuong}\t{mh.DonGia:F2}\t\t{mh.ThanhTien():F2}");
        }
    }
}
