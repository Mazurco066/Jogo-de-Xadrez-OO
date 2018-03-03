using System;
using Xadrez_OO.Business;
using Xadrez_OO.Util;
using Xadrez_OO.Model;
using Xadrez_OO.Exceptions;

namespace Xadrez_OO {

    class Program {

        static void Main(string[] args) {

            try {

                //Starting a new game
                ChessGame game = new ChessGame();

                //Verifying if the game is finished
                while (!game.IsFinished()) {

                    //Printing the Chess board
                    Console.Clear();
                    Output.ShowBoard(game.GetBoard());

                    //Reading position
                    Console.Write("Select a piece to move: ");
                    Position origin = Input.ReadChessPosition().ToPosition();
                    Console.Write("Select a field to move: ");
                    Position destiny = Input.ReadChessPosition().ToPosition();

                    //Testing move
                    game.MakeMove(origin, destiny);

                }

            }
            catch (BoardException e) {

                Console.WriteLine(e.Message);
            }

            

            Console.ReadLine();
        }
    }
}
