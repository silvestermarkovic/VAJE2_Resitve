using System;
using System.Security.Cryptography.X509Certificates;

namespace Naloga2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            TockaS tocS = new TockaS();
            Console.WriteLine($"Premaknjena tocka X={tocS.X}, Y={tocS.Y}");
            premakniS(tocS, 2, 2);
            Console.WriteLine($"Premaknjena tocka X={tocS.X}, Y={tocS.Y}");

            TockaC tocC = new TockaC();
            Console.WriteLine($"Premaknjena tocka X={tocC.X}, Y={tocC.Y}");
            premakniC(tocC, 2, 2);
            Console.WriteLine($"Premaknjena tocka X={tocC.X}, Y={tocC.Y}");

        }


        public struct TockaS
        {
            public int X;  //def value
            public int Y;
        }

        public class TockaC
        {
            public int X;
            public int Y;
        }

        static public void premakniS(TockaS tocka, int premikX, int premikY)
        {
            tocka.X += premikX;
            tocka.Y += premikY;
            Console.WriteLine($"Premaknjena tocka X={tocka.X}, Y={tocka.Y}");
        }
        static public void premakniC(TockaC tocka, int premikX, int premikY)
        {
            tocka.X += premikX;
            tocka.Y += premikY;
            Console.WriteLine($"Premaknjena tocka X={tocka.X}, Y={tocka.Y}");
        }

    }

}
