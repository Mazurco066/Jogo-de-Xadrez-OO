using Xadrez_OO.Util;

namespace Xadrez_OO.Model.Pieces {

    class Rook : Piece {

        //Constructors
        public Rook(Board board, Color color) : base(board, color) { }

        //toString
        public override string ToString() {

            return "R";
        }

    }

}
