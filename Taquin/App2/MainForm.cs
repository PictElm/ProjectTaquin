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

namespace App2
{
    public partial class MainForm : Form
    {

        private int size = 3;

        private Game game = new Game(3, 1);

        private Game result = new Game(3, 1);

        private ISolve solver;

        private Button[,] buttons;

        public MainForm()
        {
            this.InitializeComponent();

            this.buttons = new Button[size, size];
            this.InitializeGrid(size);
            this.InitializeResult(size);

            this.Size = new Size(120 * size + 16 + 120, 120 * size + 39);

            this.SetGame(game);
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
                    //button.Click += new EventHandler(this.ButtonClicked);

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

                    this.buttons[i, j] = button;
                    this.ResultTable.Controls.Add(button, j, i);
                }
        }

        public void SetGame(Game game)
        {
            this.game = game;
            this.UpdateGridDisplay(game.ToGrid());
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

        public void SetResult(Game game)
        {
            this.game = game;
            this.UpdateResultDisplay(game.ToGrid());
        }

        private void UpdateResultDisplay(int[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    this.buttons[i, j].Text = grid[i, j] == 0 ? "" : grid[i, j].ToString();
                    this.UpdateButtonTheme(this.buttons[i, j]);
                }
        }

        private void UpdateButtonTheme(Button b)
        {
            if (b.Text.Equals(""))
                b.BackColor = Color.White;
            else
                b.BackColor = Color.LightGray;
        }

        private void solutionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Solution.Step selectedNode = (Solution.Step)this.SolverTracker.SelectedItem;
            this.UpdateGridDisplay(selectedNode.grid);
        }

        private void SolverLaunch_Click(object sender, EventArgs e)
        {

        }
    }
}
