using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TicTacToeWPF
{
    class Context
    {
        private IPlayer player;

        public Context(IPlayer player)
        {
            this.player = player;
        }

        public int getMove(List<Button> board)
        {
            return player.Move(board);
        }
    }
}
