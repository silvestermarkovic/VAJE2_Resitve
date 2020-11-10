using System;
using System.Collections.Generic;

namespace Naloga1
{
    class Program
    {
        static void Main(string[] args)
        {

            //TODO ustvaritite indekserji tipa Indexers
            Indexers indekserji = new Indexers();

            //TODO dodajte nekaj >6 oseb, s poljubnimi imeni (vsaj 1 naj se podvoji) in starostjo
            indekserji.dodajOsebo("Martin", 99);
            indekserji.dodajOsebo("Silvester", 39);
            indekserji.dodajOsebo("Marko", 58);
            indekserji.dodajOsebo("Janez", 76);
            indekserji.dodajOsebo("Martin", 29);
            indekserji.dodajOsebo("Jože", 15);
            indekserji.dodajOsebo("Martin", 18);

            //izpisite vrednost steviloDodajanj 
            Console.WriteLine(indekserji.steviloDodajanj);

            //izpisite vrednost, ki jo vrnem metoda vrniPrvoOsebo
            Console.WriteLine(indekserji.vrniPrvoOsebo());

        }
    }
}
