using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _20261005_SouboryKopirovani2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //cesta k vstupnimu souboru
            string vstupniSoubor = @"C:\Users\johanovsky\Desktop\pokus.txt";

            //kontrola existence vstupu
            if (File.Exists(vstupniSoubor))
            {
                //soubor nalezen -> ok
                //cesta k vystupnimu souboru
                string vystupniSoubor = @"C:\Users\johanovsky\Desktop\kopie.txt";
                //promenna na pocitani zkopirovanych radku
                int pocetRadku = 0;

                //otevreme cteci proud
                using (StreamReader sr = File.OpenText(vstupniSoubor))
                {
                    //otevreme zapisovaci proud
                    using (StreamWriter sw = File.CreateText(vystupniSoubor))
                    {
                        //textovy retezec pro nacteni celeho radku
                        string radek;
                        while ((radek = sr.ReadLine()) != null)
                        {
                            //nacteli jsme jeden radek
                            pocetRadku++;
                            //zapiseme radek do vystupu, musime vyresit odradkovani
                            //sw.Write(radek + "\n");
                            //sw.Write(radek + "\r\n");
                            //sw.Write(radek + Environment.NewLine);
                            sw.WriteLine(radek);
                        }
                        //cely vstup je precten
                        //uzavreme vystupni proud
                        sw.Close();
                    }
                    sr.Close();
                }
                //ohlasime pocet zkopirovanych radku
                Console.WriteLine("Bylo zkopirovano: " + pocetRadku + " radku");
            } else
            {
                //soubor nenalezen
                Console.WriteLine("Vstupni soubor nenalezen");
            }
        }
    }
}
