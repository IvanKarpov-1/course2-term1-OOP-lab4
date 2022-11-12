using System;
using System.Text;

namespace Lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Default;
            Console.InputEncoding = Encoding.Default;

            var menu = new ConsoleMenu();
            menu.Start();
        }
    }
}
