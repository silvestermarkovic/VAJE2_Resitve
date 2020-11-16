using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Naloga4
{

    //TODO ustvarite razred pieceRunner z vsemi potrebnimi metodami
    public class Bishop : ChessPiece
    {
        private const double chessweight= 3;
        private const string oznakaFigure = "B";
        public Bishop(ChessBoardField start) : base(start)
        {
            this.OznakaFigure = oznakaFigure;
            this.ChessWeight = 3;
        }


         
        

        //TODO prepišite metodo move
        public override void Move(ChessBoardField field,  Player jaz, Player nasprotnik)
        {
            //giblje se lahko po diagonalah
            int premik_x = this.Position.X - field.X;
            int premik_y = this.Position.Y - field.Y;


            // Pravilo za premik trdnjave
            if (Math.Abs(premik_x) != Math.Abs(premik_y))
                throw new Exception("Nedovoljen premik!");

            base.Move(field, jaz, nasprotnik);
        }
/*
        public override List<ChessBoardField> dovoljeniPremiki
        {
            get
            {
                List<ChessBoardField> seznam = new List<ChessBoardField>();
                base.dovoljeniPremikiIgraPozrem = new List<ChessBoardField>();
                
                for (int i = 1; i <= 7; i++)
                {
                    //gremo v 4 strani

                    if (this.Position.X + i <= 8 && this.Position.Y + i <= 8)
                        seznam.Add(new ChessBoardField(this.Position.X + i, this.Position.Y + i));

                    if (this.Position.X - i > 0 && this.Position.Y + i <= 8)
                        seznam.Add(new ChessBoardField(this.Position.X - i, this.Position.Y + i));

                    if (this.Position.X + i <= 8 && this.Position.Y - i > 0)
                        seznam.Add(new ChessBoardField(this.Position.X + i, this.Position.Y - i));

                    if (this.Position.X - i > 0 && this.Position.Y - i > 0)
                        seznam.Add(new ChessBoardField(this.Position.X - i, this.Position.Y - i));

                }
                return seznam;
            }
        }
*/

        public override List<ChessBoardField> dovoljeniPremikiIgra(Player jaz, Player nasprotnik)
        {
             
            
            List<ChessBoardField> seznam = new List<ChessBoardField>();
            //DesnoGor
            for (int i = 1; i <= 7; i++)
            {
           
                int temp_x = Position.X + i;
                int temp_y = Position.Y + i;

                if (temp_x > 8 || temp_x < 1 || temp_y > 8 || temp_y < 1) break;

                if (nasprotnik.obstajaFiguraNaPoziciji(new ChessBoardField(temp_x, temp_y)) == true)
                    {
                        //nasprotnik ima figuro na tej poziciji (na to pozicijo se lahko premaknemo naprej ne)
                        seznam.Add(new ChessBoardField(temp_x, Position.Y - i));
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
            //DesnoDol
            for (int i = 1; i <= 7; i++)
            {

                int temp_x = Position.X + i;
                int temp_y = Position.Y - i;

                if (temp_x > 8 || temp_x < 1 || temp_y > 8 || temp_y < 1) break;

                if (nasprotnik.obstajaFiguraNaPoziciji(new ChessBoardField(temp_x, temp_y)) == true)
                {
                    //nasprotnik ima figuro na tej poziciji (na to pozicijo se lahko premaknemo naprej ne)
                    seznam.Add(new ChessBoardField(temp_x, Position.Y - i));
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

            //LevoGor
            for (int i = 1; i <= 7; i++)
            {

                int temp_x = Position.X - i;
                int temp_y = Position.Y + i;

                if (temp_x > 8 || temp_x < 1 || temp_y > 8 || temp_y < 1) break;

                if (nasprotnik.obstajaFiguraNaPoziciji(new ChessBoardField(temp_x, temp_y)) == true)
                {
                    //nasprotnik ima figuro na tej poziciji (na to pozicijo se lahko premaknemo naprej ne)
                    seznam.Add(new ChessBoardField(temp_x, Position.Y - i));
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
            //LevoDol
            for (int i = 1; i <= 7; i++)
            {

                int temp_x = Position.X - i;
                int temp_y = Position.Y - i;

                if (temp_x > 8 || temp_x < 1 || temp_y > 8 || temp_y < 1) break;

                if (nasprotnik.obstajaFiguraNaPoziciji(new ChessBoardField(temp_x, temp_y)) == true)
                {
                    //nasprotnik ima figuro na tej poziciji (na to pozicijo se lahko premaknemo naprej ne)
                    seznam.Add(new ChessBoardField(temp_x, Position.Y - i));
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
