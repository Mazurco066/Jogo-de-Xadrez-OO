using Xadrez_OO.Util;

namespace Xadrez_OO.Model.Pieces {

    class Rook : Piece {

        //Constructors
        public Rook(Board board, Color color) : base(board, color) { }

        //toString
        public override string ToString() {

            return "R";
        }

        //Especified class methods
        public override bool[,] Possiblemoves() {

            //Creating the method return
            bool[,] _return = new bool[base.GetBoard().GetLines(), base.GetBoard().GetColumns()];

            Position pos = new Position(0, 0);

            //Upper
            pos.SetLine(GetPosition().GetLine() - 1);
            pos.SetColumn(GetPosition().GetColumn());

            while (GetBoard().IsValidPos(pos) && CanMove(pos)) {

                //Ok this move is valid
                _return[pos.GetLine(), pos.GetColumn()] = true;

                //Stopping the while
                if (GetBoard().GetPiece(pos.GetLine(), pos.GetColumn()) != null && 
                    GetBoard().GetPiece(pos.GetLine(), pos.GetColumn()).GetColor() != GetColor()) {

                    //Breaking the loop
                    break;

                }

                //Incrementing the line
                pos.SetLine(pos.GetLine() - 1);
            }

            //Botton
            pos.SetLine(GetPosition().GetLine() + 1);
            pos.SetColumn(GetPosition().GetColumn());

            while (GetBoard().IsValidPos(pos) && CanMove(pos)) {

                //Ok this move is valid
                _return[pos.GetLine(), pos.GetColumn()] = true;

                //Stopping the while
                if (GetBoard().GetPiece(pos.GetLine(), pos.GetColumn()) != null &&
                    GetBoard().GetPiece(pos.GetLine(), pos.GetColumn()).GetColor() != GetColor()) {

                    //Breaking the loop
                    break;

                }

                //Incrementing the line
                pos.SetLine(pos.GetLine() + 1);
            }

            //Right
            pos.SetLine(GetPosition().GetLine());
            pos.SetColumn(GetPosition().GetColumn() + 1);

            while (GetBoard().IsValidPos(pos) && CanMove(pos)) {

                //Ok this move is valid
                _return[pos.GetLine(), pos.GetColumn()] = true;

                //Stopping the while
                if (GetBoard().GetPiece(pos.GetLine(), pos.GetColumn()) != null &&
                    GetBoard().GetPiece(pos.GetLine(), pos.GetColumn()).GetColor() != GetColor()) {

                    //Breaking the loop
                    break;

                }

                //Incrementing the line
                pos.SetColumn(pos.GetColumn() + 1);
            }

            //Left
            pos.SetLine(GetPosition().GetLine());
            pos.SetColumn(GetPosition().GetColumn() - 1);

            while (GetBoard().IsValidPos(pos) && CanMove(pos)) {

                //Ok this move is valid
                _return[pos.GetLine(), pos.GetColumn()] = true;

                //Stopping the while
                if (GetBoard().GetPiece(pos.GetLine(), pos.GetColumn()) != null &&
                    GetBoard().GetPiece(pos.GetLine(), pos.GetColumn()).GetColor() != GetColor()) {

                    //Breaking the loop
                    break;

                }

                //Incrementing the line
                pos.SetColumn(pos.GetColumn() - 1);
            }

            //Returning possible moves
            return _return;

        }

    }

}
