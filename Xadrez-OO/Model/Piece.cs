using Xadrez_OO.Util;

namespace Xadrez_OO.Model {

    class Piece {

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

        public Piece (Position position, Color color) {

            this.position = position;
            this.color = color;
        }

        public Piece(Position position, Board board, Color color) {

            this.position = position;
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

    }

}
