using Xadrez_OO.Util;

namespace Xadrez_OO.Model.Pieces {

    class Knight : Piece {

        //Constructors
        public Knight(Board board, Color color) : base(board, color) { }

        //toString
        public override string ToString() {

            return "N";
        }

    }

}
