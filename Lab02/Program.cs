using System.Collections;
using System.Security.Cryptography;

namespace Lab02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add("Item 1");
            arrayList.Add(2);
            arrayList.Add("Item 2");
            Console.WriteLine(arrayList.Count);
            for (int i = 0; i < arrayList.Count; i++)
            {
                Console.WriteLine(arrayList[i]);
            }
            arrayList.Insert(1, "Item 03");
            ArrayList arrayList2 = new ArrayList();
            arrayList2.Add(5);
            arrayList2.Add("Item6");
            arrayList.AddRange(arrayList2);
            arrayList.Remove(1);

            Hashtable hashtable = new Hashtable();
            hashtable.Add("Key1", "Value1");
            hashtable.Add("Key2", "Value2");
            hashtable.Add("Key3", "Value3");
            //hashtable.Add("Key3", "Value4");
            hashtable.Add(5, 5);
            foreach (DictionaryEntry entry in hashtable)
            {
                Console.WriteLine("Key : {0} - Value :{1}", entry.Key, entry.Value);
            }
            foreach (var key in hashtable.Keys)
            {
                Console.WriteLine("Key : {0} ", key);
            }
            hashtable.Remove("Key3");
            Hashtable hashtable2 = (Hashtable)hashtable.Clone();
            hashtable2.Clear();
            Console.ReadLine();
        }
    }
}
