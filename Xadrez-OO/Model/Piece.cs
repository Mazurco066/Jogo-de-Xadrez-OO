using Xadrez_OO.Util;

namespace Xadrez_OO.Model {

    abstract class Piece {

        //Atributes
        private Position position;
        private Board board;
        private Color color;
        private int moves;

        //Constructor
        public Piece () {

            this.position = null;
            this.board = null;
            this.moves = 0;
        }

        public Piece(Board board, Color color) {

            this.position = null;
            this.board = board;
            this.color = color;
        }

        //Getter/Setter
        public Position GetPosition () {

            return this.position;
        }

        public void SetPosition (Position position) {

            this.position = position;
        }

        public Board GetBoard () {

            return this.board;
        }

        public void SetBoard (Board board) {

            this.board = board;
        }

        public Color GetColor () {

            return this.color;
        }

        public void SetColor (Color color) {

            this.color = color;
        }

        public int GetMoves () {

            return this.moves;
        }

        public void IncrementMoves () {

            this.moves++;
        }

        //Class Methods
        public bool HasPossibleMoves () {

            //Recovering possible moves
            bool[,] moves = Possiblemoves();

            //Verifying the moves
            for (int i = 0; i < GetBoard().GetLines(); i++) {

                for (int j = 0; j < GetBoard().GetColumns(); j++) {

                    //Ok has moves
                    if (moves[i, j]) return true;
                }
            }

            //Returning no possible moves
            return false;

        }

        public abstract bool[,] Possiblemoves ();

        public bool CanMove (Position pos) {

            Piece p = board.GetPiece(pos.GetLine(), pos.GetColumn());

            return p == null || p.GetColor() != this.color;

        }

        public bool CanMoveTo(Position pos) {

            return Possiblemoves()[pos.GetLine(), pos.GetColumn()];
        }

    }

}
