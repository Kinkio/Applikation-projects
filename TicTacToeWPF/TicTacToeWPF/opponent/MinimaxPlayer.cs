using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TicTacToeWPF.opponent
{
    class MinimaxPlayer : IPlayer
    {
        Button move = null;
        string player = "";
        List<Button> board = new List<Button>();
        List<Button> tempBoard = new List<Button>();
        int depth = 0;
        int maxDepth = 9;
        double bestScore = 0;
        bool computerWin = false;

        public int Move(List<Button> board)
        {
            this.board = board;
            this.tempBoard = board;
            int bestMove = 0;
            double bestScore = -10;
            double minscore;

            for (int i = 0; i < board.Count; i++)
            {
                if (depth != maxDepth)
                {

                    minscore = Min();
                    if (minscore >= bestScore)
                    {
                        bestMove = i;
                        bestScore = minscore;
                    }
                }

                depth++;

            }

            return bestMove;
        }

        private double Max()
        {
            player = "O";

            if (checkForWin(tempBoard, player))
            {
                return 10;
            }
            else if (depth == maxDepth)
            {
                return 0;
                //return score(tempBoard, player);
            }
            else
            {
                bestScore = -10;

                for (int i = 0; i < 9; i++)
                {
                    tempBoard = board;
                    tempBoard[i].Content = player;
                    double score = Max();

                    if (score > bestScore)
                    {
                        bestScore = score;
                    }
                    board = tempBoard;
                }


                return bestScore;
            }


        }

        public double Min()
        {
            player = "X";

            if (checkForWin(tempBoard, player))
            {
                return -10;
            }
            else if (depth == maxDepth)
            {
                return 0;
                //  return score(tempBoard, player);
            }
            else
            {
                bestScore = 10;
                for (int i = 0; i <= 8; i++)
                {
                    tempBoard = board;
                    tempBoard[i].Content = player;

                    double score = Max();

                    if (score < bestScore)
                    {
                        bestScore = score;
                    }
                    board = tempBoard;

                }

                return bestScore;
            }
        }

        private bool checkForWin(List<Button> tempBoard, string player)
        {
            //Vertical
            if ((tempBoard[0].Content.Equals(player) && tempBoard[1].Content.Equals(player) && tempBoard[2].Content.Equals(player))
                || (tempBoard[3].Content.Equals(player) && tempBoard[4].Content.Equals(player) && tempBoard[5].Content.Equals(player))
                || (tempBoard[6].Content.Equals(player) && tempBoard[7].Content.Equals(player) && tempBoard[8].Content.Equals(player))
                //Horizontal
                || (tempBoard[0].Content.Equals(player) && tempBoard[3].Content.Equals(player) && tempBoard[6].Content.Equals(player))
                || (tempBoard[1].Content.Equals(player) && tempBoard[4].Content.Equals(player) && tempBoard[7].Content.Equals(player))
                || (tempBoard[2].Content.Equals(player) && tempBoard[5].Content.Equals(player) && tempBoard[8].Content.Equals(player))
                //Cross
                || (tempBoard[0].Content.Equals(player) && tempBoard[4].Content.Equals(player) && tempBoard[8].Content.Equals(player))
                || (tempBoard[2].Content.Equals(player) && tempBoard[4].Content.Equals(player) && tempBoard[6].Content.Equals(player)))
            {

                return true;
            }

            return false;
        }

        private bool checkForDraw(List<Button> copyBoard)
        {
            bool check = false;
            int countEmpty = 0;

            foreach (Button item in copyBoard)
            {
                if (item.Content.Equals(""))
                {
                    countEmpty++;
                }

                if (copyBoard.Count == 9 && countEmpty != 0)
                {
                    check = true;
                }


            }

            return check;
        }

    }
}
