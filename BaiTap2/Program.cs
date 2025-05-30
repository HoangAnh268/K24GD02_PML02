using System.Collections;

namespace BaiTap2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add("Item 01");
            arrayList.Add("Item 02");
            arrayList.Add(1);
            arrayList.Add(2);

            Console.WriteLine(arrayList.Count);
            for (int i = 0; i < arrayList.Count; i++)
            {
                Console.WriteLine(arrayList[i]);
            }
            arrayList.Insert(1, "Item 04");

            ArrayList arrayList2 = new ArrayList();
            arrayList2.Add(5);
            arrayList2.Add("Item 06");
            arrayList.AddRange(arrayList2);

            arrayList.Remove(5);
            arrayList.Remove("Item 06");
            arrayList.Remove("Item 08");

            Hashtable hashtable = new Hashtable();
            hashtable.Add("Key1", "Value1");
            hashtable.Add("Key2", "Value2");
            hashtable.Add("Key3", "Value3");
            hashtable.Add("Key4", 4);
            hashtable.Add(5, "Key5");
            foreach (DictionaryEntry item in hashtable)
            {
                Console.WriteLine("Key: {0} - Value: {1}", item.Key, item.Value);
            }
            foreach (var key in hashtable.Keys)
            {
                Console.WriteLine("Key: {0}", key);
            }
            foreach (var value in hashtable.Values)
            {
                Console.WriteLine("Key: {0}", value);
            }
            hashtable.Remove("Key3");
            Hashtable hashtable2 = (Hashtable)hashtable.Clone();
            hashtable2.Clear();

            SortedList sortedList = new SortedList();
            sortedList.Add("First", 1);
            sortedList.Add("key 2", 2);
            sortedList.Add("Third", "Value 3");
            sortedList.Add("third", "Value 3");
            bool hashKey = sortedList.ContainsKey("T");
            bool hashValue = sortedList.ContainsValue("Value 3");
            SortedList sortedList2 = (SortedList)sortedList.Clone();
            sortedList2.Clear();

            Stack stack = new Stack();
            stack.Push("Item01");
            stack.Push("Item02");
            stack.Push("Item03");
            stack.Push("Item04");
            stack.Push("Item05");
            stack.Pop();
            Console.ReadLine();
        }
    }
}
