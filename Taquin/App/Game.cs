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
        private List<Button> BtnList = new List<Button>() { };
        private Button btnPressed;
        public GameForm()
        {
            InitializeComponent();
            BtnList = new List<Button> { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };
            Game newGame = new Game(3, 2);
            int m = 0;
            int n = 0;
            for (int i = 0; i < 9; i++)
            {
                if (m > 2)
                {
                    m = 0;
                    n++; 
                }
                BtnList[i].Text = newGame[m, n].ToString();
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
                Game.MakeMove(getLine(btnPressed), getCol(btnPressed), getLine(btn1), getCol(btn1));
        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }
    }
}
