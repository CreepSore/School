using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebung7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> tmpList = new List<int>();
            tmpList.Add(10);
            tmpList.Add(20);
            tmpList.Add(30);

            foreach (int num in tmpList)
            {
                Console.WriteLine("{0} -> {1}", tmpList.IndexOf(num) + 1, num);
            }

            Console.WriteLine();

            for (int i = 0; i < tmpList.Count; i++)
            {
                Console.WriteLine("{0} -> {1}", i + 1, tmpList[i]);
            }

            Console.WriteLine();

            Queue<string> tmpQueue = new Queue<string>();
            tmpQueue.Enqueue("Hallo");
            tmpQueue.Enqueue("Hallo1");
            tmpQueue.Enqueue("Hallo2");

            for (int i = 0; tmpQueue.Count > 0; i++)
            {
                Console.WriteLine("{0} -> {1}", i + 1, tmpQueue.Dequeue());
            }

            Console.WriteLine();

            Stack<float> tmpStack = new Stack<float>();
            tmpStack.Push(3.141f);
            tmpStack.Push(1.112f);
            tmpStack.Push(20.25f);

            for (int i = 0; tmpStack.Count > 0; i++)
            {
                Console.WriteLine("{0} -> {1}", i + 1, tmpStack.Pop());
            }

            Console.WriteLine();


            List<int> tmpList1 = new List<int> { 10, 20, 30 };

            foreach (int num in new List<int>(tmpList1))
            {
                if (num > 10)
                    tmpList1.Remove(num);
            }

            Dictionary<string, int> tmpDict = new Dictionary<string, int>();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int i = 0; i < chars.Length; i++)
            {
                tmpDict.Add(chars[i].ToString(), i + 1);
            }

            Console.WriteLine("J -> {0}", tmpDict["J"]);
            Console.WriteLine();

            foreach (KeyValuePair<string, int> val in tmpDict)
            {
                Console.WriteLine("{0} -> {1}", val.Key, val.Value);
            }

            Console.WriteLine();

            foreach (int val in tmpDict.Values)
            {
                //Console.WriteLine(val);
            }

            foreach (string key in tmpDict.Keys)
            {
                //Console.WriteLine(key);
            }


            tmpDict.Clear();
            string[] tmpInput = { "B", "A", "C" };
            foreach (string val in tmpInput)
            {
                if (tmpDict.ContainsKey(val))
                {
                    tmpDict[val]++;
                }
                else
                {
                    tmpDict.Add(val, 1);
                }
            }

            foreach (var val in tmpDict)
            {
                Console.WriteLine("{0} -> {1}", val.Key, val.Value);
            }
            Console.WriteLine();

            SortedDictionary<string, int> tmpSrtDict = new SortedDictionary<string, int>(tmpDict);
            foreach (var val in tmpSrtDict)
            {
                Console.WriteLine("{0} -> {1}", val.Key, val.Value);
            }
            Console.WriteLine();

            Dictionary<string, List<int>> tmpDicts = new Dictionary<string, List<int>>();

            Tuple<string, DateTime>[] tmpArr = {
                new Tuple<string, DateTime>("a", DateTime.Now),
                new Tuple<string, DateTime>("b", DateTime.Now),
                new Tuple<string, DateTime>("c", DateTime.Now),
                new Tuple<string, DateTime>("a", DateTime.Now)
            };

            Console.ReadKey(true);
        }
    }
}
