using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _20261005_3Max
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //cesta k vstupnimu souboru
            string vstupniSoubor = @"C:\Users\johanovsky\Desktop\pokus.txt";

            //kontrola existence
            if(File.Exists(vstupniSoubor)){
                //soubor nalezen

                //budu hledat 3 max
                int max1 = 0;
                int max2 = 0;
                int max3 = 0;

                //otevreme cteci proud
                using(StreamReader sr = File.OpenText(vstupniSoubor))
                {
                    //nacteme cely radek
                    string radek;
                    while((radek = sr.ReadLine()) != null)
                    {
                        //nacetli jsme radek -> vyrobime z nej int
                        int cislo = Int32.Parse(radek);
                        //Console.WriteLine(cislo);

                        //hledame maximuma
                        if(cislo > max1)
                        {
                            //nasel jsem nove max1
                            //posuneme stara maxima
                            max3 = max2;
                            max2 = max1;
                            //ulozime max1
                            max1 = cislo;
                        } else if(cislo > max2)
                        {
                            //nasel jsem nove max2
                            //posuneme stara maxima
                            max3 = max2;
                            //ulozime max2
                            max2 = cislo;
                        } else if(cislo > max3)
                        {
                            //nasel jsem nove max3
                            //ulozim nove max3
                            max3 = cislo;
                        }
                    }
                    //uzavreme proud
                    sr.Close();
                }

                //Vypis
                Console.WriteLine("3 Nejvesti cisla jsou: " + max1 + ", "
                    + max2 + ", " + max3);

            } else
            {
                //soubor nenalezen
                Console.WriteLine("vstupni soubor nenalezen");
            }
        }
    }
}
