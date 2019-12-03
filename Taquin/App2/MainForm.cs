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

        private int size = 3;

        private TaquinGame game = new TaquinGame(3, 1);
        private int[,] initialGame;

        private TaquinGame result = new TaquinGame(3, 1);

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

        private ISolve<TaquinGame.Move> solver;

        private Button[,] buttons;
        private Button[,] buttonsResult;

        public MainForm()
        {
            this.InitializeComponent();

            this.initialGame = CopyGrid(game.Grid);

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

        private void solutionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedNode = (TaquinNode)this.SolverTracker.SelectedItem;
            this.UpdateGridDisplay(selectedNode.Grid);
        }

        private void SolverLaunch_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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
            int newSize = (int) nUDSize.Value;
            int newBlanks = (int) nUDBlanks.Value;
            this.size = newSize;

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
    }
}
