using System.Collections.Generic;
using Xadrez_OO.Model;
using Xadrez_OO.Model.Pieces;
using Xadrez_OO.Util;
using Xadrez_OO.Exceptions;

namespace Xadrez_OO.Business {

    class ChessGame {

        //Atributes
        private Board board;
        private int shift;
        private Color turn;
        private bool finished;
        private bool check;

        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;
        private Piece enPassant;

        //Constructor
        public ChessGame () {
        
            //Inicial Settings
            this.board = new Board(8, 8);
            this.shift = 1;
            this.turn = Color.White;
            this.finished = false;
            this.check = false;
            this.enPassant = null;

            //Instancing lists
            this.pieces = new HashSet<Piece>();
            this.captured = new HashSet<Piece>();

            //Placing the pieces into inicial position
            StartGame();

        }

        //Getter/Setter
        public Board GetBoard () {

            return this.board;
        }

        public void SetBoard (Board board) {

            this.board = board;
        }

        public int GetShift () {

            return this.shift;
        }

        public void SetShift (int shift) {

            this.shift = shift;
        }

        public Color GetTurn () {

            return this.turn;
        }

        public void SetColor (Color color) {

            this.turn = color;
        }

        public Piece GetEnPassant () {

            return enPassant;
        }

        public void FinishGame () {

            this.finished = true;
        }

        public bool IsFinished () {

            return this.finished;
        }

        public bool IsChecked () {

            return this.check;
        }

        //Class Methods
        public void ValidateOrigin (Position origin) {

            //Selecionou campo vazio
            if (board.GetPiece(origin.GetLine(), origin.GetColumn()) == null) {

                throw new BoardException(" This field is empty!");
            }
            //Selecionou peça do inimigo
            else if (turn != board.GetPiece(origin.GetLine(), origin.GetColumn()).GetColor()) {

                throw new BoardException(" This piece isn't yours!");
            }
            //Selecionou peça com nenhum movimento possivel
            else if (!board.GetPiece(origin.GetLine(), origin.GetColumn()).HasPossibleMoves()) {

                throw new BoardException(" There is no possible moves for this piece!");
            }

        }

        public void ValidateDestiny (Position origin, Position destiny) {

            //Invalid move
            if (!board.GetPiece(origin.GetLine(), origin.GetColumn()).CanMoveTo(destiny)) {

                throw new BoardException(" Invalid move!");
            }

        }

        public Piece MakeMove (Position from, Position to) {

            //Removing piece from original position and placing into a new one
            Piece piece = board.RemovePiece(from);
            piece.IncrementMoves();
            Piece captured = board.RemovePiece(to);
            board.PlacePiece(piece, to);

            //Adding captured piece into the collection if exists
            if (captured != null) this.captured.Add(captured);

            //# Adding Special Move: roque pequeno
            if (piece is King && to.GetColumn() == from.GetColumn() + 2) {

                Position ft = new Position(from.GetLine(), from.GetLine() + 3);
                Position dt = new Position(from.GetLine(), from.GetLine() + 1);
                Piece rook = board.RemovePiece(ft);
                rook.IncrementMoves();
                board.PlacePiece(rook, dt);
            }

            //# Adding Special Move: roque grande
            if (piece is King && to.GetColumn() == from.GetColumn() - 2) {

                Position ft = new Position(from.GetLine(), from.GetLine() - 4);
                Position dt = new Position(from.GetLine(), from.GetLine() - 1);
                Piece rook = board.RemovePiece(ft);
                rook.IncrementMoves();
                board.PlacePiece(rook, dt);
            }

            //# Adding Special Move: en passant
            if (piece is Pawn) {

                if (from.GetColumn() != to.GetColumn() && captured == null) {

                    Position pos;

                    //Verifying pawn color
                    if (piece.GetColor() == Color.White) {

                        pos = new Position(to.GetLine() + 1, to.GetColumn());
                    }
                    else {

                        pos = new Position(to.GetLine() - 1, to.GetColumn());
                    }

                    //Removing the pawn from the game
                    captured = board.RemovePiece(pos);
                    this.captured.Add(captured);

                }
            }

            //Returing captured piece
            return captured;

        }

