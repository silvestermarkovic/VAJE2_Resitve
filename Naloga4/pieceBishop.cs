using System;
using System.Collections.Generic;
using System.Text;

namespace Naloga4
{

    //TODO ustvarite razred pieceRunner z vsemi potrebnimi metodami
    public class Bishop : ChessPiece
    {
        public Bishop(ChessBoardField start) : base(start)
        {
            this.ChessWeight = 3;
        }


        //TODO prepišite metodo move
        public override void Move(ChessBoardField field)
        {
            //giblje se lahko po diagonalah
            int premik_x = this.Position.X - field.X;
            int premik_y = this.Position.Y - field.Y;


            // Pravilo za premik trdnjave
            if (Math.Abs(premik_x) != Math.Abs(premik_y))
                throw new Exception("Nedovoljen premik!");

            base.Move(field);
        }
    }
}
