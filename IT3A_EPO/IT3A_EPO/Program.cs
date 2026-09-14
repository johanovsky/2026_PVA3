using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT3A_EPO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //cesta k souboru
            string cestaKSouboru = "c:\\Users\\johanovsky\\Desktop\\pokus.txt";

            //test existence souboru
            if(File.Exists(cestaKSouboru))
            {
                //soubour existuje
                Console.WriteLine("Soubor nalezen");

                //do souboru pripojime proud (ctecka text. souboru)
                using (StreamReader sr = File.OpenText(cestaKSouboru))
                {
                    //deklaruji si promennou pro jeden znak
                    int cislo;
                    //jdeme cist znaku po znaku
                    while ((cislo = sr.Read()) != -1)
                    {
                        //cislo prevedeme na znak
                        string znak = Char.ConvertFromUtf32(cislo);
                        //vytiskni znak
                        Console.Write(znak);
                    }
                    //uzavreme cteci proud
                    sr.Close();
                }
            } else
            {
                //soubor na zadane ceste neexistuje
                Console.WriteLine("Soubor nenalezen");
            }
        }
    }
}
