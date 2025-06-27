using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Baitap02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            DongHo dongHo = new DongHo();
            HienThiThoiGian display = new HienThiThoiGian();
            dongHo.MotGiayTroiQua += display.XuLyMoiGiay;
            dongHo.BatDau();
        }

        
    }


    public class DongHo
    {
        public DateTime ThoiGian;
        public event EventHandler MotGiayTroiQua;
        public void BatDau()
        {
            while (true)
            {
                Thread.Sleep(1000);
                MotGiayTroiQua?.Invoke(this, EventArgs.Empty);
            }
        }
    }
    public class HienThiThoiGian
    {
        public void XuLyMoiGiay(object sender, EventArgs e)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Thời gian hiện tại: " + DateTime.Now.ToString("HH:mm:ss"));
        }
    }
}
