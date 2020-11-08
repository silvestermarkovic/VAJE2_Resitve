using System;
using System.Collections.Generic;
using System.Text;

namespace Naloga3
{
    enum vrstaZivaliSeznam
    {
        Domacazival,
        Divjazival,
        Zver
    }

    interface IZival
    {
        //!!!!! interface cannot contain insatce fields
        //!!!!! public string vrednost = "";


        // Property declaration:
        public string VrstaZivali { get; }
        public int SteviloNog { get; set; }
        string NazivZivali
        {
            get;
            set;
        }

        public string Oglasanje();

       
    }

    public abstract class DomacaZival : IZival
    {

        private int _stevilonog = 0;
        private string _nazivZivali;

        public int SteviloNog
        {
            get
            {
                return _stevilonog;
            }
            set
            {
                _stevilonog = value;
            }
        }

        public string NazivZivali  // read-write instance property
        {
            get => _nazivZivali;
            set => _nazivZivali = value;
        }

        public abstract string VrstaZivali { get; }

        public abstract string Oglasanje();

        public abstract string Gibanje();
    }

    public class Petelin : DomacaZival
    {

        private int _vrstaZivali = (int)vrstaZivaliSeznam.Zver;

        public Petelin(string pNaziv, int pSteviloNog)
        {
            base.SteviloNog = pSteviloNog;
            base.NazivZivali = pNaziv;
        }

        public override string VrstaZivali
        {
            get
            {
                return Enum.GetName(typeof(vrstaZivaliSeznam), _vrstaZivali);
            }
        }

        public override string Oglasanje()
        {
            return "Kikiriki";
        }
        public override string Gibanje()
        {
            return "Leti";
        }
    }
}
 
