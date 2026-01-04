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
                Console.Write("N (20-30): ");
                sorok = int.Parse(Console.ReadLine());
                Console.Write("M (20-30): ");
                oszlopok = int.Parse(Console.ReadLine());
            }
            while (!(sorok >= 20 && sorok <= 30 && oszlopok >= 20 && oszlopok <= 30 && sorok != oszlopok));

            char[,] terkep = new char[sorok, oszlopok];

            int szabadDb = 0, koszDb = 0;
            while (szabadDb == 0 || koszDb == 0)
            {
                szabadDb = 0;
                koszDb = 0;

                for (int i = 0; i < sorok; i++)
                {
                    for (int j = 0; j < oszlopok; j++)
                    {
                        int x = rnd.Next(100);
                        if (x < 50)
                        {
                            terkep[i, j] = '-';
                            szabadDb++;
                        }
                        else if (x < 70)
                        {
                            terkep[i, j] = 'B';
                        }
                    }
                }



            }
        }
    }
}
