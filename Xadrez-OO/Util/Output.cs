using System;
using System.Collections.Generic;
using System.Text;
using Xadrez_OO.Business;
using Xadrez_OO.Model;

namespace Xadrez_OO.Util {

    class Output {

        /* Class for static methods that show data to final user */

        //String Builder for string building
        private static StringBuilder showdown; 

        //Normal Methods
        public static void ShowBoard (Board board) {

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
        public static void ShowBoard (Board board, bool[,] moves) {

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

        //Método para imprimir informações d apartida atual
        public static void DisplayGameInfo (ChessGame game) {

            //Displaying captured pieces
            DisplayCapturedPieces(game);

            //Displaying game info
            Console.WriteLine(" Shift: " + game.GetShift());
            Console.WriteLine(" Waiting for: " + game.GetTurn());
            Console.WriteLine();
            if (game.IsChecked()) {
                Console.WriteLine("CHECK!");
                Console.WriteLine();
            }

        }

        //Método para imprimir peças capturadas
        public static void DisplayCapturedPieces (ChessGame game) {

            Console.WriteLine(" Captures Pieces");
            Console.Write(" White: ");
            DisplayPieces(game.GetCapturedPieces(Color.White));
            Console.WriteLine();
            Console.Write(" Black: ");
            ConsoleColor backup = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            DisplayPieces(game.GetCapturedPieces(Color.Black));
            Console.ForegroundColor = backup;
            Console.WriteLine();
            Console.WriteLine();

        }

        //Método para recuperar peças capturadas do conjunto
        public static void DisplayPieces (HashSet<Piece> pieces) {

            //Abrindo conjunto para impressão
            Console.Write("[");

            //Percorrenco conjunto
            foreach (Piece _piece in pieces) {

                Console.Write(_piece + " ");
            }

            //Fechando conjunto após impresso
            Console.Write("]");

        }

        //Método para imprimir peças com cores determinadas
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
