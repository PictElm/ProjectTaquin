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
    public partial class GameForm : Form
    {
        public Game newGame = new Game(3, 2);
        private List<Button> BtnList = new List<Button>() { };
        private Button btnPressed;
        public GameForm()
        {
            InitializeComponent();
            // Random r = new Random();
            // newGame.Shuffle(r, 50);
            refreshBoard();
        }

        private void refreshBoard()
        {
            BtnList = new List<Button> { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };
            int m = 0;
            int n = 0;
            for (int i = 0; i < 9; i++)
            {
                if (m > 2)
                {
                    m = 0;
                    n++;
                }
                BtnList[i].Text = newGame[n, m].ToString();
                if (BtnList[i].Text == "0")
                {
                    BtnList[i].BackColor = Color.White;
                    BtnList[i].Text = "";
                }
                else
                {
                    BtnList[i].BackColor = Color.DarkGray;
                    BtnList[i].ForeColor = Color.White;
                }
                m++;
            }
        }

        private int getLine(Button btn)
        {
            BtnList = new List<Button> { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };
            int index = BtnList.IndexOf(btn);
            return index / 3;
        }
        
        private int getCol(Button btn)
        {
            BtnList = new List<Button> { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };
            int index = BtnList.IndexOf(btn);
            return index % 3;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (btnPressed == null)
                btnPressed = btn1;
            else
            {
                newGame.MakeMove(getLine(btnPressed), getCol(btnPressed), getLine(btn1), getCol(btn1));
                btnPressed = null;
            }
            refreshBoard();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (btnPressed == null)
                btnPressed = btn2;
            else
            {
                newGame.MakeMove(getLine(btnPressed), getCol(btnPressed), getLine(btn2), getCol(btn2));
                btnPressed = null;
            }
            refreshBoard();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (btnPressed == null)
                btnPressed = btn3;
            else
            {
                newGame.MakeMove(getLine(btnPressed), getCol(btnPressed), getLine(btn3), getCol(btn3));
                btnPressed = null;
            }
            refreshBoard();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (btnPressed == null)
                btnPressed = btn4;
            else
            {
                newGame.MakeMove(getLine(btnPressed), getCol(btnPressed), getLine(btn4), getCol(btn4));
                btnPressed = null;
            }
            refreshBoard();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (btnPressed == null)
                btnPressed = btn5;
            else
            {
                newGame.MakeMove(getLine(btnPressed), getCol(btnPressed), getLine(btn5), getCol(btn5));
                btnPressed = null;
            }
            refreshBoard();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (btnPressed == null)
                btnPressed = btn6;
            else
            {
                newGame.MakeMove(getLine(btnPressed), getCol(btnPressed), getLine(btn6), getCol(btn6));
                btnPressed = null;
            }
            refreshBoard();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (btnPressed == null)
                btnPressed = btn7;
            else
            {
                newGame.MakeMove(getLine(btnPressed), getCol(btnPressed), getLine(btn7), getCol(btn7));
                btnPressed = null;
            }
            refreshBoard();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (btnPressed == null)
                btnPressed = btn8;
            else
            {
                newGame.MakeMove(getLine(btnPressed), getCol(btnPressed), getLine(btn8), getCol(btn8));
                btnPressed = null;
            }
            refreshBoard();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (btnPressed == null)
                btnPressed = btn9;
            else
            {
                newGame.MakeMove(getLine(btnPressed), getCol(btnPressed), getLine(btn9), getCol(btn9));
                btnPressed = null;
            }
            refreshBoard();
        }
    }
}
