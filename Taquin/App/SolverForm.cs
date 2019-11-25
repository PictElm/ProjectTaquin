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
            btnList = new List<Button> { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };
            foreach (Button button in btnList)
            {
                button.Text = "0";
                button.BackColor = Color.White;
                button.ForeColor = Color.White;
                currentBtnNb = 1;
            }

        }
        
        public List<Button> btnList;
        public Solution.Step selectedNode;
        public int currentBtnNb = 1;
        public Game importedGame;

        public SolverForm(Game game)
        {
            importedGame = game;
            InitializeComponent();
            btnList = new List<Button> { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };
            int m = 0;
            int n = 0;
            for (int i = 0; i < 9; i++)
            {
                if (m > 2)
                {
                    m = 0;
                    n++;
                }
                btnList[i].Text = importedGame.ToGrid()[n, m].ToString();
                if (btnList[i].Text == "0")
                {
                    btnList[i].BackColor = Color.White;
                    btnList[i].ForeColor = Color.White;
                    btnList[i].Text = "0";
                }
                else
                {
                    btnList[i].BackColor = Color.DarkGray;
                    btnList[i].ForeColor = Color.White;
                }
                m++;
            }
        }

        private ISolve solver;

        private void UpdateGridDisplay(int[,] grid)
        {
            int m = 0;
            int n = 0;
            for (int i = 0; i < 9; i++)
            {
                if (m > 2)
                {
                    m = 0;
                    n++;
                }
                btnList[i].Text = grid[n, m].ToString();
                if (btnList[i].Text == "0")
                {
                    btnList[i].BackColor = Color.White;
                    btnList[i].ForeColor = Color.White;
                    btnList[i].Text = "0";
                }
                else
                {
                    btnList[i].BackColor = Color.DarkGray;
                    btnList[i].ForeColor = Color.White;
                }
                m++;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedNode = (Solution.Step) lb1.SelectedItem;
            this.UpdateGridDisplay(selectedNode.grid);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.solvingBackgroundWorker.RunWorkerAsync();
            System.Diagnostics.Debug.WriteLine("Started background solving");
        }

        private void SolverForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.solvingBackgroundWorker.IsBusy)
            {
                this.solvingBackgroundWorker.CancelAsync();
                System.Diagnostics.Debug.WriteLine("Canceled background solving");
            }
        }

        private void solvingBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.UpdateGridDisplay(e.UserState as int[,]);
        }

        private void solvingBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Finished background solving");
            lb1.DataSource = (e.Result as Solution).Steps;
        }

        private void solvingBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int[,] currentGrid = { { int.Parse(btn1.Text), int.Parse(btn2.Text), int.Parse(btn3.Text) }, 
                { int.Parse(btn4.Text), int.Parse(btn5.Text), int.Parse(btn6.Text) }, 
                { int.Parse(btn7.Text), int.Parse(btn8.Text), int.Parse(btn9.Text) } };

            int gapCount = CountGaps(currentGrid);
            Game newGame = new Game(3, gapCount);

            newGame.LoadGrid(currentGrid); // état initial
            int[,] finalGrid = getFinalGrid(3, gapCount); // état final

            solver = new SolveAEtoile();
            Solution solution = solver.Solve(newGame, finalGrid, state => this.solvingBackgroundWorker.ReportProgress(0, state));
            e.Result = solution;
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
            btnList = new List<Button> { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };
            foreach (Button button in btnList)
            {
                button.Text = "0";
                button.BackColor = Color.White;
                button.ForeColor = Color.White;
                currentBtnNb = 1;
            }
        }

        private int CountGaps(int[,] grid)
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
