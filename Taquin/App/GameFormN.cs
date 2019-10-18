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
    public partial class GameFormN : Form
    {

        private Game game;
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

        public GameFormN(int size)
        {
            this.InitializeComponent();

            this.buttons = new Button[size, size];
            this.InitializeGrid(size);
            
            this.Size = new Size(120 * size + 16, 120 * size + 39);

            this.SetGame(new Game(size, 1));
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
                    button.Click += new EventHandler(this.ButtonClicked);

                    this.buttons[i, j] = button;
                    this.gameTablePanel.Controls.Add(button, j, i);
                }
        }

        public void SetGame(Game game)
        {
            this.game = game;
            int[,] grid = game.ToGrid();

            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    this.buttons[i, j].Text = grid[i, j] == 0 ? "" : grid[i, j].ToString();
                    this.UpdateButtonTheme(this.buttons[i, j]);
                }
        }

        private void UpdateButtonTheme(Button b, bool isSelected=false)
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
                    int[] from = this.GetCoords(this.Selected);
                    int[] to = this.GetCoords(target);

                    if (this.game.MakeMove(from[0], from[1], to[0], to[1]))
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

    }
}
