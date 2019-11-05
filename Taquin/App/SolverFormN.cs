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
    public partial class SolverFormN : Form
    {

        private Game game;

        private ISolve solver;

        private Button[,] buttons;

        public SolverFormN(Game game)
        {
            int size = game.GetSize();

            this.InitializeComponent();

            this.buttons = new Button[size, size];
            this.InitializeGrid(size);

            this.Size = new Size(120 * size + 16 + 120, 120 * size + 39);
            
            this.SetGame(game);
        }

        public void InitializeGrid(int size)
        {
            this.gameTablePanel.ColumnCount = size;
            this.gameTablePanel.RowCount = size;

            this.gameTablePanel.ColumnStyles.Clear();
            this.gameTablePanel.RowStyles.Clear();

            float each = 100f / size;
            for (int k = 0; k < size; k++)
            {
                this.gameTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, each));
                this.gameTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, each));
            }

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    Button button = new Button();
                    button.Name = $"{i},{j}";
                    button.Dock = DockStyle.Fill;
                    //button.Click += new EventHandler(this.ButtonClicked);

                    this.buttons[i, j] = button;
                    this.gameTablePanel.Controls.Add(button, j, i);
                }
        }

        public void SetGame(Game game)
        {
            this.game = game;
            this.UpdateGridDisplay(game.ToGrid());
        }

        private void UpdateButtonTheme(Button b)
        {
            if (b.Text.Equals(""))
                b.BackColor = Color.White;
            else
                b.BackColor = Color.LightGray;
        }

        private void UpdateGridDisplay(int[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    this.buttons[i, j].Text = grid[i, j] == 0 ? "" : grid[i, j].ToString();
                    this.UpdateButtonTheme(this.buttons[i, j]);
                }
        }

        private void solveButton_Click(object sender, EventArgs e)
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
            this.solutionListBox.DataSource = (e.Result as Solution).Steps;
        }

        private void solvingBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int[,] finalGrid = new Game(this.game.GetSize(), this.game.CountGaps()).ToGrid();

            this.solver = new SolveAEtoile();
            Solution solution = solver.Solve(this.game, finalGrid, state => this.solvingBackgroundWorker.ReportProgress(0, state));
            e.Result = solution;
        }

        private void solutionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Solution.Step selectedNode = (Solution.Step)this.solutionListBox.SelectedItem;
            this.UpdateGridDisplay(selectedNode.grid);
        }

    }
}
