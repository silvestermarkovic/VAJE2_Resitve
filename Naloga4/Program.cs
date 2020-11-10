using System;

namespace Naloga4
{
    class Program
    {
        static void Main(string[] args)
        {

           // piece.Move(fieldEnd);
           //pozicija
            Player player = new Player();
            
            Rook top1 = new Rook(new  ChessBoardField(1,1));
            Rook top2 =new Rook(new ChessBoardField(8,1));

            Bishop tekac1 = new Bishop(new ChessBoardField(3, 1));

            Bishop tekac2 = new Bishop(new ChessBoardField(6, 1));
            tekac1.ToString();
            tekac1.Move(new ChessBoardField(4, 2));
            tekac1.ToString();
            tekac1.Move(new ChessBoardField(5, 5));
            tekac1.ToString();

        }
    }
}
