using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TicTacToeWPF
{
    public interface IPlayer
    {
        int Move(List<Button> board);
    }
}
