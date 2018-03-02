using System;
using Xadrez_OO.Model;
using Xadrez_OO.Util;

namespace Xadrez_OO {

    class Program {

        static void Main(string[] args) {

            Board board = new Board(8, 8);
            Output.ShowBoard(board);

            Console.ReadLine();
        }
    }
}
