using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez_OO.Model {

    class Position {

        //Atributes
        public int line { get; set; }
        public int column { get; set; }

        //Constructor
        public Position(int x, int y) {

            this.line = x;
            this.column = y;
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
