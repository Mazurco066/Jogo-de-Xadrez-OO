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

            //Definindo uma posição
            Position pos = new Position(0, 0);

            //Verificando movimentos possiveis
            pos.SetLine(GetPosition().GetLine() - 1);
            pos.SetColumn(GetPosition().GetColumn() - 2);

            if (GetBoard().IsValidPos(pos) && CanMove(pos)) {

                _return[pos.GetLine(), pos.GetColumn()] = true;
            }

            //Second
            pos.SetLine(GetPosition().GetLine() - 2);
            pos.SetColumn(GetPosition().GetColumn() - 1);

            if (GetBoard().IsValidPos(pos) && CanMove(pos)) {

                _return[pos.GetLine(), pos.GetColumn()] = true;
            }

            //Third
            pos.SetLine(GetPosition().GetLine() - 2);
            pos.SetColumn(GetPosition().GetColumn() + 1);

            if (GetBoard().IsValidPos(pos) && CanMove(pos)) {

                _return[pos.GetLine(), pos.GetColumn()] = true;
            }

            //Fourth
            pos.SetLine(GetPosition().GetLine() - 1);
            pos.SetColumn(GetPosition().GetColumn() + 2);

            if (GetBoard().IsValidPos(pos) && CanMove(pos)) {

                _return[pos.GetLine(), pos.GetColumn()] = true;
            }

            //Fifith
            pos.SetLine(GetPosition().GetLine() + 1);
            pos.SetColumn(GetPosition().GetColumn() + 2);

            if (GetBoard().IsValidPos(pos) && CanMove(pos)) {

                _return[pos.GetLine(), pos.GetColumn()] = true;
            }

            //Sixth
            pos.SetLine(GetPosition().GetLine() + 2);
            pos.SetColumn(GetPosition().GetColumn() + 1);

            if (GetBoard().IsValidPos(pos) && CanMove(pos)) {

                _return[pos.GetLine(), pos.GetColumn()] = true;
            }

            //Seventh
            pos.SetLine(GetPosition().GetLine() + 2);
            pos.SetColumn(GetPosition().GetColumn() - 1);

            if (GetBoard().IsValidPos(pos) && CanMove(pos)) {

                _return[pos.GetLine(), pos.GetColumn()] = true;
            }

            //Eighth
            pos.SetLine(GetPosition().GetLine() + 1);
            pos.SetColumn(GetPosition().GetColumn() - 2);

            if (GetBoard().IsValidPos(pos) && CanMove(pos)) {

                _return[pos.GetLine(), pos.GetColumn()] = true;
            }

            //Returning possible moves
            return _return;

        }

    }

}
