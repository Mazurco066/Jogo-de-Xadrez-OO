using Xadrez_OO.Util;

namespace Xadrez_OO.Model.Pieces {

    class King : Piece {

        //Constructors
        public King (Board board, Color color) : base (board, color) {}

        //toString
        public override string ToString() {

            return "K";
        }

    }

}
