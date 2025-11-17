using System;

namespace L0_S2
{
    delegate void Notify(string msg);

    class Program
    {
        static void Main(string[] args)
        {
            Notify handler = null;

            handler += (m) => Console.WriteLine("A: " + m);
            handler += (m) => Console.WriteLine("B: " + m.ToUpper());

            handler("hello");

            handler -= (m) => Console.WriteLine("A: " + m);

            handler("world");
        }
    }
}
