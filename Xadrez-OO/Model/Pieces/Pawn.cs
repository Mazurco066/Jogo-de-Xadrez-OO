using Xadrez_OO.Util;

namespace Xadrez_OO.Model.Pieces {

    class Pawn : Piece {

        //Constructors
        public Pawn(Board board, Color color) : base(board, color) { }

        //toString
        public override string ToString() {

            return "P";
        }

        //Especified class methods
        private bool HasEnemy (Position pos) {

            //Verifica se há inimigo na diagonal
            Piece p = GetBoard().GetPiece(pos.GetLine(), pos.GetColumn());
            return p != null && p.GetColor() != GetColor();
        }

        private bool IsAvaliable (Position pos) {

            //Verifica se a posição a frente dele esta livre
            return GetBoard().GetPiece(pos.GetLine(), pos.GetColumn()) == null;
        }

        public override bool[,] Possiblemoves() {

            //Creating the method return
            bool[,] _return = new bool[base.GetBoard().GetLines(), base.GetBoard().GetColumns()];

            //Definindo uma posição
            Position pos = new Position(0, 0);

            //Verificando cor do peão
            if (GetColor() == Color.White) {

                //Verificando casa a frente
                pos.SetLine(GetPosition().GetLine() - 1);
                pos.SetColumn(GetPosition().GetColumn());

                if (GetBoard().IsValidPos(pos) && IsAvaliable(pos)) {
                    
                    //Ok pode mover para essa posição
                    _return[pos.GetLine(), pos.GetColumn()] = true;
                }

                //Verificando duas casas a frente
                pos.SetLine(GetPosition().GetLine() - 2);
                pos.SetColumn(GetPosition().GetColumn());

                if (GetBoard().IsValidPos(pos) && IsAvaliable(pos) && GetMoves() == 0) {

                    //Ok pode mover para essa posição
                    _return[pos.GetLine(), pos.GetColumn()] = true;
                }

                //Verificando diagonal esquerda
                pos.SetLine(GetPosition().GetLine() - 1);
                pos.SetColumn(GetPosition().GetColumn() -1);

                if (GetBoard().IsValidPos(pos) && HasEnemy(pos)) {

                    //Ok pode mover para essa posição
                    _return[pos.GetLine(), pos.GetColumn()] = true;
                }

                //Verificando diagonal direita
                pos.SetLine(GetPosition().GetLine() - 1);
                pos.SetColumn(GetPosition().GetColumn() + 1);

                if (GetBoard().IsValidPos(pos) && HasEnemy(pos)) {

                    //Ok pode mover para essa posição
                    _return[pos.GetLine(), pos.GetColumn()] = true;
                }

            }
            else {

                //Verificando casa a frente
                pos.SetLine(GetPosition().GetLine() + 1);
                pos.SetColumn(GetPosition().GetColumn());

                if (GetBoard().IsValidPos(pos) && IsAvaliable(pos)) {

                    //Ok pode mover para essa posição
                    _return[pos.GetLine(), pos.GetColumn()] = true;
                }

                //Verificando duas casas a frente
                pos.SetLine(GetPosition().GetLine() + 2);
                pos.SetColumn(GetPosition().GetColumn());

                if (GetBoard().IsValidPos(pos) && IsAvaliable(pos) && GetMoves() == 0) {

                    //Ok pode mover para essa posição
                    _return[pos.GetLine(), pos.GetColumn()] = true;
                }

                //Verificando diagonal esquerda
                pos.SetLine(GetPosition().GetLine() + 1);
                pos.SetColumn(GetPosition().GetColumn() - 1);

                if (GetBoard().IsValidPos(pos) && HasEnemy(pos)) {

                    //Ok pode mover para essa posição
                    _return[pos.GetLine(), pos.GetColumn()] = true;
                }

                //Verificando diagonal direita
                pos.SetLine(GetPosition().GetLine() + 1);
                pos.SetColumn(GetPosition().GetColumn() + 1);

                if (GetBoard().IsValidPos(pos) && HasEnemy(pos)) {

                    //Ok pode mover para essa posição
                    _return[pos.GetLine(), pos.GetColumn()] = true;
                }

            }

            //Returning possible moves
            return _return;

        }

    }

}
