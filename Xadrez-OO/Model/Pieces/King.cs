using Xadrez_OO.Util;

namespace Xadrez_OO.Model.Pieces {

    class King : Piece {

        //Constructors
        public King (Board board, Color color) : base (board, color) {}

        //toString
        public override string ToString() {

            return "K";
        }

        //Especified class methods
        public override bool[,] Possiblemoves() {

            //Creating the method return
            bool[,] _return = new bool[base.GetBoard().GetLines(), base.GetBoard().GetColumns()];

            Position pos = new Position(0, 0);

            //Upper
            pos.SetLine(GetPosition().GetLine() - 1);
            pos.SetColumn(GetPosition().GetColumn());

            if (GetBoard().IsValidPos(pos) && CanMove(pos)) {

                //OK this move is valid
                _return[pos.GetLine(), pos.GetColumn()] = true;
            }

            //Upper right
            pos.SetLine(GetPosition().GetLine() - 1);
            pos.SetColumn(GetPosition().GetColumn() + 1);

            if (GetBoard().IsValidPos(pos) && CanMove(pos)) {

                //OK this move is valid
                _return[pos.GetLine(), pos.GetColumn()] = true;
            }

            //Right
            pos.SetLine(GetPosition().GetLine());
            pos.SetColumn(GetPosition().GetColumn() + 1);

            if (GetBoard().IsValidPos(pos) && CanMove(pos)) {

                //OK this move is valid
                _return[pos.GetLine(), pos.GetColumn()] = true;
            }

            //Bottom Right
            pos.SetLine(GetPosition().GetLine() + 1);
            pos.SetColumn(GetPosition().GetColumn() + 1);

            if (GetBoard().IsValidPos(pos) && CanMove(pos)) {

                //OK this move is valid
                _return[pos.GetLine(), pos.GetColumn()] = true;
            }

            //Bottom
            pos.SetLine(GetPosition().GetLine() + 1);
            pos.SetColumn(GetPosition().GetColumn());

            if (GetBoard().IsValidPos(pos) && CanMove(pos)) {

                //OK this move is valid
                _return[pos.GetLine(), pos.GetColumn()] = true;
            }

            //Bottom Left
            pos.SetLine(GetPosition().GetLine() + 1);
            pos.SetColumn(GetPosition().GetColumn() - 1);

            if (GetBoard().IsValidPos(pos) && CanMove(pos)) {

                //OK this move is valid
                _return[pos.GetLine(), pos.GetColumn()] = true;
            }

            //Left
            pos.SetLine(GetPosition().GetLine());
            pos.SetColumn(GetPosition().GetColumn() - 1);

            if (GetBoard().IsValidPos(pos) && CanMove(pos)) {

                //OK this move is valid
                _return[pos.GetLine(), pos.GetColumn()] = true;
            }

            //upprer Left
            pos.SetLine(GetPosition().GetLine() - 1);
            pos.SetColumn(GetPosition().GetColumn() - 1);

            if (GetBoard().IsValidPos(pos) && CanMove(pos)) {

                //OK this move is valid
                _return[pos.GetLine(), pos.GetColumn()] = true;
            }

            //Returning possible moves
            return _return;

        }

    }

}
