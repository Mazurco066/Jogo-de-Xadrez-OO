using System.Text;
using Xadrez_OO.Model;

namespace Xadrez_OO.Model {

    class ChessPos {

        //Atributes
        private int line;
        private char column;

        //Constructor
        public ChessPos(char column, int line) {

            this.line = line;
            this.column = column;
        }

        //Getter/Setter
        public int GetLine () {

            return this.line;
        }

        public void SetLine (int line) {

            this.line = line;
        }

        public char GetColumn () {

            return this.column;
        }

        public void SetColumn (char column) {

            this.column = column;
        }

        //Class Methods
        public Position ToPosition () {

            /*
             * Chess logic for coordinates conversion
             * EXAMPLE: a3[5,0] e d8[0,3]
             * 8 - 3 = 5
             * ascII(a) - ascII(a) = 0
             * 8 - 8 = 0
             * ascII(d) - ascII(a) = 3
             */
            return new Position(8 - this.line, this.column - 'a');
        }

        //ToString
        public override string ToString() {

            //Building the return string
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(this.column).Append(this.line);

            //Returning text
            return stringBuilder.ToString();

        }

    }

}
