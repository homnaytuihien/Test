using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitap03
{
    internal class Program
    {
        public delegate void LoggerDelegate(string message);
        public delegate int PhepTinh(int n);
        static void Main(string[] args)
        {
            Logger logger = new Logger();
            LoggerDelegate log = logger.LogToConsole;
            log("HelloWorld");
            LoggerDelegate log2 = logger.LogToFile;
            log2("Xin chao VietNam");
            LoggerDelegate multiLogger = logger.LogToConsole;
            multiLogger += logger.LogToFile;
            multiLogger("Multicast delegate xin chao");
            multiLogger -= logger.LogToConsole;
            multiLogger("Da xoa logToConsole");
            Action<int, int> pheptinh = TinhToan;
            pheptinh(5, 3);
            
        }
        static void TinhToan(int x, int y)
        {
            Console.WriteLine(x, y);
        }
    }
    public class Logger
    {
        public void LogToConsole(string message)
        {
            //ghi file
            Console.WriteLine($"[Console]: {message}");
        }
        public void LogToFile(string message)
        {
            Console.WriteLine($"[File]: {message}" );
        }
    }
}
