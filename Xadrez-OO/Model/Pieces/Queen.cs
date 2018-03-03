using Xadrez_OO.Util;

namespace Xadrez_OO.Business.Pieces {

    class Queen : Piece {

        //Constructors
        public Queen(Board board, Color color) : base(board, color) { }

        //toString
        public override string ToString() {

            return "Q";
        }

    }

}
