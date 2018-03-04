using System;
using System.Text;
using Xadrez_OO.Model;

namespace Xadrez_OO.Util {

    class Output {

        /* Class for static methods that show data to final user */

        //String Builder for string building
        private static StringBuilder showdown; 

        //Normal Methods
        public static void ShowBoard(Board board) {

            //Instancing StringBuilder
            showdown = new StringBuilder();

            //Recovering line and column numbers
            int MaxLines = board.GetLines();
            int MaxColumns = board.GetColumns();
            
            //Verifing board x
            for (int i = 0; i < MaxLines; i ++) {

                //Adding left field indicators
                showdown.Append(" ").Append(MaxLines - i).Append(" ");
                Console.Write(showdown.ToString());
                showdown.Clear();

                //Verifing board y
                for (int j = 0; j < MaxColumns; j++) {

                    //Printing on the screen
                    showdown.Append(board.GetPiece(i, j));
                    ShowPiece(board.GetPiece(i, j));
                }

                //Adding one blank line
                showdown.Append("\n");
                Console.Write(showdown.ToString());
                showdown.Clear();

            }

            //Adding the lower field indicators
            showdown.Append("   A B C D E F G H\n\n");

            //Writing the board
            Console.Write(showdown.ToString());

        }

        //Overcharged method
        public static void ShowBoard(Board board, bool[,] moves) {

            //Backuping the original console background color
            ConsoleColor backup = Console.BackgroundColor;
            ConsoleColor marked = ConsoleColor.DarkGray;

            //Instancing StringBuilder
            showdown = new StringBuilder();

            //Recovering line and column numbers
            int MaxLines = board.GetLines();
            int MaxColumns = board.GetColumns();

            //Verifing board x
            for (int i = 0; i < MaxLines; i++) {

                //Adding left field indicators
                showdown.Append(" ").Append(MaxLines - i).Append(" ");
                Console.Write(showdown.ToString());
                showdown.Clear();

                //Verifing board y
                for (int j = 0; j < MaxColumns; j++) {

                    //Adding possible moves indicators
                    if (moves[i, j]) {

                        Console.BackgroundColor = marked;
                    }

                    //Printing on the screen
                    showdown.Append(board.GetPiece(i, j));
                    ShowPiece(board.GetPiece(i, j));

                    Console.BackgroundColor = backup;
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

            //Verifying if it has a piece
            if (piece == null) {

                //!Exists
                showdown.Append("- ");
                Console.Write(showdown.ToString());
                showdown.Clear();
            }
            else {

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

                //Adding the layout space
                Console.Write(" ");

            }

        }

    }

}
