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
    public partial class SolverForm : Form
    {
        public SolverForm()
        {
            InitializeComponent();
            BtnList = new List<Button> { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };
            foreach (Button button in BtnList)
            {
                button.Text = "0";
                button.BackColor = Color.White;
                button.ForeColor = Color.White;
                currentBtnNb = 1;
            }

        }
        
        public List<Button> BtnList;
        public Solution.Step selectedNode;
        public int currentBtnNb = 1;
        public Game importedGame;

        public SolverForm(Game game)
        {
            importedGame = game;
            InitializeComponent();
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
                BtnList[i].Text = importedGame.ToGrid()[n, m].ToString();
                if (BtnList[i].Text == "0")
                {
                    BtnList[i].BackColor = Color.White;
                    BtnList[i].ForeColor = Color.White;
                    BtnList[i].Text = "0";
                }
                else
                {
                    BtnList[i].BackColor = Color.DarkGray;
                    BtnList[i].ForeColor = Color.White;
                }
                m++;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedNode = (Solution.Step) lb1.SelectedItem;
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
                BtnList[i].Text = selectedNode.grid[n, m].ToString();
                if (BtnList[i].Text == "0")
                {
                    BtnList[i].BackColor = Color.White;
                    BtnList[i].ForeColor = Color.White;
                    BtnList[i].Text = "0";
                }
                else
                {
                    BtnList[i].BackColor = Color.DarkGray;
                    BtnList[i].ForeColor = Color.White;
                }
                m++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[,] currentGrid = { { int.Parse(btn1.Text), int.Parse(btn2.Text), int.Parse(btn3.Text) }, 
                { int.Parse(btn4.Text), int.Parse(btn5.Text), int.Parse(btn6.Text) }, 
                { int.Parse(btn7.Text), int.Parse(btn8.Text), int.Parse(btn9.Text) } };

            Game newGame = new Game(3, countGaps(currentGrid));
            Solve3 solver = new Solve3();
            Solution solution = solver.Solve(newGame, getFinalGrid(3, countGaps(currentGrid)));
            lb1.DataSource = solution.Steps;

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (btn1.Text == "" || btn1.Text == "0")
            {
                btn1.Text = currentBtnNb.ToString();
                btn1.BackColor = Color.DarkGray;
                btn1.ForeColor = Color.White;
                currentBtnNb++;
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (btn2.Text == "" || btn2.Text == "0")
            {
                btn2.Text = currentBtnNb.ToString();
                btn2.BackColor = Color.DarkGray;
                btn2.ForeColor = Color.White;
                currentBtnNb++;
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (btn3.Text == "" || btn3.Text == "0")
            {
                btn3.Text = currentBtnNb.ToString();
                btn3.BackColor = Color.DarkGray;
                btn3.ForeColor = Color.White;
                currentBtnNb++;
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (btn4.Text == "" || btn4.Text == "0")
            {
                btn4.Text = currentBtnNb.ToString();
                btn4.BackColor = Color.DarkGray;
                btn4.ForeColor = Color.White;
                currentBtnNb++;
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (btn5.Text == "" || btn5.Text == "0")
            {
                btn5.Text = currentBtnNb.ToString();
                btn5.BackColor = Color.DarkGray;
                btn5.ForeColor = Color.White;
                currentBtnNb++;
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (btn6.Text == "" || btn6.Text == "0")
            {
                btn6.Text = currentBtnNb.ToString();
                btn6.BackColor = Color.DarkGray;
                btn6.ForeColor = Color.White;
                currentBtnNb++;
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (btn7.Text == "" || btn7.Text == "0")
            {
                btn7.Text = currentBtnNb.ToString();
                btn7.BackColor = Color.DarkGray;
                btn7.ForeColor = Color.White;
                currentBtnNb++;
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (btn8.Text == "" || btn8.Text == "0")
            {
                btn8.Text = currentBtnNb.ToString();
                btn8.BackColor = Color.DarkGray;
                btn8.ForeColor = Color.White;
                currentBtnNb++;
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (btn9.Text == "" || btn9.Text == "0")
            {
                btn9.Text = currentBtnNb.ToString();
                btn9.BackColor = Color.DarkGray;
                btn9.ForeColor = Color.White;
                currentBtnNb++;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            BtnList = new List<Button> { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };
            foreach (Button button in BtnList)
            {
                button.Text = "0";
                button.BackColor = Color.White;
                button.ForeColor = Color.White;
                currentBtnNb = 1;
            }
        }

        private int countGaps(int[,] grid)
        {
            int nbGaps = 0;
            foreach (int elem in grid)
            {
                if (elem == 0)
                {
                    nbGaps++;
                }
            }
            return nbGaps;
        }

        private int[,] getFinalGrid(int size, int gaps)
        {
            int[,] template = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            int numbers = (int)Math.Pow(size, 2) - gaps;
            int row = 0;
            int col = 0;
            for (int i = 0; i < numbers; i++)
            {
                template[row, col] = i + 1;
                col++;
                if (col > 2)
                {
                    row++;
                    col = 0;
                }
            }
            return template;
        }
    }
}
