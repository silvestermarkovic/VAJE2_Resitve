using System;
using System.Collections.Generic;
using System.Text;

namespace Naloga4
{
    public class Knight : ChessPiece
    {
        private const double chessWeight = 3;
        private const string oznakaFigure = "N";

        public Knight(ChessBoardField start) : base(start)
        {
            this.OznakaFigure = oznakaFigure;
            this.ChessWeight = chessWeight;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nMoje ime je {this.GetType()}";
        }

        //TODO dodajte metodo premik, ki prepiše osnovon

        public override void Move(ChessBoardField field, Player jaz, Player nasprotnik)
        {
             
            //ta naredi dejanski premik brez kontrole
            base.Move(field, jaz, nasprotnik);
        }


         
        public override List<ChessBoardField> dovoljeniPremikiIgra(Player jaz, Player nasprotnik)
        {
            List<ChessBoardField> seznam = new List<ChessBoardField>();


            for (int i = -1; i <= 1; i += 2)
            {
                for (int j = -1; j <= 1; j += 2)
                {
                    int temp_x = Position.X + 2 * i;
                    int temp_y = Position.Y + j;

                    if (temp_x > 8 || temp_x < 1 || temp_y > 8 || temp_y < 1) continue;
                    if (jaz.obstajaFiguraNaPoziciji(new ChessBoardField(temp_x, temp_y)) == false)
                        seznam.Add(new ChessBoardField(temp_x, temp_y));
                    

                    temp_x = Position.X + i;
                    temp_y = Position.Y + 2 * j;
                    if (temp_x > 8 || temp_x < 1 || temp_y > 8 || temp_y < 1) continue;
                    if (jaz.obstajaFiguraNaPoziciji(new ChessBoardField(temp_x, temp_y)) == false)
                        seznam.Add(new ChessBoardField(temp_x, temp_y));

                }
            }

            return seznam;
        }
    }
}
