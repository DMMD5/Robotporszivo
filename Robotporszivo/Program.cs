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
                            terkep[i, j] = 'b';
                        }
                        else
                        {
                            terkep[i, j] = 'k';
                            koszDb++;
                        }
                    }
                }
            }


            int robotSor = 0, robotOszlop = 0;
            bool megtalalt = false;
            while (!megtalalt)
            {
                robotSor = rnd.Next(sorok);
                robotOszlop = rnd.Next(oszlopok);
                if (terkep[robotSor, robotOszlop] == '-')
                {
                    terkep[robotSor, robotOszlop] = 'R';
                    megtalalt = true;
                }
            }


            KiirTerkep(terkep);

            int lepesek = 0;
            int kitakaritott = 0;

            int maradoKosz = SzamolKosz(terkep);


            while (maradoKosz > 0 && VanSzabadSzomszed(terkep, robotSor, robotOszlop))
            {
                int[,] iranyok = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };
                int szabadIranyokDb = 0;
                int[] lepesekIndex = new int[4];

                for (int i = 0; i < 4; i++)
                {
                    int ujSor = robotSor + iranyok[i, 0];
                    int ujOszlop = robotOszlop + iranyok[i, 1];

                    if (ujSor >= 0 && ujSor < sorok && ujOszlop >= 0 && ujOszlop < oszlopok)
                    {
                        if (terkep[ujSor, ujOszlop] != 'b')
                        {
                            lepesekIndex[szabadIranyokDb] = i;
                            szabadIranyokDb++;
                        }
                    }
                }
            }
        }

        static void KiirTerkep(char[,] terkep)
            {
                int sorok = terkep.GetLength(0);
                int oszlopok = terkep.GetLength(1);

                for (int i = 0; i < sorok; i++)
                {
                    for (int j = 0; j < oszlopok; j++)
                    {
                        Console.Write(terkep[i, j] + "   ");
                    }
                }
            }

        static bool VanSzabadSzomszed(char[,] terkep, int sor, int oszlop)
        {
            int sorok = terkep.GetLength(0);
            int oszlopok = terkep.GetLength(1);
            int[,] iranyok = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };

            for (int i = 0; i < 4; i++)
            {
                int ujSor = sor + iranyok[i, 0];
                int ujO = oszlop + iranyok[i, 1];

                if (ujSor >= 0 && ujSor < sorok && ujO >= 0 && ujO < oszlopok)
                {
                    if (terkep[ujSor, ujO] != 'b')
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static int SzamolKosz(char[,] terkep)
            {

            }
        }
    }
}
