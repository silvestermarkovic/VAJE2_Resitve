using System;
using System.Collections.Generic;

namespace Naloga1
{
    class Program
    {
        static void Main(string[] args)
        {

            Indexers indeksi = new Indexers();
            indeksi.dodajOsebo("Martin", 99);
            indeksi.dodajOsebo("Silvester", 39);
            indeksi.dodajOsebo("Marko", 58);
            indeksi.dodajOsebo("Janez", 76);
            indeksi.dodajOsebo("Martin", 29);
            indeksi.dodajOsebo("Jože", 15);
            indeksi.dodajOsebo("Martin", 18);

            Console.WriteLine(indeksi.steviloDodajanj);

            Console.WriteLine(indeksi.vrniPrvoOsebo());

        }
    }
}
