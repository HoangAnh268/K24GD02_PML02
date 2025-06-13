
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
namespace BaiTap2TL
{
    public delegate void NumberAddEventHandler(int Number);
   public class NumberList
    {
        private List<int> numbers = new List<int>();
        public event NumberAddEventHandler NumberAdd;
        public void AddNumber(int number)
        {
            numbers.Add(number);
            NumberAdd?.Invoke(number);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            NumberList list = new NumberList();
            list.NumberAdd += OnNumberAdd;
            list.AddNumber(10);
            list.AddNumber(20);
            list.AddNumber(30);
            list.AddNumber(40);
            list.AddNumber(50);
        }
        public static void OnNumberAdd(int number)
        {
            Console.WriteLine($"Số vừa thêm vào listnumbers: {number}");
        }

    }
}
