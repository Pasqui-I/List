using System.ComponentModel;
using List.src.LinkedList;
namespace List.src
{
    class Program
    {
        static void Main()
        {
            LinkedList.LinkedList<int> list = new();

            list.Add(10);
            list.Add(20);
            list.Add(30);
            list.Add(40);
            Console.WriteLine(list);
            Console.WriteLine(list.GetAt(list.Length-1));
        }
    }
}