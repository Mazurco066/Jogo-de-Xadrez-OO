using Xadrez_OO.Util;

namespace Xadrez_OO.Model.Pieces {

    class Queen : Piece {

        //Constructors
        public Queen(Board board, Color color) : base(board, color) { }

        //toString
        public override string ToString() {

            return "Q";
        }

        //Especified class methods
        public override bool[,] Possiblemoves() {

            //Creating the method return
            bool[,] _return = new bool[base.GetBoard().GetLines(), base.GetBoard().GetColumns()];

            //Returning possible moves
            return _return;

        }

    }

}
