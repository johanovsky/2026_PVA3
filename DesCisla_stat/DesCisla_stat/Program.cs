using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesCisla_stat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //cesta k vstupnimu souboru
            string vstupniSoubor = @"C:\Users\johanovsky\Desktop\desCisla.txt";

            //kontrola existence
            if (File.Exists(vstupniSoubor))
            {
                //soubor nalezen

                //pom. promenne
                float max = float.MinValue;
                float min = float.MaxValue;

                int pocet = 0;
                float soucet = 0;

                //otevreme cteci proud
                using (StreamReader sr = File.OpenText(vstupniSoubor))
                {
                    //nacteme cely radek
                    string radek;
                    while ((radek = sr.ReadLine()) != null)
                    {
                        //nacetli jsme radek -> vyrobime z nej float
                        float cislo = float.Parse(radek);
                        //Console.WriteLine(cislo);

                        //pricteme ho do souctu
                        soucet += cislo;
                        //zvysime pocet
                        pocet++;

                        //hledame maximum
                        if (cislo > max)
                        {
                            //mam nove maximum
                            max = cislo;
                        }

                        //hledame minimum
                        if (cislo < min)
                        {
                            //mam nove minimum
                            min = cislo;
                        }
                    }
                    //uzavreme proud
                    sr.Close();
                }

                //Zapis do vystupu

                //cesta k vystupnimu souboru
                string vystupniSoubor = @"C:\Users\johanovsky\Desktop\statistika.txt";

                //otevreme zapisovaci proud
                using (StreamWriter sw = File.CreateText(vystupniSoubor))
                {
                    sw.WriteLine("Minimum: " + min);
                    sw.WriteLine("Maximum: " + max);
                    sw.WriteLine("Prumer z max a min: " + ((min + max) / 2));
                    sw.WriteLine("Aritmeticky prumer ze vsech: " + (soucet / pocet));
                    sw.Close();
                    Console.WriteLine("Hotovo");
                }
            }
            else
            {
                //soubor nenalezen
                Console.WriteLine("vstupni soubor nenalezen");
            }
        }
    }
}
