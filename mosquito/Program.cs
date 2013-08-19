using System;

namespace Mosquito
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Mosquito.Start();

            Console.ReadKey();

            Mosquito.Stop();
        }
    }
}
