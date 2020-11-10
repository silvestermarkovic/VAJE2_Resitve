using System;

namespace Naloga3
{
    class Program
    {
        static void Main(string[] args)
        {

            //TODO: ustvarite objekt tipa Petelin z imenom zivPetelin (z imenom Marjan, število nog 2)
            Petelin zivPetelin = new Petelin("Marjan", 2);

            //TODO: izpišite na zaslon, kar vrne metoda Givanje in VrstaZivali
            Console.WriteLine(zivPetelin.Gibanje());
            Console.WriteLine(zivPetelin.VrstaZivali);


            //TODO: ustvarite objekt tipa Tiger z imenom zivTiger (z imenom Polde, število nog 4, št. zob 46)
            Tiger zivTiger = new Tiger("Polde", 4, 46);

            
            //TODO: ustvarite in kličite razširitev Opis
            zivTiger.Opis();


        }
    }
}
