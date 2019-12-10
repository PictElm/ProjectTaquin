using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Solver2;
using Solver2.Taquin;
using Solver2.Solve;
using Solver2.Graph;

namespace App2
{
    public partial class MainForm : Form
    {

        public int size = 3;
        public int nbBlanks = 1;

        private TaquinGame game = new TaquinGame(3, 1);
        private int[,] initialGame;

        public TaquinGame result = new TaquinGame(3, 1);

        private readonly Random rng = new Random();

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

        private Stack<int[,]> PrecedingMoves = new Stack<int[,]>();
        private Stack<int[,]> ForwardMoves = new Stack<int[,]>();

        private ISolve<TaquinGame.Move> solver;

        private Button[,] buttons;
        private Button[,] buttonsResult;

        public MainForm()
        {
            this.InitializeComponent();

            this.initialGame = CopyGrid(game.Grid);
            PrecedingMoves.Push(initialGame);

            this.buttons = new Button[size, size];
            this.buttonsResult = new Button[size, size];
            this.InitializeGrid(size);
            this.InitializeResult(size);

            this.Size = new Size(240 * size + 32 + 240, 200 * size + 78);

            this.SetGame(game);
            this.SetResult(game);
        }

        public void InitializeGrid(int size)
        {
            this.TaquinTable.ColumnCount = size;
            this.TaquinTable.RowCount = size;

            this.TaquinTable.ColumnStyles.Clear();
            this.TaquinTable.RowStyles.Clear();

            float each = 100f / size;
            for (int k = 0; k < size; k++)
            {
                this.TaquinTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, each));
                this.TaquinTable.RowStyles.Add(new RowStyle(SizeType.Percent, each));
            }

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    Button button = new Button();
                    button.Name = $"{i},{j}";
                    button.Dock = DockStyle.Fill;
                    button.Click += new EventHandler(this.ButtonClicked);

