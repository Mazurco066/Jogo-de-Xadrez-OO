using System;
using System.Text;
using Xadrez_OO.Model;

namespace Xadrez_OO.Util {

    class Output {

        /* Class for static methods that show data to final user */

        //String Builder for string building
        private static StringBuilder showdown; 

        public static void ShowBoard(Board board) {

            //Instancing StringBuilder
            showdown = new StringBuilder();

            //Recovering line and column numbers
            int MaxLines = board.GetLines();
            int MaxColumns = board.GetColumns();
            
            //Verifing board x
            for (int i = 0; i < MaxLines; i ++) {

                //Adding left field indicators
                showdown.Append(MaxLines - i).Append(" ");
                Console.Write(showdown.ToString());
                showdown.Clear();

                //Verifing board y
                for (int j = 0; j < MaxColumns; j++) {

                    //Verifing piece existence
                    if (board.GetPiece(i, j) != null) {

                        //Exists
                        showdown.Append(board.GetPiece(i, j)).Append(" ");
                        ShowPiece(board.GetPiece(i, j));
                    }
                    else {

                        //!Exists
                        showdown.Append("- ");
                        Console.Write(showdown.ToString());
                        showdown.Clear();
                    }

                }

                //Adding one blank line
                showdown.Append("\n");
                Console.Write(showdown.ToString());
                showdown.Clear();

            }

            //Adding the lower field indicators
            showdown.Append("  A B C D E F G H\n\n");

            //Writing the board
            Console.Write(showdown.ToString());

        }

        public static void ShowPiece (Piece piece) {

            //Verifing piece color
            if (piece.GetColor() == Color.White) {

                //Printing the piece signature
                Console.Write(showdown.ToString());
                showdown.Clear();
            }
            else {

                //Backuping the original console text color
                ConsoleColor backup = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;

                //Printing the piece signature
                Console.Write(showdown.ToString());
                showdown.Clear();

                //Restoring the backup color
                Console.ForegroundColor = backup;

            }

        }

    }

}
