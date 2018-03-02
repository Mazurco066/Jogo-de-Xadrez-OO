using System.Text;

namespace Xadrez_OO.Model {

    class Position {

        //Atributes
        private int line;
        private int column;

        //Constructors
        public Position() {

            this.line = 0;
            this.column = 0;
        }

        public Position(int x, int y) {

            this.line = x;
            this.column = y;
        }

        //Getter/Setter
        public int GetLine() {

            return this.line;
        }

        public void SetLine(int line) {

            this.line = line;
        }

        public int GetColumn() {

            return this.column;
        }

        public void SetColumn(int column) {

            this.column = column;
        }

        //ToString
        public override string ToString() {

            //Building the return string
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Posição: ").Append(this.line);
            stringBuilder.Append(", ").Append(this.column);

            //Returning generated string
            return stringBuilder.ToString();
        }

    }

}
