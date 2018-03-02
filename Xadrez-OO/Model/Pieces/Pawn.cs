using Xadrez_OO.Util;

namespace Xadrez_OO.Model.Pieces {

    class Pawn : Piece {

        //Constructors
        public Pawn(Board board, Color color) : base(board, color) { }

        //toString
        public override string ToString() {

            return "P";
        }

    }

}
