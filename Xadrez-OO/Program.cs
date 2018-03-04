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

                //Console settings
                Console.Title = "C# Chess";

                //Verifying if the game is finished
                while (!game.IsFinished()) {

                    try {

                        //Printing the Chess board
                        Console.Clear();
                        Console.WriteLine();
                        Output.ShowBoard(game.GetBoard());

                        Output.DisplayGameInfo(game);

                        //Reading position
                        Console.Write(" Select a piece to move: ");
                        Position origin = Input.ReadChessPosition().ToPosition();

                        //Validating the position
                        game.ValidateOrigin(origin);

                        //Calculating possible moves
                        bool[,] possibleMoves = game.GetBoard().GetPiece(origin.GetLine(), origin.GetColumn()).Possiblemoves();

                        //Clearing screen for possible moves
                        Console.Clear();
                        Console.WriteLine();
                        Output.ShowBoard(game.GetBoard(), possibleMoves);

                        Console.Write(" Select a field to move: ");
                        Position destiny = Input.ReadChessPosition().ToPosition();

                        //Validating the position
                        game.ValidateDestiny(origin, destiny);

                        //Testing move
                        game.PlayTurn(origin, destiny);

                    }
                    catch (BoardException e) {

                        //Ops... something is wrong
                        Console.WriteLine();
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }

                }

                //Imprimindo resultados da partida
                Console.Clear();
                Console.WriteLine();
                Output.ShowBoard(game.GetBoard());
                Output.DisplayGameInfo(game);    

            }
            catch (BoardException e) {

                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