        public void UndoMove (Position from, Position to, Piece piece) {

            //Removendo peça na posição de destino (ultima jogada)
            Piece p = board.RemovePiece(to);
            p.DecrementMoves();

            //Verificando se alguma peça foi capturada no processo
            if (piece != null) {

                //Recolocando peça capturada
                board.PlacePiece(piece, to);
                captured.Remove(piece);
            }

            //Recolocando a peçamovida para origem
            board.PlacePiece(p, from);

            //# Removing Special Move: roque pequeno
            if (p is King && to.GetColumn() == from.GetColumn() + 2) {

                Position ft = new Position(from.GetLine(), from.GetLine() + 3);
                Position dt = new Position(from.GetLine(), from.GetLine() + 1);
                Piece king = board.RemovePiece(dt);
                king.DecrementMoves();
                board.PlacePiece(king, ft);
            }

            //# Removing Special Move: roque grande
            if (p is King && to.GetColumn() == from.GetColumn() - 2) {

                Position ft = new Position(from.GetLine(), from.GetLine() - 4);
                Position dt = new Position(from.GetLine(), from.GetLine() - 1);
                Piece king = board.RemovePiece(dt);
                king.DecrementMoves();
                board.PlacePiece(king, ft);
            }

            //# Removing Special Move: enPassant
            if (p is Pawn) {

                if (from.GetColumn() != to.GetColumn() && piece == this.enPassant) {

                    //Undoing the move
                    Piece pawn = board.RemovePiece(to);
                    Position posPawn;

                    //Verifying the pawn color
                    if (p.GetColor() == Color.White) {

                        posPawn = new Position(3, to.GetColumn());
                    }
                    else {

                        posPawn = new Position(4, to.GetColumn());
                    }

                    //Replacing the piece
                    board.PlacePiece(pawn, posPawn);

                }

            }

        } 

        public void PlayTurn (Position from, Position to) {

            //Making a move
            Piece cap = MakeMove(from, to);

            //Verificando se essa jogada te deixa em check
            if (InCheck(turn)) {

                //Desfazendo a jogada
                UndoMove(from, to, cap);
                throw new BoardException(" You cannot put yourself in check!");

            }

            Piece p = board.GetPiece(to.GetLine(), to.GetColumn());

            //# Special Move: promoção
            if (p is Pawn) {

                //Verificando cor
                if (p.GetColor() == Color.White && to.GetLine() == 0
                    || p.GetColor() == Color.Black && to.GetLine() == 7) {

                    p = board.RemovePiece(to);
                    pieces.Remove(p);

                    //Criando nova rainha para substituir o peão promovido
                    Piece queen = new Queen(board, p.GetColor());
                    board.PlacePiece(queen, to);
                    pieces.Add(queen);

                }

            }

            //Verificando se jogador adversário esta em check
            if (InCheck(GetEnemyColor(turn))) {

                check = true;
            }
            else {

                check = false;
            }

            //Verificando check mate
            if (Mates(GetEnemyColor(turn))) {

                //Finalizando jogo
                finished = true;
            }
            else {

                //Finalizando turno  e mudando de jogador
                ChangeTurn();
                this.shift++;

            }

            //# Special move: EnPassant
            if (p is Pawn 
                && to.GetLine() == from.GetLine() -2 
                || to.GetLine() == from.GetLine() + 2) {

                //Peça vuneravel a tomar enPassant
                enPassant = p;

            }
            else {

                enPassant = null;
            }

        }

        public void ChangeTurn () {

            if (turn == Color.White) {

                this.turn = Color.Black;
            }
            else {

                this.turn = Color.White;
            }
        }

        private void PlaceNewPiece (char column, int line, Piece piece) {

            //Adds a new piece into the board and register it into the collection
            board.PlacePiece(piece, new ChessPos(column, line).ToPosition());
            pieces.Add(piece);
        }

        public HashSet<Piece> GetCapturedPieces (Color color) {

            //Instanciando coleção de retorno
            HashSet<Piece> _return = new HashSet<Piece>();

            //Verificando peças capturadas de uma cor especificada
            foreach (Piece _piece in this.captured) {

                if (_piece.GetColor() == color) {

                    _return.Add(_piece);
                }

            }

            //Retornando peças encontradas
            return _return;

        }

        public HashSet<Piece> GetInGamePieces (Color color) {

            //Instanciando coleção de retorno
            HashSet<Piece> _return = new HashSet<Piece>();

            //Verificando peças em jogo de uma cor especificada
            foreach (Piece _piece in this.pieces) {

                if (_piece.GetColor() == color) {

                    _return.Add(_piece);
                }

            }

            //Removendo peças capturadas do conjunto de peças do jogo
            _return.ExceptWith(GetCapturedPieces(color));

            //Retornando peças encontradas
            return _return;

        }

        private Color GetEnemyColor (Color color) {

            if (color == Color.White) {

                return Color.Black;
            }
            else {

                return Color.White;
            }
        }

