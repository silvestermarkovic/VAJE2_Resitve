using System;
using System.Collections.Generic;
using System.Text;

namespace Naloga4
{
    public class Rook : ChessPiece
    {
        public Rook(ChessBoardField start) : base(start)
        {
            this.ChessWeight = 4.9;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nMoje ime je {this.GetType()}";
        }

        /// <summary>
        /// Trdnjava se premika samo po linijah in vrstah
        /// </summary>
        /// <param name="field">Polje na plošči</param>
        public override void Move(ChessBoardField field)
        {
            // Pravilo za premik trdnjave
            if (this.Position.X != field.X && this.Position.Y != field.Y)
                throw new Exception("Nedovoljen premik!");

            base.Move(field);
        }

        //TODO ustvarite metodo, ki bo vrnila seznam pozicij, kamor se figura lahko premakne glede na trenutno pozicijo
        


    }
}
