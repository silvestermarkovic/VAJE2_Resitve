using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Naloga1
{

    //TODO ustvarite razred Indexers
    class Indexers
    {


        //TODO dodajte Dictionary osebe, ki vsebuje naziv (string) in starost (int)
        Dictionary<string, int> osebe = new Dictionary<string, int>();

        //TODO ustvarite propery steviloDodajanj (get, private set) s privzetno vrednostjo 0
        public int steviloDodajanj { get; private set; } = 0;



        //TODO ustvarite metodo dodajOsebo (vhodni parameter je naziv (string) in starost (int))
        //TODO poveča števec steviloDodajanj
        //TODO če je starost >= 18 doda osebo vendar preveri, če morda že obstaja
        //TODO v kolikor obstaja, popravi starost osebe
        public void dodajOsebo(string naziv, int starost) 
        {
            
            steviloDodajanj += 1;
            if (starost >= 18)
            {
             if (!osebe.ContainsKey (naziv))  
                {
                    osebe.Add(naziv, starost);
                }
             else
                {
                    osebe[naziv] = starost;
                }
            }
        }


        //TODO ustvarite metodo, ki vrne prvo osebo slovarja in njeno starost v obliki "naziv - starost"
        //TODO v kolikor v slovarju ni zapisov vrnite "" prazen string
        //TODO pomoč: var prvaOseba = osebe.First();
        public string vrniPrvoOsebo()
        {
            if (osebe.Count > 0)
            {
                var prvaOseba = osebe.First();
                return (prvaOseba.Key + " - " + prvaOseba.Value);
            }
            else {
                return "";
            }
             
        }

    }

}
