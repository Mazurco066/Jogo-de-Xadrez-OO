using System;
using System.Text;
using Xadrez_OO.Model;

namespace Xadrez_OO.Util {

    class Output {

        public static void ShowBoard(Board board) {

            //String Builder for string building
            StringBuilder showdown = new StringBuilder();

            //Recovering line and column numbers
            int MaxLines = board.GetLines();
            int MaxColumns = board.GetColumns();
            
            //Verifing board x
            for (int i = 0; i < MaxLines; i ++) {

                //Verifing board y
                for (int j = 0; j < MaxColumns; j++) {

                    //Verifing piece existence
                    if (board.GetPiece(i, j) != null) {

                        //Exists
                        showdown.Append(board.GetPiece(i, j)).Append(" ");
                    }
                    else {

                        //!Exists
                        showdown.Append("- ");
                    }

                }

                //Adding one blank line
                showdown.Append("\n");

            }

            //Writing the board
            Console.Write(showdown.ToString());

        }

    }

}
