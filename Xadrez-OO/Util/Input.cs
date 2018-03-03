using System;
using Xadrez_OO.Business;

namespace Xadrez_OO.Util {

    class Input {

        /* Class for static methods that get data from user */

        //Position input
        public static ChessPos ReadChessPosition () {

            //Reading the position
            string p = Console.ReadLine();
   
            char column = p[0];
            int line = int.Parse(p[1] + "");

            //Returning inputed position
            return new ChessPos(column, line);

        }

    }

}
