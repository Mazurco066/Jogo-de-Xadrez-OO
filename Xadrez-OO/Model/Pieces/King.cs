using Xadrez_OO.Util;
using Xadrez_OO.Business;

namespace Xadrez_OO.Model.Pieces {

    class King : Piece {

        //Atributes
        private ChessGame game;

        //Constructors
        public King (Board board, Color color) : base (board, color) {}

        public King(Board board, Color color, ChessGame game) : base(board, color) {

            this.game = game;
        }

        //toString
        public override string ToString() {

            return "K";
        }

        //Especified class methods
        private bool HasRook (Position pos) {

            Piece p = GetBoard().GetPiece(pos.GetLine(), pos.GetColumn());

            return  p != null && 
                    p is Rook && 
                    p.GetColor() == GetColor() && 
                    p.GetMoves() == 0;
        }

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

            //Upper Left
            pos.SetLine(GetPosition().GetLine() - 1);
            pos.SetColumn(GetPosition().GetColumn() - 1);

            if (GetBoard().IsValidPos(pos) && CanMove(pos)) {

                //OK this move is valid
                _return[pos.GetLine(), pos.GetColumn()] = true;
            }

            //#Special move: roque
            if (GetMoves() == 0 && !game.IsChecked()) {

                //#Special move: roque pequeno
                Position t1 = new Position(GetPosition().GetLine(), GetPosition().GetColumn() + 3);

                //Testando se ha torre elegivel
                if (HasRook(t1)) {

                    Position p1 = new Position(GetPosition().GetLine(), GetPosition().GetColumn() + 1);
                    Position p2 = new Position(GetPosition().GetLine(), GetPosition().GetColumn() + 2);

                    //Verificando se o caminho esta livre
                    if (GetBoard().GetPiece(p1.GetLine(), p1.GetColumn()) == null
                        && GetBoard().GetPiece(p2.GetLine(), p2.GetColumn()) == null) {

                        //Ok roque liberado
                        _return[GetPosition().GetLine(), GetPosition().GetColumn() + 2] = true;

                    }

                }

                //#Special move: roque grande
                Position t2 = new Position(GetPosition().GetLine(), GetPosition().GetColumn() - 4);

                //Testando se ha torre elegivel
                if (HasRook(t2)) {

                    Position p3 = new Position(GetPosition().GetLine(), GetPosition().GetColumn() - 1);
                    Position p4 = new Position(GetPosition().GetLine(), GetPosition().GetColumn() - 2);
                    Position p5 = new Position(GetPosition().GetLine(), GetPosition().GetColumn() - 3);


                    //Verificando se o caminho esta livre
                    if (GetBoard().GetPiece(p3.GetLine(), p3.GetColumn()) == null
                        && GetBoard().GetPiece(p4.GetLine(), p4.GetColumn()) == null
                        && GetBoard().GetPiece(p5.GetLine(), p5.GetColumn()) == null) {

                        //Ok roque liberado
                        _return[GetPosition().GetLine(), GetPosition().GetColumn() - 4] = true;

                    }

                }

            }

            //Returning possible moves
            return _return;

        }

    }

}
