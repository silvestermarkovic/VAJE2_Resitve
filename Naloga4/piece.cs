using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Naloga4
{

    interface IPiece
    {
        /// <summary>
        /// Vsaka figura se zna premakniti na neko polje
        /// </summary>
        /// <param name="field">Polje, kamor se naj figura premakne</param>
        void Move(ChessBoardField field, Player jaz, Player nasprotnik);

        /// <summary>
        /// Vmesniki definirajo tudi lastnosti v enaki obliki, 
        /// kot v razredu definiramo samodejno implementirane lastnosti.
        /// Vendar moramo lastnosti vmesnika dejansko implementirati v razredu.
        /// </summary>
        bool IsAlive { get; set; }

        double ChessWeight { get; }

        ChessBoardField Position { get; }
    }

    /// <summary>
    /// Definiramo si struct za shranjevanje koordinat na šahovski plošči
    /// </summary>
    public class  ChessBoardField
    {
        /// <summary>
        /// Vodoravna koordinata
        /// </summary>
        public ChessBoardField(int p_x, int p_y)
        {
            X = p_x;
            Y = p_y;
        }

        public string oznaka { get; set; }

        public int X { get; set; }

        /// <summary>
        /// Navpična koordinata
        /// </summary>
        public int Y { get; set; }

        public override string ToString()
        {
            return $"({this.X},{this.Y})";
        }
    }

    
    /// <summary>
    /// V tem primeru naj razred implementira vmesnik IPiece,
    /// zato moramo implementirati tudi vse zahtevane metode in lastnosti vmesnika
    /// </summary>
    public abstract class ChessPiece : IPiece
    {
        public ChessPiece(ChessBoardField start)
        {
            this.position = start;
        }

        public double ChessWeight { get; protected set; }
        //oznaka figure, bo predstavljala String, ki se bo izpisovl
        public string  OznakaFigure { get; protected set; }
       


        public override string ToString()
        {
            return $"Sem šahovska figura z vrednostjo {this.ChessWeight}.";
        }

        /// <summary>
        /// Implementiramo metodo za premik figure.
        /// Vsaka figura ima svoja pravila za premike, 
        /// zato bomo to metodo zelo verjetno v vsakem izmed podrazredov prepisali ("override").
        /// V ta namen jo označimo za virtualno.
        /// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/virtual?f1url=%3FappId%3DDev16IDEF1%26l%3DEN-US%26k%3Dk(virtual_CSharpKeyword);k(DevLang-csharp)%26rd%3Dtrue
        /// </summary>
        /// <param name="field">Polje, kamor naj se figura premakne</param>
        public virtual void Move(ChessBoardField field, Player jaz, Player nasprotnik)
        {
            if (nasprotnik.obstajaFiguraNaPoziciji (field) == true)
            {
                //požremo figuro
                nasprotnik.odstraniFiguro(field);
                Console.WriteLine($"Igralec {jaz.ime} je pojedel igralcu {nasprotnik.ime} figuro na poziciji ({field.X}, {field.Y})");
            }

            position = field;
            
        }



        public abstract List<ChessBoardField> dovoljeniPremikiIgra(Player jaz, Player nasprotnik);
        //seznam figur, ki jih lahko požrem napolni se v metodi dovoljeniPremikiIgra!
        public List<ChessBoardField> dovoljeniPremikiIgraPozrem;


        //izpis premikov
        public void izpisiPremikeIgra(Player jaz, Player nasprotnik)
        {
            foreach (var kr1 in this.dovoljeniPremikiIgra(jaz, nasprotnik))
            {
                Console.WriteLine($"{kr1.X}, {kr1.Y}");
            }
        }

        public bool IsAlive { get; set; }

        /// <summary>
        /// Implementirana lastnost mora biti zapisana eksplicitno
        /// </summary>
        private ChessBoardField position;
        public ChessBoardField Position
        {
            get
            {
                return position;
            }
            /*private set 
            {
                position = value;
            } */
        }
    }

   
}
