using System;
using System.Collections.Generic;
using System.Text;

namespace Naloga4
{
     
     public class Queen : ChessPiece
    {
        private const double chessWeight = 9;
        private const string oznakaFigure = "Q";
        public Queen(ChessBoardField start) : base(start)
        {
            this.OznakaFigure= oznakaFigure;
            this.ChessWeight = chessWeight;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nMoje ime je {this.GetType()}";
        }

        //TODO dodajte metodo premik, ki prepiše osnovon

        public override void Move(ChessBoardField field, Player jaz, Player nasprotnik)
        {
            // Pravilo za premik kraljice
            // premakne se lahko le na polja Dovoljeni premiki
           
                if (this.Position.X != field.X && this.Position.Y != field.Y)

                    throw new Exception("Nedovoljen premik!");

            //ta naredi dejanski premik brez kontrole
            base.Move(field, jaz, nasprotnik);
        }

        /*
         * public override List<ChessBoardField> dovoljeniPremiki
        {

            get
            {
                List<ChessBoardField> seznam = new List<ChessBoardField>();

                //polja tekača
                for (int i = 1; i <= 7; i++)
                {
                    //gremo v 4 strani kot tekač in kot top
                    if (this.Position.X + i <= 8 && this.Position.Y + i <= 8)
                        seznam.Add(new ChessBoardField(this.Position.X + i, this.Position.Y + i));

                    if (this.Position.X - i > 0 && this.Position.Y + i <= 8)
                        seznam.Add(new ChessBoardField(this.Position.X - i, this.Position.Y + i));

                    if (this.Position.X + i <= 8 && this.Position.Y - i > 0)
                        seznam.Add(new ChessBoardField(this.Position.X + i, this.Position.Y - i));

                    if (this.Position.X - i > 0 && this.Position.Y - i > 0)
                        seznam.Add(new ChessBoardField(this.Position.X - i, this.Position.Y - i));

                    if (Position.X + i <= 8) seznam.Add(new ChessBoardField(Position.X + 1, Position.Y));
                    if (Position.X - i > 0) seznam.Add(new ChessBoardField(Position.X - 1, Position.Y));

                    if (Position.Y + i <= 8) seznam.Add(new ChessBoardField(Position.X, Position.Y + 1));
                    if (Position.Y - i > 0) seznam.Add(new ChessBoardField(Position.X, Position.Y - 1));

                }
                return seznam;
            }
        }
        */
        public override List<ChessBoardField> dovoljeniPremikiIgra(Player jaz, Player nasprotnik)
        {


            //premike dobimo tako, da damo skupaj dovoljene premike na tem mestu od Tekača in Topa

            Bishop tempTekac = new Bishop(this.Position);
            Rook tempTop = new Rook (this.Position);

            List<ChessBoardField> tempSezTekac = tempTekac.dovoljeniPremikiIgra(jaz, nasprotnik);
            List<ChessBoardField> tempSezTop = tempTop.dovoljeniPremikiIgra(jaz, nasprotnik);

            foreach (ChessBoardField poz in tempSezTekac) {
                tempSezTop.Add(poz);
            }

            return tempSezTop;
        }
    }
}
