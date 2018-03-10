using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace TicTacToeWPF.opponent
{
    class RandomPlayer : IPlayer
    {
        public System.Random ran = new System.Random();

        public int Move(List<Button> board)
        {
            retry:
            int randomRow = ran.Next(0, 8);


            if (board[randomRow] != null && board[randomRow].IsEnabled && board[randomRow].Content.Equals(""))
            {
                return randomRow;
            }
            else
            {
                goto retry;
            }
        }
    }
}