                    this.buttons[i, j] = button;
                    this.TaquinTable.Controls.Add(button, j, i);
                }
        }

        public void InitializeResult(int size)
        {
            this.ResultTable.ColumnCount = size;
            this.ResultTable.RowCount = size;

            this.ResultTable.ColumnStyles.Clear();
            this.ResultTable.RowStyles.Clear();

            float each = 100f / size;
            for (int k = 0; k < size; k++)
            {
                this.ResultTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, each));
                this.ResultTable.RowStyles.Add(new RowStyle(SizeType.Percent, each));
            }

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    Button button = new Button();
                    button.Name = $"{i},{j}";
                    button.Dock = DockStyle.Fill;
                    //button.Click += new EventHandler(this.ButtonClicked);

                    this.buttonsResult[i, j] = button;
                    this.ResultTable.Controls.Add(button, j, i);
                }
        }

        public void SetGame(TaquinGame game)
        {
            this.game = game;
            this.UpdateGridDisplay(game.Grid);
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

        public void SetResult(TaquinGame game)
        {
            this.UpdateResultDisplay(game.Grid);
        }

        private void UpdateResultDisplay(int[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    this.buttonsResult[i, j].Text = grid[i, j] == 0 ? "" : grid[i, j].ToString();
                    this.UpdateButtonTheme(this.buttonsResult[i, j]);
                }
        }

        private void UpdateButtonTheme(Button b)
        {
            if (b.Text.Equals(""))
                b.BackColor = Color.White;
            else
                b.BackColor = Color.LightGray;
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
                    PrecedingMoves.Push(CopyGrid(this.game.Grid));
                    ForwardMoves.Clear();
                    int[] from = this.GetCoords(this.Selected);
                    int[] to = this.GetCoords(target);

                    if (this.game.MakeMove(new TaquinGame.Move(from[0], from[1], to[0], to[1])))
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

        private void SizeButton_Click(object sender, EventArgs e)
        {
            this.SolverTracker.DataSource = null;

            int newSize = (int) nUDSize.Value;
            int newBlanks = (int) nUDBlanks.Value;
            this.size = newSize;
            this.nbBlanks = newBlanks;

            this.TaquinTable.Controls.Clear();
            this.ResultTable.Controls.Clear();

            this.buttons = new Button[size, size];
            this.buttonsResult = new Button[size, size];
            this.game = new TaquinGame(newSize, newBlanks);
            this.result = new TaquinGame(newSize, newBlanks);

            this.initialGame = CopyGrid(game.Grid);

            InitializeGrid(size);
            InitializeResult(size);
            this.SetGame(game);
            this.SetResult(game);
            PrecedingMoves.Clear();
            ForwardMoves.Clear();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            this.game.Grid = initialGame;
            UpdateGridDisplay(game.Grid);
        }

        private int[,] CopyGrid(int[,] grid)
        {
            int[,] copy = new int[this.size, this.size];
            for (int i = 0; i < this.size ; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    copy[i, j] = grid[i, j];
                }
            }
            return copy;
        }

        public bool InputEnabled
        {
            get { return this.ResetButton.Enabled; }
            set
            {
                if (value != this.ResetButton.Enabled)
                {
                    for (int i = 0; i < this.game.Size; i++)
                        for (int j = 0; j < this.game.Size; j++)
                            this.buttons[i, j].Enabled = value;

                    this.ShuffleButton.Enabled = value;
                    this.ResetButton.Enabled = value;
                    this.SizeButton.Enabled = value;

                    this.UseWaitCursor = !value;

                    this.SolverLaunch.Text = value ? "Lancer le Solveur" : "Arrêter le Solveur";
                }
            }
        }

        private void SolverLaunch_Click(object sender, EventArgs e)
        {
            if (this.InputEnabled)
            {
                this.InputEnabled = false;

                this.backgroundSolver.RunWorkerAsync();
                System.Diagnostics.Debug.WriteLine("Started background solving");
            }
            else
            {
                this.InputEnabled = true;

                this.backgroundSolver.CancelAsync();
                System.Diagnostics.Debug.WriteLine("Stopped background solving");
            }
        }

        private void ButtonShuffle_Click(object sender, EventArgs e)
        {
            this.game.Shuffle(this.rng, 10);
            this.UpdateGridDisplay(this.game.Grid);
        }

        private void backgroundSolver_DoWork(object sender, DoWorkEventArgs e)
        {
            this.solver = new TaquinSolveSteps();
            var solution = this.solver.Solve(this.game, this.result.State);
            e.Result = solution;
        }

        private void backgroundSolver_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var solution = e.Result as Solution<TaquinGame.Move>;
            System.Diagnostics.Debug.WriteLine($"Finished background solving, solution is {solution.Steps.Count} steps after exploring {solution.ExploredStates} game states");
            this.SolverTracker.DataSource = solution.Steps;

            this.InputEnabled = true;
        }

        private void SolverTracker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedNode = this.SolverTracker.SelectedItem as TaquinNode;
            if (selectedNode != null)
            {
                this.game.State = selectedNode;
                this.UpdateGridDisplay(this.game.Grid);
            }
        }

        private void btnStepBack_Click(object sender, EventArgs e)
        {
            if (PrecedingMoves.Count != 0)
            {
                ForwardMoves.Push(CopyGrid(this.game.Grid));
                this.game.Grid = PrecedingMoves.Pop();
                this.UpdateGridDisplay(this.game.Grid);
            }
        }

        private void btnStepForward_Click(object sender, EventArgs e)
        {
            if (ForwardMoves.Count != 0)
            {
                PrecedingMoves.Push(CopyGrid(this.game.Grid));
                this.game.Grid = ForwardMoves.Pop();
                this.UpdateGridDisplay(this.game.Grid);
            }
        }

        private void btnChangeResult_Click(object sender, EventArgs e)
        {
            if (this.backgroundSolver.IsBusy)
                this.backgroundSolver.CancelAsync();

            ResultForm newResultForm = new ResultForm(this);
            newResultForm.ShowDialog();
        }

        public void ChangeResult(int[,] grid)
        {
            this.result.Grid = grid;
            this.SolverTracker.DataSource = null;
            this.UpdateResultDisplay(this.result.Grid);
        }

        private void btnChangeInit_Click(object sender, EventArgs e)
        {
            if (this.backgroundSolver.IsBusy)
                this.backgroundSolver.CancelAsync();

            InitForm newResultForm = new InitForm(this);
            newResultForm.ShowDialog();
        }

        public void ChangeInit(int[,] grid)
        {
            this.game.Grid = grid;
            this.SolverTracker.DataSource = null;
            this.UpdateGridDisplay(this.game.Grid);
        }
    }
}
