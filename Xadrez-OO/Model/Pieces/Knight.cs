using Xadrez_OO.Util;

namespace Xadrez_OO.Model.Pieces {

    class Knight : Piece {

        //Constructors
        public Knight(Board board, Color color) : base(board, color) { }

        //toString
        public override string ToString() {

            return "N";
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
