using SortAlgorithms;
using System;
using System.Text;

namespace SortAlgorithms
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            MenuManager.InputArray();
            MenuManager.SortingMenu();         
        }
    }
}
