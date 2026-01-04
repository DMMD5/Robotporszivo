using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robotporszivo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            int sorok, oszlopok;


            do
            {
                Console.Write("N(20-30): ");
                sorok = int.Parse(Console.ReadLine());
                Console.Write("M(20-30): ");
                oszlopok = int.Parse(Console.ReadLine());
            }
            while (!(sorok >= 20 && sorok <= 30 && oszlopok >= 20 && oszlopok <= 30));

            char[,] terkep = new char[sorok, oszlopok];
        }
    }
}
