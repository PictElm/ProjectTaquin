using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App2
{
    public partial class InitForm : Form
    {
        private MainForm originForm;
        private int size;
        private int[,] Grid;
        private Button[,] Buttons;
        private int currentNumber = 1;
        private Stack<int[,]> PrecedingMoves = new Stack<int[,]>();
        private Stack<int[,]> ForwardMoves = new Stack<int[,]>();

        public InitForm(MainForm unForm)
        {
            InitializeComponent();
            originForm = unForm;
            size = originForm.size;
            Grid = new int[size, size];
            Buttons = new Button[size, size];
            InitializeGrid(size);
            this.UpdateGridDisplay(this.Grid);
        }

        public void InitializeGrid(int size)
        {
            this.InitTable.ColumnCount = size;
            this.InitTable.RowCount = size;

            this.InitTable.ColumnStyles.Clear();
            this.InitTable.RowStyles.Clear();

            float each = 100f / size;
            for (int k = 0; k < size; k++)
            {
                this.InitTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, each));
                this.InitTable.RowStyles.Add(new RowStyle(SizeType.Percent, each));
            }

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    Button button = new Button();
                    button.Name = $"{i},{j}";
                    button.Dock = DockStyle.Fill;
                    button.Click += new EventHandler(this.ButtonClicked);

                    this.Buttons[i, j] = button;
                    this.InitTable.Controls.Add(button, j, i);
                }
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button.Text == "")
            {
                PrecedingMoves.Push(CopyGrid(this.Grid));
                ForwardMoves.Clear();
                button.Text = currentNumber.ToString();
                string[] tmpCoords = button.Name.Split(',');
                int i = int.Parse(tmpCoords[0]);
                int j = int.Parse(tmpCoords[1]);
                Grid[i, j] = currentNumber++;
                this.UpdateGridDisplay(this.Grid);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (this.currentNumber - 1 == this.originForm.size * this.originForm.size - this.originForm.nbBlanks)
            {
                originForm.ChangeInit(this.Grid);
                this.Close();
            }
        }

        private void ResultTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnStepBack_Click(object sender, EventArgs e)
        {
            if (PrecedingMoves.Count != 0)
            {
                ForwardMoves.Push(CopyGrid(this.Grid));
                this.Grid = PrecedingMoves.Pop();
                this.currentNumber--;
                this.UpdateGridDisplay(this.Grid);
            }
        }

        private void btnStepForward_Click(object sender, EventArgs e)
        {
            if (ForwardMoves.Count != 0)
            {
                PrecedingMoves.Push(CopyGrid(this.Grid));
                this.Grid = ForwardMoves.Pop();
                this.currentNumber++;
                this.UpdateGridDisplay(this.Grid);
            }
        }

        private int[,] CopyGrid(int[,] grid)
        {
            int[,] copy = new int[this.size, this.size];
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    copy[i, j] = grid[i, j];
                }
            }
            return copy;
        }

        private void UpdateGridDisplay(int[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    this.Buttons[i, j].Text = grid[i, j] == 0 ? "" : grid[i, j].ToString();
                    this.UpdateButtonTheme(this.Buttons[i, j]);
                }
        }

        private void UpdateButtonTheme(Button b)
        {
            if (b.Text.Equals(""))
                b.BackColor = Color.White;
            else
                b.BackColor = Color.LightGray;
        }
    }
}
