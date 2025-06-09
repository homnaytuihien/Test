using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitap2
{
    // Khai báo delegate cho event
    public delegate void NumberAddedEventHandler(int number);

    // 1. Tạo class NumberList chứa danh sách số nguyên và event
    public class NumberList
    {
        private List<int> numbers = new List<int>();

        // 2. Event NumberAdded khi thêm số mới
        public event NumberAddedEventHandler NumberAdded;

        public void Add(int number)
        {
            numbers.Add(number);

            // Gọi event nếu có người đăng ký
            NumberAdded?.Invoke(number);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            NumberList list = new NumberList();

            // 3.Định nghĩa v Subscribe event, in ra số vừa thêm
            list.NumberAdded += (int number) => Console.WriteLine($"Đã thêm số: {number}");

            // 4. Thêm vài số và kiểm tra event có gọi đúng
            list.Add(5);
            list.Add(10);
            list.Add(15);
        }
    }
}
