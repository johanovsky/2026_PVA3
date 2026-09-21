using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _20260921_Soubory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //cesta k vstupnimu souboru
            //@ pred stringem -> C# to bere jak cestu a staci jednoducha \
            string cestaKVstupnimuSouboru = @"C:\Users\johanovsky\Desktop\pokus.txt";

            //test existence vstupniho souboru
            if(File.Exists(cestaKVstupnimuSouboru)) 
            {
                //vstupni soubor existuje
                Console.WriteLine("Vstupni soubor existuje");

                //cesta k vystupnimu souboru
                string cestaKVystupnimuSouboru = @"C:\Users\johanovsky\Desktop\kopie.txt";

                //vytvorime cteci proud ze vstupniho souboru
                using (StreamReader sr = File.OpenText(cestaKVstupnimuSouboru))
                {
                    //potrebuju cislo, kam budu ukladat kody prectenych znaku
                    int cislo;

                    //vytvorime zapisovaci proud do vystupniho souboru
                    //CreateText - vytvori soubor, puvodni prepise
                    //using (StreamWriter sw = File.CreateText(cestaKVystupnimuSouboru))
                    //AppendText - vytvorie soubor, do puvodniho pripise
                    using (StreamWriter sw = File.AppendText(cestaKVystupnimuSouboru))
                    {
                        //cteme az do konce vstupni soubor znak po znaku
                        while((cislo = sr.Read()) != -1)
                        {
                            //z ciselneho kodu vytvorime jednoznakovy string
                            string znak = Char.ConvertFromUtf32(cislo);
                            //tento znak / string zapisu
                            sw.Write(znak);
                            //toto zapisuje UTF kody
                            //sw.Write(cislo);
                            //kontrolni vypis do konzole - nefunguji spec. pismena (arabstina, cinstina, apod...)
                            //Console.Write(znak);
                        }
                        //uzavreme zapisovaci proud
                        sw.Close();
                    }
                    //uzavreme cteci proud
                    sr.Close();
                }
                //Happy end
                Console.WriteLine("Soubor zkopirovan");
            } else
            {
                //vstupni soubor neexistuje
                Console.WriteLine("Vstupni soubor neexistuje");
            }
        }
    }
}
