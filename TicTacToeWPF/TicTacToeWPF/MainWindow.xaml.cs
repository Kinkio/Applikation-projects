using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;

namespace TicTacToeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool turn = true;
        private int x, o;
        private bool endedgame = false;

        public List<Button> board = new List<Button>();
        Context context;

        public MainWindow()
        {
            InitializeComponent();
            createButtons();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            turn = true;

        }

        private void newBtn_Click(object sender, RoutedEventArgs e)
        {

            Button btn = sender as Button;


            if (turn)
            {
                btn.Content = "X";
                Label0.Content = "O";
                turn = false;
            }
            else
            {
                btn.Content = "O";
                Label0.Content = "X";
                turn = true;
            }

            btn.IsEnabled = false;
            CheckWin(btn.Content.ToString());
            btn = null;


            if (!turn && !endedgame)
            {
                int getmove = getOpponent();

                btn = board[getmove];
                try
                {
                    MyExt.PerformClick(btn);
                }
                catch (Exception)
                {
                }



            }


        }

        //New game
        private void mnuNew_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button btn in btnContainerMain.Children)
            {
                btn.Content = "";
                turn = true;
                btn.IsEnabled = true;
                endedgame = false;
            }
            getOpponent();
        }

        //Quit app
        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //Create board of buttons
        private void createButtons()
        {
            for (int i = 1; i <= 9; i++)
            {
                System.Windows.Controls.Button newBtn = new Button();

                newBtn.Content = "";
                newBtn.Width = 50;
                newBtn.Height = 50;
                newBtn.Name = "Button" + i.ToString();
                newBtn.Click += new RoutedEventHandler(newBtn_Click);
                btnContainerMain.Children.Add(newBtn);
                board.Add(newBtn);
            }
        }

        //Win check
        private void CheckWin(string player)
        {

            //Vertical
            if ((board[0].Content.Equals(player) && board[1].Content.Equals(player) && board[2].Content.Equals(player))
                || (board[3].Content.Equals(player) && board[4].Content.Equals(player) && board[5].Content.Equals(player))
                || (board[6].Content.Equals(player) && board[7].Content.Equals(player) && board[8].Content.Equals(player))
                //Horizontal
                || (board[0].Content.Equals(player) && board[3].Content.Equals(player) && board[6].Content.Equals(player))
                || (board[1].Content.Equals(player) && board[4].Content.Equals(player) && board[7].Content.Equals(player))
                || (board[2].Content.Equals(player) && board[5].Content.Equals(player) && board[8].Content.Equals(player))
                //Cross
                || (board[0].Content.Equals(player) && board[4].Content.Equals(player) && board[8].Content.Equals(player))
                || (board[2].Content.Equals(player) && board[4].Content.Equals(player) && board[6].Content.Equals(player)))
            {
                if (player == "X")
                {
                    Label2.Content = ++x;
                }
                else
                {
                    Label1.Content = ++o;
                }
                MessageBox.Show("Player " + player + " Wins");

                endedgame = true;
            }
            else
            {
                foreach (Button btn in btnContainerMain.Children)
                {
                    if (btn.IsEnabled == true)
                        return;
                }
                MessageBox.Show("DRAW!!");
            }
            disablebuttons();
        }

        private void disablebuttons()
        {
            foreach (Button btn in btnContainerMain.Children)
            {
                btn.IsEnabled = false;
            }
        }

        private int getOpponent()
        {
            int moveMade = 0;

            var opponent = CBopponent.SelectionBoxItem.ToString();
            if (opponent.Equals("User"))
            {

            }
            else if (opponent.Equals("Random"))
            {
                context = new Context(new opponent.RandomPlayer());
                moveMade = context.getMove(board);
            }
            else if (opponent.Equals("Minimax"))
            {
                context = new Context(new opponent.MinimaxPlayer());
                moveMade = context.getMove(board);
            }

            return moveMade;
        }


    }
}
