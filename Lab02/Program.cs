using System.Collections;
using System.Collections.Generic;
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
            SortedList sortedList = new SortedList();
            sortedList.Add("First", 1);
            sortedList.Add("Key", 1);
            sortedList.Add("Key1", "Value3");
            sortedList.Remove("Key1");
            bool hasKey = sortedList.ContainsKey("T");
            bool hasValue = sortedList.ContainsValue(1);
            SortedList sortedList2 = (SortedList)sortedList.Clone();
            sortedList2.Clear();
            Stack stack = new Stack();
            stack.Push("Item01");
            stack.Push("Item02");
            stack.Push("Item03");
            stack.Push("Item04");
            stack.Pop();
            Queue queue = new Queue();
            queue.Enqueue("Item01");
            queue.Enqueue("Item02");
            queue.Enqueue("Item03");
            queue.Enqueue("Item04");
            var imtemQueue = queue.Dequeue();

            Console.ReadLine();
        }
    }
}
