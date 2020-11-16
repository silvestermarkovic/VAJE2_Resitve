using System;
using System.Collections.Generic;
using System.Text;

namespace Naloga4
{
        public class King : ChessPiece
    {
        private const double chessWeight = double.PositiveInfinity;
        private const string oznakaFigure = "K";

        public King(ChessBoardField start) : base(start)
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
            // Pravilo za premik trdnjave

            int premik_x = Math.Abs(this.Position.X - field.X);
            int premik_y = Math.Abs(this.Position.Y - field.Y);

            if (premik_x > 1 || premik_y > 1 || (premik_x + premik_y ) == 0)
                throw new Exception("Nedovoljen premik!");

            //ta naredi dejanski premik brez kontrole
            base.Move(field, jaz, nasprotnik);
        }
/*
        public override List<ChessBoardField> dovoljeniPremiki
        {
            get
            {
                List<ChessBoardField> seznam = new List<ChessBoardField>();

                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (i != 0 || j != 0)
                        {
                            if (this.Position.X + i >= 1 && this.Position.X + i <= 8 &&
                                this.Position.Y + j >= 1 && this.Position.Y + j <= 8)
                                seznam.Add(new ChessBoardField(this.Position.X + i, this.Position.Y + j));
                        }
                    }
                }

                return seznam;
            }
        }
*/
        public override List<ChessBoardField> dovoljeniPremikiIgra(Player jaz, Player nasprotnik)
        {
            List<ChessBoardField> seznam = new List<ChessBoardField>();
             
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i != 0 || j != 0)
                    {

                        if (this.Position.X + i >= 1 && this.Position.X + i <= 8 &&
                            this.Position.Y + j >= 1 && this.Position.Y + j <= 8)

                            if (nasprotnik.obstajaFiguraNaPoziciji(new ChessBoardField(this.Position.X + i, this.Position.Y + j)) == true)
                            {
                                //nasprotnik ima figuro na tej poziciji (na to pozicijo se lahko premaknemo)
                                seznam.Add(new ChessBoardField(this.Position.X + i, this.Position.Y + j));
                            }
                            else if (jaz.obstajaFiguraNaPoziciji(new ChessBoardField(this.Position.X + i, this.Position.Y + j)) == true)
                            {
                                //če je tam moja figura ne dodamo in nadaljujemo

                            }
                            else
                            {
                                seznam.Add(new ChessBoardField(this.Position.X + i, this.Position.Y + j));
                            }
                        
                    }
                }
            }
            return seznam;
        }
    }
}
