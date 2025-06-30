using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo1
{
    internal class Program
    {
        static  async Task Main(string[] args)
        {
            int hp;
            Console.OutputEncoding = Encoding.UTF8;
            Task task1 = new Task(Demo);// lấy dữ liệu hp nhân vật.
            task1.Start();
            Console.WriteLine("Chương trình chạy xong");
            if(hp <= 0)
            {
                Die();
            }
        }

        void DemoCoroutine()
        {
            //nhiệm vụ 1
            yield return new Frame;
            //nhiệm vụ 2
            yield return new Frame;
            // nhiệm vụ 3
        }
    }

}
