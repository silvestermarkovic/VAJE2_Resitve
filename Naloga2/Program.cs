using System;
using System.Security.Cryptography.X509Certificates;

namespace Naloga2
{
    class Program
    {
        static void Main(string[] args)
        {
            

            //TODO: ustvarimo tocS tipa TockaS
            TockaS tocS = new TockaS();

            //TODO: izpišemo trenutno vrednost tocS
            Console.WriteLine($"Premaknjena tocka X={tocS.X}, Y={tocS.Y}");
            //TODO: kličemo premikS
            premakniS(tocS, 2, 2);
            //TODO: izpišemo trenutno vrednost tocS
            Console.WriteLine($"Premaknjena tocka X={tocS.X}, Y={tocS.Y}");


            //TODO: ustvarimo tocC tipa TockaS
            TockaC tocC = new TockaC();
            //TODO: izpišemo trenutno vrednost tocC
            Console.WriteLine($"Premaknjena tocka X={tocC.X}, Y={tocC.Y}");
            //TODO: kličemo premikC
            premakniC(tocC, 2, 2);
            //TODO: izpišemo trenutno vrednost tocC
            Console.WriteLine($"Premaknjena tocka X={tocC.X}, Y={tocC.Y}");

        }



        //TODO ustvarite TockaS tipa struct, v njem določite public spremenljivki tipa int X in Y
        public struct TockaS
        {
            public int X;  //def value
            public int Y;
        }


        //TODO ustvarite razred TockaC, v njem določite public spremenljivki tipa int X in Y
        public class TockaC
        {
            public int X;
            public int Y;
        }


        //TODO ustvarite statično metodo, ki ne vrača ničesar premakniS
        //TODO kot vhodni parameter dobi: TockaS tocka, int premikX, int premikY
        //TODO vhodnemu parametru tocka.X pristeje premikX (analogono za Y)
        //TODO izpište vrednost tocka.X in tocka.Y
        static public void premakniS(TockaS tocka, int premikX, int premikY)
        {
            tocka.X += premikX;
            tocka.Y += premikY;
            Console.WriteLine($"Premaknjena tocka X={tocka.X}, Y={tocka.Y}");
        }

        //kot za metodo premakniS naredimo metodo premakniC, le da je vhodni parameter tocka tipa TockaC
        static public void premakniC(TockaC tocka, int premikX, int premikY)
        {
            tocka.X += premikX;
            tocka.Y += premikY;
            Console.WriteLine($"Premaknjena tocka X={tocka.X}, Y={tocka.Y}");
        }

    }

}
