namespace Xadrez_OO.Model {

    class Board {

        //Atributes
        private int lines;
        private int columns;
        private Piece[,] pieces;

        //Constructors
        public Board () {

            this.lines = 8;
            this.lines = 8;
            this.pieces = new Piece[lines, columns];
        }

        public Board (int lines, int columns) {

            if (lines > 0 && columns > 0) {

                this.lines = lines;
                this.columns = columns;
            }
            else {

                this.lines = 8;
                this.columns = 8;
            }
            
            this.pieces = new Piece[lines, columns];
        }

        //Getter/Setter
        public int GetLines () {

            return this.lines;
        }

        public void SetLines (int lines) {

            this.lines = lines;
        }

        public int GetColumns () {

            return this.columns;
        }

        public void SetColumns (int columns) {

            this.columns = columns;
        }

    }

}
