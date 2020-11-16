using System;
using System.Collections.Generic;
using System.Text;

namespace Naloga4
{
    public class Rook : ChessPiece
    {
        private const double chessWeight = 4.9;
        private const string oznakaFigure = "R";
        public Rook(ChessBoardField start) : base(start)
        {
            this.OznakaFigure = oznakaFigure;
            this.ChessWeight = chessWeight;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nMoje ime je {this.GetType()}";
        }

        /// <summary>
        /// Trdnjava se premika samo po linijah in vrstah
        /// </summary>
        /// <param name="field">Polje na plošči</param>
        public override void Move(ChessBoardField field, Player jaz, Player nasprotnik)
        {
            //giblje se lahko po diagonalah
            int premik_x = this.Position.X - field.X;
            int premik_y = this.Position.Y - field.Y;


            // Pravilo za premik tekaca
            // Pravilo za premik trdnjave
            if ((Math.Abs(premik_x) != Math.Abs(premik_y)) && 
                (this.Position.X != field.X && this.Position.Y != field.Y))
                throw new Exception("Nedovoljen premik!");

            base.Move(field, jaz, nasprotnik);
        }

        //TODO ustvarite metodo, ki bo vrnila seznam pozicij, kamor se figura lahko premakne glede na trenutno pozicijo
        /*
        public override List<ChessBoardField> dovoljeniPremiki 
        {
            get
            {
                List<ChessBoardField> seznam = new List<ChessBoardField>();
                for (int i = 0; i < 8; i++)
                {
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
            List<ChessBoardField> seznam = new List<ChessBoardField>();

            //premik Desno
            for (int i = 1 ; i <= 8 - Position.X; i++)
            {

                int temp_x = Position.X + i;
                int temp_y = Position.Y;

                if (nasprotnik.obstajaFiguraNaPoziciji(new ChessBoardField(temp_x, temp_y)) == true)
                {
                    //nasprotnik ima figuro na tej poziciji (na to pozicijo se lahko premaknemo naprej ne)
                    seznam.Add(new ChessBoardField(temp_x, temp_y));
                break;
                } else if (jaz.obstajaFiguraNaPoziciji(new ChessBoardField(temp_x, temp_y)) == true)
                {
                    //če je tam moja figura zaključimo, tega mesta ne dodamo
                    break;
                } else 
                {
                        seznam.Add(new ChessBoardField(temp_x, temp_y));
                }
            }
            //premik Levo
            for (int i = 1; i < Position.X; i++)
            {
                int temp_x = Position.X - i;
                int temp_y = Position.Y;
                if (nasprotnik.obstajaFiguraNaPoziciji(new ChessBoardField(temp_x, temp_y)) == true)
                {
                    //nasprotnik ima figuro na tej poziciji (na to pozicijo se lahko premaknemo naprej ne)
                    seznam.Add(new ChessBoardField(temp_x, temp_y));
                    break;
                }
                else if (jaz.obstajaFiguraNaPoziciji(new ChessBoardField(temp_x, temp_y)) == true)
                {
                    //če je tam moja figura zaključimo, tega mesta ne dodamo
                    break;
                }
                else
                {
                    seznam.Add(new ChessBoardField(temp_x, temp_y));
                }
            }


            //premik Gor
            for (int i = 1; i <= 8 - Position.Y; i++)
            {
                int temp_x = Position.X;
                int temp_y = Position.Y + i;
                if (nasprotnik.obstajaFiguraNaPoziciji(new ChessBoardField(temp_x, temp_y)) == true)
                {
                    //nasprotnik ima figuro na tej poziciji (na to pozicijo se lahko premaknemo naprej ne)
                    seznam.Add(new ChessBoardField(temp_x, temp_y));
                    break;
                }
                else if (jaz.obstajaFiguraNaPoziciji(new ChessBoardField(temp_x, temp_y)) == true)
                {
                    //če je tam moja figura zaključimo, tega mesta ne dodamo
                    break;
                }
                else
                {
                    seznam.Add(new ChessBoardField(temp_x, temp_y));
                }
            }

            //premik Dol
            for (int i = 1; i < Position.Y; i++)
            {
                int temp_x = Position.X;
                int temp_y = Position.Y - i;
                if (nasprotnik.obstajaFiguraNaPoziciji(new ChessBoardField(temp_x, temp_y)) == true)
                {
                    //nasprotnik ima figuro na tej poziciji (na to pozicijo se lahko premaknemo naprej ne)
                    seznam.Add(new ChessBoardField(temp_x, temp_y));
                    break;
                }
                else if (jaz.obstajaFiguraNaPoziciji(new ChessBoardField(temp_x, temp_y)) == true)
                {
                    //če je tam moja figura zaključimo, tega mesta ne dodamo
                    break;
                }
                else
                {
                    seznam.Add(new ChessBoardField(temp_x, temp_y));
                }
            }
             
            return seznam;
        }
    }
}
