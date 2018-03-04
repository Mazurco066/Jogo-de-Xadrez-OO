using Xadrez_OO.Util;

namespace Xadrez_OO.Model.Pieces {

    class Bishop : Piece {

        //Constructors
        public Bishop(Board board, Color color) : base(board, color) { }

        //toString
        public override string ToString() {

            return "B";
        }

        //Especified class methods
        public override bool[,] Possiblemoves() {

            //Creating the method return
            bool[,] _return = new bool[base.GetBoard().GetLines(), base.GetBoard().GetColumns()];

            //Instanciando uma posiçao
            Position pos = new Position(0, 0);

            //Diagonal esquerda cima
            pos.SetLine(GetPosition().GetLine() - 1);
            pos.SetColumn(GetPosition().GetColumn() - 1);

            while (GetBoard().IsValidPos(pos) && CanMove(pos)) {

                //Ok movimento válido
                _return[pos.GetLine(), pos.GetColumn()] = true;

                if (GetBoard().GetPiece(pos.GetLine(), pos.GetColumn()) != null &&
                    GetBoard().GetPiece(pos.GetLine(), pos.GetColumn()).GetColor() != GetColor()) {

                    break;
                }

                //Ok indoo para proxima posição
                pos.SetLine(pos.GetLine() - 1);
                pos.SetColumn(pos.GetColumn() - 1);

            }

            //Diagonal direita cima
            pos.SetLine(GetPosition().GetLine() - 1);
            pos.SetColumn(GetPosition().GetColumn() + 1);

            while (GetBoard().IsValidPos(pos) && CanMove(pos)) {

                //Ok movimento válido
                _return[pos.GetLine(), pos.GetColumn()] = true;

                if (GetBoard().GetPiece(pos.GetLine(), pos.GetColumn()) != null &&
                    GetBoard().GetPiece(pos.GetLine(), pos.GetColumn()).GetColor() != GetColor()) {

                    break;
                }

                //Ok indoo para proxima posição
                pos.SetLine(pos.GetLine() - 1);
                pos.SetColumn(pos.GetColumn() + 1);

            }

            //Diagonal direita baixo
            pos.SetLine(GetPosition().GetLine() + 1);
            pos.SetColumn(GetPosition().GetColumn() + 1);

            while (GetBoard().IsValidPos(pos) && CanMove(pos)) {

                //Ok movimento válido
                _return[pos.GetLine(), pos.GetColumn()] = true;

                if (GetBoard().GetPiece(pos.GetLine(), pos.GetColumn()) != null &&
                    GetBoard().GetPiece(pos.GetLine(), pos.GetColumn()).GetColor() != GetColor()) {

                    break;
                }

                //Ok indoo para proxima posição
                pos.SetLine(pos.GetLine() + 1);
                pos.SetColumn(pos.GetColumn() + 1);

            }

            //Diagonal esquerda baixo
            pos.SetLine(GetPosition().GetLine() + 1);
            pos.SetColumn(GetPosition().GetColumn() - 1);

            while (GetBoard().IsValidPos(pos) && CanMove(pos)) {

                //Ok movimento válido
                _return[pos.GetLine(), pos.GetColumn()] = true;

                if (GetBoard().GetPiece(pos.GetLine(), pos.GetColumn()) != null &&
                    GetBoard().GetPiece(pos.GetLine(), pos.GetColumn()).GetColor() != GetColor()) {

                    break;
                }

                //Ok indoo para proxima posição
                pos.SetLine(pos.GetLine() + 1);
                pos.SetColumn(pos.GetColumn() - 1);

            }

            //Returning possible moves
            return _return;

        }

    }

}
