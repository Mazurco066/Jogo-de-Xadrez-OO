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

        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;

        //Constructor
        public ChessGame () {
        
            //Inicial Settings
            this.board = new Board(8, 8);
            this.shift = 1;
            this.turn = Color.White;
            this.finished = false;

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

        public void FinishGame () {

            this.finished = true;
        }

        public bool IsFinished () {

            return this.finished;
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

        public void MakeMove (Position from, Position to) {

            //Removing piece from original position and placing into a new one
            Piece piece = board.RemovePiece(from);
            piece.IncrementMoves();
            Piece captured = board.RemovePiece(to);
            board.PlacePiece(piece, to);

            //Adding captured piece into the collection if exists
            if (captured != null) this.captured.Add(captured);

        }

        public void PlayTurn (Position from, Position to) {

            //Making a move
            MakeMove(from, to);
            ChangeTurn();
            this.shift++;

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

        private void StartGame() {

            //Placing white pieces
            PlaceNewPiece('a', 2, new Pawn(board, Color.White));
            PlaceNewPiece('b', 2, new Pawn(board, Color.White));
            PlaceNewPiece('c', 2, new Pawn(board, Color.White));
            PlaceNewPiece('d', 2, new Pawn(board, Color.White));
            PlaceNewPiece('e', 2, new Pawn(board, Color.White));
            PlaceNewPiece('f', 2, new Pawn(board, Color.White));
            PlaceNewPiece('g', 2, new Pawn(board, Color.White));
            PlaceNewPiece('h', 2, new Pawn(board, Color.White));
            PlaceNewPiece('a', 1, new Rook(board, Color.White));
            PlaceNewPiece('h', 1, new Rook(board, Color.White));
            PlaceNewPiece('b', 1, new Knight(board, Color.White));
            PlaceNewPiece('g', 1, new Knight(board, Color.White));
            PlaceNewPiece('c', 1, new Bishop(board, Color.White));
            PlaceNewPiece('f', 1, new Bishop(board, Color.White));
            PlaceNewPiece('d', 1, new King(board, Color.White));
            PlaceNewPiece('e', 1, new Queen(board, Color.White));

            //Placing black pieces
            PlaceNewPiece('a', 7, new Pawn(board, Color.Black));
            PlaceNewPiece('b', 7, new Pawn(board, Color.Black));
            PlaceNewPiece('c', 7, new Pawn(board, Color.Black));
            PlaceNewPiece('d', 7, new Pawn(board, Color.Black));
            PlaceNewPiece('e', 7, new Pawn(board, Color.Black));
            PlaceNewPiece('f', 7, new Pawn(board, Color.Black));
            PlaceNewPiece('g', 7, new Pawn(board, Color.Black));
            PlaceNewPiece('h', 7, new Pawn(board, Color.Black));
            PlaceNewPiece('a', 8, new Rook(board, Color.Black));
            PlaceNewPiece('h', 8, new Rook(board, Color.Black));
            PlaceNewPiece('b', 8, new Knight(board, Color.Black));
            PlaceNewPiece('g', 8, new Knight(board, Color.Black));
            PlaceNewPiece('c', 8, new Bishop(board, Color.Black));
            PlaceNewPiece('f', 8, new Bishop(board, Color.Black));
            PlaceNewPiece('d', 8, new King(board, Color.Black));
            PlaceNewPiece('e', 8, new Queen(board, Color.Black));

        }

    }

}
