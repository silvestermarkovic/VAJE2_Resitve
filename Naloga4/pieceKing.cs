using System;
using System.Collections.Generic;
using System.Text;

namespace Naloga4
{
        public class King : ChessPiece
    {
        private const double chessWeight = double.PositiveInfinity;

        public King(ChessBoardField start) : base(start)
        {
            this.ChessWeight = chessWeight;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nMoje ime je {this.GetType()}";
        }

        //TODO dodajte metodo premik, ki prepiše osnovon

        public override void Move(ChessBoardField field)
        {
            // Pravilo za premik trdnjave

            int premik_x = Math.Abs(this.Position.X - field.X);
            int premik_y = Math.Abs(this.Position.Y - field.Y);

            if (premik_x > 1 || premik_y > 1 || (premik_x + premik_y ) == 0)
                throw new Exception("Nedovoljen premik!");

            //ta naredi dejanski premik brez kontrole
            base.Move(field);
        }

    }
}
