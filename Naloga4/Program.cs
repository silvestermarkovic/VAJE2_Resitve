using System;
using System.Collections.Generic;

namespace Naloga4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Naloga1: 
            //sledite navodilom v datoteki player.cs
            //sledite navodilom v datoteki game.cs
            //odstrani dodaj figuro, delajte le s figuro King
            //ustvarite novo igro tipa Game
           
             
            Console.WriteLine("IGRA");
            Game igra = new Game();
            igra.izrisiStanjeIgre();
            //topa premaknemo 
            //igra.igralecPremakne(igra.aktivniIgralec().MojeFigure[0], new ChessBoardField (1,8));
             
            


            for (int i = 0; i<10; i++)
            {
                igra.narediPotezoNakljucno(true);
                igra.izrisiStanjeIgre();
            }
        }


        public static void izrisiFigure(ChessPiece pfigura, Player jaz, Player nasprotnik)
        {
            //metoda izriše Figuro (OznakoFigure) in dovoljene premike (označi z *)
            
            String[,] polja = new string[9, 9 ];
            List<ChessBoardField> seznam = pfigura.dovoljeniPremikiIgra(jaz, nasprotnik);
            
            //narišemo
            polja[pfigura.Position.X, pfigura.Position.Y] = pfigura.OznakaFigure;
            foreach (ChessBoardField elm in seznam)
            {
                polja[elm.X, elm.Y] = "*";
            }

            for (int osy = 8; osy > 0; osy--)
            {
                string vrstica = osy.ToString();
                for (int osx = 1; osx <= 8; osx++)
                {
                    vrstica += (polja[osx, osy] != null) ? polja[osx, osy] : " ";
                }
                Console.WriteLine(vrstica);

            }
            Console.WriteLine(" 12345678");
        }
    }

    static class razsiritve
    {
        public static void IzpisiPozicijo(this ChessPiece figura)
        {
            Console.WriteLine($"X = {figura.Position.X}   Y = {figura.Position.Y}");


        }
         
        
    }

}
