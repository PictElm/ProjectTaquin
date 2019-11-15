using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Solver;

namespace App
{
    public partial class GameForm5 : AGameForm
    {
        public GameForm5()
        {
            InitializeComponent();

        }

        public Game newGame;
        private List<Button> btnList = new List<Button>();
        private Button btnPressed;

        public override void SetGame(Game game)
        {
            newGame = game;
            Random r = new Random();
            newGame.Shuffle(r, 50);
            RefreshBoard();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GameForm5_Load(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            btnList = new List<Button> { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12, btn13, btn14, btn15, btn16, btn17, btn18, btn19, btn20, btn21, btn22, btn23, btn24, btn25 };
            if (btnPressed == null)
                btnPressed = (Button) sender;
            else
            {
                newGame.MakeMove(getLine(btnPressed), getCol(btnPressed), getLine((Button)sender), getCol((Button)sender));
                btnPressed = null;
            }
            RefreshBoard();
        }

        private int getLine(Button btn)
        {
            int index = btnList.IndexOf(btn);
            return index / 5;
        }

        private int getCol(Button btn)
        {
            int index = btnList.IndexOf(btn);
            return index % 5;
        }

        private void RefreshBoard()
        {
            int m = 0;
            int n = 0;
            for (int i = 0; i < 25; i++)
            {
                if (m > 4)
                {
                    m = 0;
                    n++;
                }
                btnList[i].Text = newGame[n, m].ToString();
                if (btnList[i].Text == "0")
                {
                    btnList[i].BackColor = Color.White;
                    btnList[i].Text = "";
                }
                else
                {
                    btnList[i].BackColor = Color.DarkGray;
                    btnList[i].ForeColor = Color.White;
                }
                m++;
            }
        }
    }
}
