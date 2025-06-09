using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitap3
{
    class Program
    {
        // 1. Khai báo delegate Operation nhận 2 số nguyên, trả int
        delegate int Operation(int a, int b);

        static void Main(string[] args)
        {
            // 2. Gán anonymous method vào delegate tính tổng 2 số
            Operation op = delegate (int x, int y)
            {
                return x + y;
            };

            // 3. Gọi delegate với 5 và 7, in kết quả
            int result = op(5, 7);
            Console.WriteLine($"Tổng của 5 và 7 là: {result}");
        }
    }
}
