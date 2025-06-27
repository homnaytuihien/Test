using System;
using System.IO;
using System.Text;

class NotNegativeException : Exception
{
    public NotNegativeException(string message) : base(message) { }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        try
        {
            Console.Write("Nhập x: ");
            int x = int.Parse(Console.ReadLine());

            Console.Write("Nhập y: ");
            int y = int.Parse(Console.ReadLine());

            int tuSo = 3 * x + 2 * y;
            int mauSo = 2 * x - y;

            if (mauSo == 0)
                throw new DivideByZeroException("Mẫu số bằng 0!");

            if (tuSo < 0)
                throw new NotNegativeException("Giá trị trong căn nhỏ hơn 0!");

            double H = Math.Sqrt(tuSo) / mauSo;

            Console.WriteLine($"Giá trị H = {H}");

            File.WriteAllText("input.txt", $"H = {H}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Lỗi: Bạn phải nhập số nguyên.");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Lỗi: " + ex.Message);
        }
        catch (NotNegativeException ex)
        {
            Console.WriteLine("Lỗi: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi không xác định: " + ex.Message);
        }
    }
}