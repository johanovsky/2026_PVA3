using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20261102_Vyhledavani
{
    internal class Program
    {

        /* naivni vyhledavani - funkce */
        public static bool Naivni(int[] pole, int hledany)
        {
            //predpokladam ze nenajdu
            bool nalezeno = false;
            //projdu CELE pole
            for(int i = 0; i < pole.Length; i++)
            {
                //kazdeho prvku se zeptam jestli se nerovna hledanemu
                if (pole[i] == hledany)
                {
                    //nasel jsem
                    nalezeno = true;
                }
            }
            //koncim a vratim vysledek
            return nalezeno;
        }

        static void Main(string[] args)
        {
            /* zde vytvorime pole */
            int[] pole = new int[10];

            /* nah. generator */
            Random rd = new Random();

            /* projdeme pole, naplnime hodnotama, vypiseme */
            for(int i = 0; i < pole.Length; i++)
            {
                /* nah. hodnota */
                pole[i] = rd.Next(pole.Length);
                /* vypis */
                Console.Write(pole[i] + ", ");
            }
            //odentrujeme vypis
            Console.WriteLine();

            //Testujeme vyhledavani
            int hledany = 5;
            //pouzijeme nasi funkci v podmince
            if(Naivni(pole, hledany) == true)
            {
                Console.WriteLine("Cislo: " + hledany + " NALEZENO");
            } else
            {
                Console.WriteLine("Cislo: " + hledany + " NENALEZENO");
            }
        }
    }
}
