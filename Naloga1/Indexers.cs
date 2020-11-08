using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Naloga1
{
    class Indexers
    {

        //seznam osebe, ki vsebuje naziv (string) in starost (int)
        Dictionary<string, int> osebe = new Dictionary<string, int>();

        public int steviloDodajanj { get; private set; } = 0;

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
