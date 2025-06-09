using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitap1
{
    internal class Program
    {
        // 1. Định nghĩa delegate nhận một int và trả về int
        delegate int MyDelegate(int x);

        // 2. Viết 2 method: Square và Cube
        static int Square(int x)
        {
            return x * x;
        }

        static int Cube(int x)
        {
            return x * x * x;
        }

        static void Main(string[] args)
        {
            // 3. Tạo delegate trỏ đến một trong 2 method
            MyDelegate del;

            // Gán delegate trỏ đến method Square
            del = Square;
            int result1 = del(3);
            Console.WriteLine($"Square(3) = {result1}");

            // Gán delegate trỏ đến method Cube
            del = Cube;
            int result2 = del(3);
            Console.WriteLine($"Cube(3) = {result2}");
        }
    }
}
