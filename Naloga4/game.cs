using System;
using System.Collections.Generic;
using System.Text;

namespace Naloga4
{
    public class Game
    {
        //Naloga1
        //ustvarite 2 igralca ime naj bo igralec1 in igralec2, tipa Player (prvi napada Gor, drugi dopl)
        //imeni naj imata P1 in P2
        public Player igralec1 = new Player(smerNapada.Gor, "P1");
        public Player igralec2 = new Player(smerNapada.Dol, "P2");
        
        
        //pove kateri igralec je na potezi
        public int igralecNaPotezi = 1;

        public Game()
        {
            //dodajte začetne figure na šahovnico (8x8) 

            //Naloga1: dodajte samo kralja na pozicijo (5,1) igralcu 1 in pozicijo (5,8)
            
            //Naloga3: dodajte vsakemu igralcu 3 figure (top,tekač in kralj) 
            igralec1.dodajFiguro(new Rook(new ChessBoardField( 1, 1)));
            igralec1.dodajFiguro(new Knight(new ChessBoardField(2, 1)));
            igralec1.dodajFiguro(new Bishop(new ChessBoardField(3, 1)));
            //igralec1.odstraniFiguro(new ChessBoardField(3,1));
            
            
            igralec1.dodajFiguro(new Queen(new ChessBoardField(4, 1)));
            igralec1.dodajFiguro(new King(new ChessBoardField(5, 1)));
            igralec1.dodajFiguro(new Bishop(new ChessBoardField(6, 1)));
            igralec1.dodajFiguro(new Knight(new ChessBoardField(7, 1)));
            igralec1.dodajFiguro(new Rook(new ChessBoardField(8, 1)));

            igralec2.dodajFiguro(new Rook(new ChessBoardField(1, 8)));
            igralec2.dodajFiguro(new Knight(new ChessBoardField(2, 8)));
            igralec2.dodajFiguro(new Bishop(new ChessBoardField(3, 8)));
            igralec2.dodajFiguro(new Queen(new ChessBoardField(4, 8)));
            igralec2.dodajFiguro(new King(new ChessBoardField(5, 8)));
            igralec2.dodajFiguro(new Bishop(new ChessBoardField(6, 8)));
            igralec2.dodajFiguro(new Knight(new ChessBoardField(7, 8)));
            igralec2.dodajFiguro(new Rook(new ChessBoardField(8, 8)));

        }

        //Naloga1
        //ustvarite javno metodo aktivniIgralec(), ki vrača igralca (tip Player), 
        //aktivnega igralca vrača na podlagi sprmenljivke igralecNaPotezi (1 igralec1, 2 igralec2)
        //koda
        public Player aktivniIgralec()
        {
            return igralecNaPotezi == 1 ? igralec1 : igralec2;
        }


        //Naloga1
        //ta metoda bo izrisala trenutno stanje postavitve fiur
        public void izrisiStanjeIgre()
        {
            string[,] polja = new string[9, 9];

            foreach (ChessPiece figura in igralec1.MojeFigure)
            {
                polja[figura.Position.X, figura.Position.Y] = figura.OznakaFigure;
            }

            foreach (ChessPiece figura in igralec2.MojeFigure)
            {
                polja[figura.Position.X, figura.Position.Y] = figura.OznakaFigure.ToLower();
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


     
        public Player neaktivniIgralec()
        {
            if (igralecNaPotezi == 1)
            {
                return igralec2;
            }
            else
            {
                return igralec1;
            }
        }
        public void narediPotezoNakljucno(bool napadalniNacin)
        {
            if (aktivniIgralec().MojeFigure.Count == 0 || neaktivniIgralec().MojeFigure.Count == 0)
            {
                Console.WriteLine("Premalo figur za igro!");
                return;
            }
            Random rnd = new Random();
            ChessPiece figura = aktivniIgralec().MojeFigure[rnd.Next(0, aktivniIgralec().MojeFigure.Count - 1)];

            List<ChessBoardField> sezdovoljeni = figura.dovoljeniPremikiIgra(aktivniIgralec(), neaktivniIgralec());
            ChessBoardField pozicijanova = sezdovoljeni[rnd.Next(0, sezdovoljeni.Count - 1)];
            if (napadalniNacin == true) {
                //v kolikor lahko figura požre nasprotnikovo to storimo
                foreach (ChessBoardField poz in sezdovoljeni)
                {
                    if (neaktivniIgralec ().obstajaFiguraNaPoziciji (poz) ==true )
                    {
                        pozicijanova = poz;
                        break;
                    }
                }

            } 
            
            //naredimo premik
            if (igralecNaPotezi == 1)
            {
                Console.WriteLine($" {aktivniIgralec().ime} Premik {figura.OznakaFigure} ({figura.Position.X},{figura.Position.Y}) na ({pozicijanova.X}, {pozicijanova.Y})");
            }
            else
            {
                Console.WriteLine($" {aktivniIgralec().ime} Premik {figura.OznakaFigure.ToLower()} ({figura.Position.X},{figura.Position.Y}) na ({pozicijanova.X}, {pozicijanova.Y})");
            }
            igralecPremakne(figura, pozicijanova);
          
        }

        public void igralecPremakne(ChessPiece figura, ChessBoardField pozicijanova)
        {
            try
            {

                // figura.izpisiPremike();
                figura.Move(pozicijanova, aktivniIgralec(),neaktivniIgralec());
               // figura.izpisiPremike();

                //zamenjamo igralca, ki na potezi
                igralecNaPotezi = (igralecNaPotezi == 1) ? 2 : 1;

            } catch
            {
                Console.WriteLine("NapakaPremika (nekaj ni ok s kodo)");
            }

            
        }


    }
}
