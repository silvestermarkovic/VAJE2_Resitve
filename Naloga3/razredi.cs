using System;
using System.Collections.Generic;
using System.Text;

namespace Naloga3
{
    //TODO: ustvarite vrstaZivaliSeznam tipa enum
    //TODO: dodajte zapise Domacazival, Divjazival, Zver
    enum vrstaZivaliSeznam
    {
        Domacazival,
        Divjazival,
        Zver
    }

    //TODO ustvarite interface Izival
    interface IZival
    {
        //!!!!! interface cannot contain instance fields
        //!!!!! public string vrednost = "";

        // Property declaration:
        //TODO ustvarite lastnosti string VrstaZivali (get), int SteviloNog (get,set), string NazivZivali(get,set)
        public string VrstaZivali { get; }
        public int SteviloNog { get; set; }
        string NazivZivali
        {
            get;
            set;
        }


        //TODO ustvarite metode Oglasanje (vrne string), brez vhodnih parametrov
        public string Oglasanje();

        //TODO ustvarite metodo HitrostGibanja (vrne int), brez vhodnih parametrov
        public int HitrostGibanja();

       
    }
    //TODO ustvarite abstraktni razred Zival, ki implementira interface IZival
    public abstract class Zival : IZival
    {
        //TODO: ustvarite field _stevilonog tipa int s privzetno vrednostjo 0. ki bo dosegljiv le v tem razredu
        private int _stevilonog = 0;

        //TODO: ustvarite field _nazivZivali tipa string, ki bo dosegljiv tudi v dedovanih razredih
        protected string _nazivZivali;


        //TODO implementirajte property SteviloNog (vrne in določi field _stevilonog tipa int)
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


        //TODO implementirajte property NazivZivali (vrne in določi field _nazivZivali tipa int)
        public string NazivZivali  // read-write instance property
        {
            get => _nazivZivali;
            set => _nazivZivali = value;
        }


        //TODO dodajte abstraktni property VrstaZivali tipa string (samo get)
        public abstract string VrstaZivali { get; }


        //TODO dodajte abstraktno metodo Oglasanje tipa string, brez vhodnih parametrov 
        public abstract string Oglasanje();


        //TODO dodajte abstraktno metodo Gibanje tipa string, brez vhodnih parametrov
        public abstract string Gibanje();



        //TODO dodajte virtualno metodo HitrostGibanja tipa int, brez vhodnih parametrov, ki vrne vrednost 0
        public virtual int HitrostGibanja()
        {
            return 0;
        }

    }


    //TODO ustvarite razred Petelin, ki je dedovana iz razreda Zival
    public class Petelin : Zival
    {
        //TODO ustvarite field _vrstaZivali tipa int in mu dodelite vrednost (int)vrstaZivaliSeznam.Domacazival
        private int _vrstaZivali = (int)vrstaZivaliSeznam.Domacazival;


        //TODO ustvarite konstruktor Petelin(string pNaziv, int pSteviloNog), vrednosti zapišite v ustrezne Propery
        public Petelin(string pNaziv, int pSteviloNog)
        {
            base.SteviloNog = pSteviloNog;
            base.NazivZivali = pNaziv;
            
            
        }

        //TODO ustvarite VrstaZivali, ki vrne (get) _vrstaZivali vrne string (primer: Divjazival)
        public override string VrstaZivali
        {
            get
            {
                return Enum.GetName(typeof(vrstaZivaliSeznam), _vrstaZivali);
            }
        }

        //TODO ustvarite metodo Oglasanje, ki vrne string "Kikiriki"
        public override string Oglasanje()
        {
            return "Kikiriki";
        }

        //TODO ustvarite metodo Oglasanje, ki vrne string "Leti"
        public override string Gibanje()
        {
            return "Leti";
        }
    }


    //TODO ustvarite razred Tiger, ki je dedovana iz razreda Zival
    public class Tiger : Zival
    {
        //TODO ustvarite field _vrstaZivali tipa int in mu dodelite vrednost (int)vrstaZivaliSeznam.Zver
        private int _vrstaZivali = (int)vrstaZivaliSeznam.Zver;

        //TODO utvarite field _steviloZob tipa int in mu dodelite vrednost 0
        private int _steviloZob = 0;

        //TODO ustvarite konstruktor Tiger(string pNaziv, int pSteviloNog, nt pSteviloZob), vrednosti zapišite v ustrezne Propery
        public Tiger(string pNaziv, int pSteviloNog, int pSteviloZob)
        {
            base.SteviloNog = pSteviloNog;
            base.NazivZivali = pNaziv;
            _steviloZob = pSteviloZob;
        }

        //TODO ustvarite VrstaZivali, ki vrne (get) _vrstaZivali vrne string (primer: Zver)
        public override string VrstaZivali
        {
            get
            {
                return Enum.GetName(typeof(vrstaZivaliSeznam), _vrstaZivali);
            }
        }
        //TODO ustvarite metodo Oglasanje, ki vrne string "KikRjovenjeiriki"
        public override string Oglasanje()
        {
            return "Rjovenje";
        }

        //TODO ustvarite metodo Oglasanje, ki vrne string "Teče"
        public override string Gibanje()
        {
            return "Teče";
        }

        
    }
    //TODO:ustvarite razred Razsiritve
    static class razsitive {
        
        //TODO: ustvarite razsiritev Opis za Tiger
        //TODO: izpiše naj podatke o Tigru stevilonov, gibanje, oglasanje
        public static void Opis(this Tiger pTiger)
        {
            Console.WriteLine("Tiger je lep");
            Console.WriteLine($"Tiger ima {pTiger.SteviloNog} nog.");
            Console.WriteLine($"Gibanje {pTiger.Gibanje()}");
            Console.WriteLine($"Oglasanje {pTiger.Oglasanje()}");
            
        }
    }

   
}
 
