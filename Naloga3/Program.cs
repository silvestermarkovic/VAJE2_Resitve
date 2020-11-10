using System;

namespace Naloga3
{
    class Program
    {
        static void Main(string[] args)
        {


            Petelin zivPetelin = new Petelin("Marjan", 2);

            Console.WriteLine(zivPetelin.Gibanje());
            Console.WriteLine(zivPetelin.VrstaZivali);



        }
    }
}