        private Piece GetKing (Color color) {

            //Percorrendo peças em jogo e procurando pelo rei
            foreach (Piece x in GetInGamePieces(color)) {

                //Rei encontrado
                if (x is King) return x;

            }

            //Rei não encontrado
            return null;

        }

        private void StartGame () {

            //Placing white pieces
            PlaceNewPiece('a', 2, new Pawn(board, Color.White, this));
            PlaceNewPiece('b', 2, new Pawn(board, Color.White, this));
            PlaceNewPiece('c', 2, new Pawn(board, Color.White, this));
            PlaceNewPiece('d', 2, new Pawn(board, Color.White, this));
            PlaceNewPiece('e', 2, new Pawn(board, Color.White, this));
            PlaceNewPiece('f', 2, new Pawn(board, Color.White, this));
            PlaceNewPiece('g', 2, new Pawn(board, Color.White, this));
            PlaceNewPiece('h', 2, new Pawn(board, Color.White, this));
            PlaceNewPiece('a', 1, new Rook(board, Color.White));
            PlaceNewPiece('h', 1, new Rook(board, Color.White));
            PlaceNewPiece('b', 1, new Knight(board, Color.White));
            PlaceNewPiece('g', 1, new Knight(board, Color.White));
            PlaceNewPiece('c', 1, new Bishop(board, Color.White));
            PlaceNewPiece('f', 1, new Bishop(board, Color.White));
            PlaceNewPiece('d', 1, new Queen(board, Color.White));
            PlaceNewPiece('e', 1, new King(board, Color.White, this));

            //Placing black pieces
            PlaceNewPiece('a', 7, new Pawn(board, Color.Black, this));
            PlaceNewPiece('b', 7, new Pawn(board, Color.Black, this));
            PlaceNewPiece('c', 7, new Pawn(board, Color.Black, this));
            PlaceNewPiece('d', 7, new Pawn(board, Color.Black, this));
            PlaceNewPiece('e', 7, new Pawn(board, Color.Black, this));
            PlaceNewPiece('f', 7, new Pawn(board, Color.Black, this));
            PlaceNewPiece('g', 7, new Pawn(board, Color.Black, this));
            PlaceNewPiece('h', 7, new Pawn(board, Color.Black, this));
            PlaceNewPiece('a', 8, new Rook(board, Color.Black));
            PlaceNewPiece('h', 8, new Rook(board, Color.Black));
            PlaceNewPiece('b', 8, new Knight(board, Color.Black));
            PlaceNewPiece('g', 8, new Knight(board, Color.Black));
            PlaceNewPiece('c', 8, new Bishop(board, Color.Black));
            PlaceNewPiece('f', 8, new Bishop(board, Color.Black));
            PlaceNewPiece('d', 8, new Queen(board, Color.Black));
            PlaceNewPiece('e', 8, new King(board, Color.Black, this));

        }

        //Check methods
        public bool InCheck (Color color) {

            //Recuperando rei da cor
            Piece king = GetKing(color);

            //Exceção que não será disparada provavelmente mais vai que...
            if (king == null) throw new BoardException(" Ops... looks like an error ocurred, you have no king!");

            //Varrendo todas as peças adversárias  vendo se há algo dando check no rei
            foreach (Piece x in GetInGamePieces (GetEnemyColor(color))) {

                //Recuperando movimentos possiveis
                bool[,] moves = x.Possiblemoves();

                //Verificando se há algo dando check na posição do rei
                if (moves[king.GetPosition().GetLine(), king.GetPosition().GetColumn()]) {

                    //King is in check
                    return true;
                }

            }


            //King is not in check
            return false;

        }

        public bool Mates (Color color) {

            //Verificando se está em check
            if (!InCheck(color)) return false;

            //Varrendo todas peças da cor indicada
            foreach (Piece x in GetInGamePieces(color)) {

                bool[,] moves = x.Possiblemoves();

                //Verificando se há ao menos um movimento possivel para tirar co check
                for (int i = 0; i < board.GetLines(); i++) {

                    for (int j = 0; j < board.GetColumns(); j++) {

                        if (moves[i,j]) {

                            //Tentando realizar um movimento
                            Position from = x.GetPosition();
                            Position to = new Position(i, j);
                            Piece cap = MakeMove(from, to);
                            bool checkTest = InCheck(color);
                            UndoMove(from, to, cap);

                            //Ta salvo rapas heuhe não é mate ainda
                            if (!checkTest) return false;

                        }

                    }

                }

            }

            //Fudeo de vez maluco, check mate
            return true;

        }

    }

}
