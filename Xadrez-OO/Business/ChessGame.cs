using Xadrez_OO.Model;
using Xadrez_OO.Model.Pieces;
using Xadrez_OO.Util;

namespace Xadrez_OO.Business {

    class ChessGame {

        //Atributes
        private Board board;
        private int shift;
        private Color turn;
        private bool finished;

        //Constructor
        public ChessGame () {
        
            //Inicial Settings
            this.board = new Board(8, 8);
            this.shift = 1;
            this.turn = Color.White;
            this.finished = false;

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
        public void MakeMove (Position from, Position to) {

            //Removing piece from original position and placing into a new one
            Piece piece = board.RemovePiece(from);
            piece.IncrementMoves();
            Piece captured = board.RemovePiece(to);
            board.PlacePiece(piece, to);

        }

        private void StartGame() {

            //Placing white pieces
            board.PlacePiece(new Pawn(board, Color.White), new ChessPos('a', 2).ToPosition());
            board.PlacePiece(new Pawn(board, Color.White), new ChessPos('b', 2).ToPosition());
            board.PlacePiece(new Pawn(board, Color.White), new ChessPos('c', 2).ToPosition());
            board.PlacePiece(new Pawn(board, Color.White), new ChessPos('d', 2).ToPosition());
            board.PlacePiece(new Pawn(board, Color.White), new ChessPos('e', 2).ToPosition());
            board.PlacePiece(new Pawn(board, Color.White), new ChessPos('f', 2).ToPosition());
            board.PlacePiece(new Pawn(board, Color.White), new ChessPos('g', 2).ToPosition());
            board.PlacePiece(new Pawn(board, Color.White), new ChessPos('h', 2).ToPosition());
            board.PlacePiece(new Rook(board, Color.White), new ChessPos('a', 1).ToPosition());
            board.PlacePiece(new Knight(board, Color.White), new ChessPos('b', 1).ToPosition());
            board.PlacePiece(new Bishop(board, Color.White), new ChessPos('c', 1).ToPosition());
            board.PlacePiece(new Queen(board, Color.White), new ChessPos('e', 1).ToPosition());
            board.PlacePiece(new King(board, Color.White), new ChessPos('d', 1).ToPosition());
            board.PlacePiece(new Bishop(board, Color.White), new ChessPos('f', 1).ToPosition());
            board.PlacePiece(new Knight(board, Color.White), new ChessPos('g', 1).ToPosition());
            board.PlacePiece(new Rook(board, Color.White), new ChessPos('h', 1).ToPosition());

            //Placing black pieces
            board.PlacePiece(new Pawn(board, Color.Black), new ChessPos('a', 7).ToPosition());
            board.PlacePiece(new Pawn(board, Color.Black), new ChessPos('b', 7).ToPosition());
            board.PlacePiece(new Pawn(board, Color.Black), new ChessPos('c', 7).ToPosition());
            board.PlacePiece(new Pawn(board, Color.Black), new ChessPos('d', 7).ToPosition());
            board.PlacePiece(new Pawn(board, Color.Black), new ChessPos('e', 7).ToPosition());
            board.PlacePiece(new Pawn(board, Color.Black), new ChessPos('f', 7).ToPosition());
            board.PlacePiece(new Pawn(board, Color.Black), new ChessPos('g', 7).ToPosition());
            board.PlacePiece(new Pawn(board, Color.Black), new ChessPos('h', 7).ToPosition());
            board.PlacePiece(new Rook(board, Color.Black), new ChessPos('a', 8).ToPosition());
            board.PlacePiece(new Knight(board, Color.Black), new ChessPos('b', 8).ToPosition());
            board.PlacePiece(new Bishop(board, Color.Black), new ChessPos('c', 8).ToPosition());
            board.PlacePiece(new King(board, Color.Black), new ChessPos('d', 8).ToPosition());
            board.PlacePiece(new Queen(board, Color.Black), new ChessPos('e', 8).ToPosition());
            board.PlacePiece(new Bishop(board, Color.Black), new ChessPos('f', 8).ToPosition());
            board.PlacePiece(new Knight(board, Color.Black), new ChessPos('g', 8).ToPosition());
            board.PlacePiece(new Rook(board, Color.Black), new ChessPos('h', 8).ToPosition());

        }

    }

}
