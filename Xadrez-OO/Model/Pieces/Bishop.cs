﻿using Xadrez_OO.Util;

namespace Xadrez_OO.Model.Pieces {

    class Bishop : Piece {

        //Constructors
        public Bishop(Board board, Color color) : base(board, color) { }

        //toString
        public override string ToString() {

            return "B";
        }

    }

}