using System;
using Xadrez_OO.Model;
using Xadrez_OO.Model.Pieces;
using Xadrez_OO.Util;
using Xadrez_OO.Exceptions;

namespace Xadrez_OO {

    class Program {

        //Atributes
        public static Board board;

        static void Main(string[] args) {

            //Instancing board
            board = new Board(8, 8);

            try {

                //Placing pieces
                board.PlacePiece(new Rook(board, Color.Black), new Position(0, 0));
                board.PlacePiece(new Rook(board, Color.Black), new Position(1, 3));
                board.PlacePiece(new King(board, Color.Black), new Position(2, 4));

            }
            catch (BoardException e) {

                Console.WriteLine(e.Message);
            }

            Output.ShowBoard(board);

            Console.ReadLine();
        }
    }
}
