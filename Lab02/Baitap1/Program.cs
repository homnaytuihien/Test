using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    public static void RandomNum(int num)
    {
        Console.WriteLine("Số lượng cần sinh: " + num);

        // Tạo danh sách để lưu các số nguyên ngẫu nhiên
        List<int> list = new List<int>();

        // Sinh số ngẫu nhiên
        Random random = new Random((int)DateTime.Now.Ticks);

        Console.WriteLine("Dãy số ngẫu nhiên:");
        for (int i = 0; i < num; i++)
        {
            int value = random.Next(10000); // sinh số từ 0 đến 10000
            list.Add(value);              // lưu vào danh sách
            Console.Write(value + " ");
        }

        // Sắp xếp tăng dần
        list.Sort();

        Console.WriteLine("\nDãy sau khi sắp xếp tăng dần:");
        foreach (int v in list)
        {
            Console.Write(v + " ");
        }
    }

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Write("Nhập số lượng phần tử: ");
        int n = int.Parse(Console.ReadLine());

        if (n > 0)
        {
            RandomNum(n);
        }
        else
        {
            Console.WriteLine("Vui lòng nhập số nguyên dương.");
        }
    }
}
