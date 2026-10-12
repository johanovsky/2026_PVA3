using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Min
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //cesta k vstupnimu souboru
            string vstupniSoubor = @"C:\Users\johanovsky\Desktop\pokus.txt";

            //kontrola existence
            if (File.Exists(vstupniSoubor))
            {
                //soubor nalezen

                //budu hledat 3 min
                int min1 = Int32.MaxValue;
                int min2 = Int32.MaxValue;
                int min3 = Int32.MaxValue;

                //otevreme cteci proud
                using (StreamReader sr = File.OpenText(vstupniSoubor))
                {
                    //nacteme cely radek
                    string radek;
                    while ((radek = sr.ReadLine()) != null)
                    {
                        //nacetli jsme radek -> vyrobime z nej int
                        int cislo = Int32.Parse(radek);
                        //Console.WriteLine(cislo);

                        //hledame minima
                        if (cislo < min1)
                        {
                            //nasel jsem nove min1
                            //posuneme stara minima
                            min3 = min2;
                            min2 = min1;
                            //ulozime min1
                            min1 = cislo;
                        }
                        else if ((cislo > min1) && (cislo < min2))
                        {
                            //nasel jsem nove min2 vetsi jak min1
                            //posuneme stara minima
                            min3 = min2;
                            //ulozime min2
                            min2 = cislo;
                        }
                        else if ((cislo > min2) && (cislo < min3))
                        {
                            //nasel jsem nove min3 vetsi jak min2
                            //ulozim nove min3
                            min3 = cislo;
                        }
                    }
                    //uzavreme proud
                    sr.Close();
                }

                //Vypis
                Console.WriteLine("3 Nejmensi cisla jsou: " + min1 + ", "
                    + min2 + ", " + min3);

            }
            else
            {
                //soubor nenalezen
                Console.WriteLine("vstupni soubor nenalezen");
            }
        }
    }
}
