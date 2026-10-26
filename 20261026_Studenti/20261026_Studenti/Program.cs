using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20261026_Studenti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //cesta k vstupnimu souboru
            string vstupniSoubor = @"C:\Users\johanovsky\Desktop\studenti.txt";
            //hledana trida
            string hledanaTrida = "IT1B";

            //test existence
            if(File.Exists(vstupniSoubor)) {
                //soubor existuje -> bude se cist
                Console.WriteLine("Vstupni soubor nalezen");
                //otevreme cteci proud

                //jmeno nejlepsiho
                string nejlepsiJmeno = "";
                //prumer nejlepsiho
                float nejlepsiPrumer = 5.0f;

                using (StreamReader sr = File.OpenText(vstupniSoubor))
                {
                    //pomocny string pro jeden radek
                    string radek;
                    //cteme po radcich az do konce souboru
                    while((radek = sr.ReadLine()) != null)
                    {
                        //vypisujeme nacteny radek
                        Console.WriteLine(radek);
                        //Budeme cist nacteny radek do prvniho ; protoze tam je prijmeni
                        //Var a. cteme a slepujeme po znaku - cesta bolesti
                        /*
                        string prijmeni = "";
                        int i = 0;
                        //cteme radek po znacich az do stredniku
                        while (radek[i] != ';')
                        {
                            //pismenka prilepujeme do prijmeni
                            prijmeni += radek[i];
                            //posunu se na dalsi
                            i++;
                        }
                        Console.WriteLine("Vytazene prijmeni: " + prijmeni);
                        */
                        //Var b. pomoci Split
                        string[] sloupce = radek.Split(';');
                        Console.WriteLine("Vytazene prijmeni: " + sloupce[0]);
                        Console.WriteLine("Vytazene trida: " + sloupce[1]);
                        Console.WriteLine("Vytazene prumer: " + sloupce[2]);

                        //hledame je lidi ze zadane tridy
                        if (sloupce[1] == hledanaTrida)
                        {
                            //ze strigoveho prumeru udelam float
                            float prumer = float.Parse(sloupce[2]);
                            //porovnam float s nejlepsim
                            if(prumer < nejlepsiPrumer)
                            {
                                //nasel jsem zaka s nejlepsim prumerem
                                nejlepsiPrumer = prumer;
                                nejlepsiJmeno = sloupce[0];
                            }
                        }
                    }
                    //uzavreme cteci proud
                    sr.Close();
                }
                //Vypiseme nejlepsiho
                Console.WriteLine("Nejlepsi prumer ze tridy: " + hledanaTrida + " ma: " + nejlepsiJmeno);
            } else
            {
                //soubor neexistuje -> konec
                Console.WriteLine("Vstupni soubor nenalezen");
            }

        }
    }
}
