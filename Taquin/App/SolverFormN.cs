using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class SolverFormN : Form
    {

        private Solver2.Taquin.TaquinGame game;
        private Solver2.Solve.ISolve<Solver2.Taquin.TaquinGame.Move> solver;

        private readonly Random rng;

        private Button[,] buttons;
        private Button _selected;
        private Button Selected
        {
            get { return this._selected; }
            set
            {
                if (this._selected != null)
                    this.UpdateButtonTheme(this._selected, false);

                this._selected = value;

                if (this._selected != null)
                    this.UpdateButtonTheme(this._selected, true);
            }
        }


        public SolverFormN(int size, int gaps)
        {
            this.game = new Solver2.Taquin.TaquinGame(size, gaps);
            this.rng = new Random();

            this.InitializeComponent();

            this.buttons = new Button[this.game.Size, this.game.Size];
            this.InitializeGrid(this.game.Size);

            this.Size = new Size(120 * this.game.Size + 16 + 120, 120 * this.game.Size + 39);
            
            this.SetGame(this.game);
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
                    Button button = new Button
                    {
                        Name = $"{i},{j}",
                        Dock = DockStyle.Fill
                    };
                    button.Click += new EventHandler(this.ButtonClicked);

                    this.buttons[i, j] = button;
                    this.gameTablePanel.Controls.Add(button, j, i);
                }
        }

        public void SetGame(Solver2.Taquin.TaquinGame game)
        {
            this.game = game;
            this.UpdateGridDisplay(game.Grid);
        }

        private void UpdateButtonTheme(Button b, bool isSelected = false)
        {
            if (isSelected)
                b.BackColor = Color.Gray;
            else
            {
                if (b.Text.Equals(""))
                    b.BackColor = Color.White;
                else
                    b.BackColor = Color.LightGray;
            }
        }

        public bool InputEnabled
        {
            set
            {
                if (value != this.solveButton.Enabled)
                {
                    for (int i = 0; i < this.game.Size; i++)
                        for (int j = 0; j < this.game.Size; j++)
                            this.buttons[i, j].Enabled = value;

                    this.solveButton.Enabled = value;
                    this.shuffleButton.Enabled = value;

                    this.UseWaitCursor = !value;
                }
            }
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

        private int[] GetCoords(Button b)
        {
            String[] tmp = b.Name.Split(',');
            return new int[2] { int.Parse(tmp[0]), int.Parse(tmp[1]) };
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            Button target = sender as Button;

            if (target.Text.Equals(""))
            {
                if (this.Selected != null)
                {
                    int[] from = this.GetCoords(this.Selected);
                    int[] to = this.GetCoords(target);
                    
                    if (this.game.MakeMove(new Solver2.Taquin.TaquinGame.Move(from[0], from[1], to[0], to[1])))
                    {
                        target.Text = this.Selected.Text;
                        this.Selected.Text = "";
                        this.UpdateButtonTheme(target);
                    }

                    this.Selected = null;
                }
            }
            else
            {
                this.Selected = target == this.Selected ? null : target;
            }
        }

        private void shuffleButton_Click(object sender, EventArgs e)
        {
            this.game.Shuffle(this.rng, 100);
            this.UpdateGridDisplay(this.game.Grid);
            this.solutionListBox.DataSource = null;
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            this.InputEnabled = false;

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

        private void solvingBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var solution = e.Result as Solver2.Solve.Solution<Solver2.Taquin.TaquinGame.Move>;
            System.Diagnostics.Debug.WriteLine($"Finished background solving, solution is {solution.Steps.Count} steps after exploring {solution.ExploredStates} game states");
            this.solutionListBox.DataSource = solution.Steps;

            this.InputEnabled = true;
        }

        private void solvingBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int[,] finalGrid = Solver2.Taquin.TaquinGame.SortedGrid(this.game.Size, this.game.Gaps);

            this.solver = new Solver2.Taquin.TaquinSolveSteps(); //new Solver2.Solve.Method.SolveAstar<Solver2.Taquin.TaquinGame.Move>();
            var solution = solver.Solve(this.game, new Solver2.Taquin.TaquinNode(finalGrid));
            e.Result = solution;
        }

        private void solutionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedNode = (Solver2.Taquin.TaquinNode)this.solutionListBox.SelectedItem;
            if (selectedNode != null)
            {
                this.game.State = selectedNode;
                this.UpdateGridDisplay(this.game.Grid);
            }
        }

        private void gameTablePanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
