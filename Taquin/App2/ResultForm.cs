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
    public partial class ResultForm : Form
    {
        private MainForm originForm;
        private int size;
        private int[,] Grid;
        private Button[,] Buttons;
        private int currentNumber = 1;

        public ResultForm(MainForm unForm)
        {
            InitializeComponent();
            originForm = unForm;
            size = originForm.size;
            Grid = new int[size, size];
            Buttons = new Button[size, size];
            InitializeResult(size);
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
                    button.Click += new EventHandler(this.ButtonClicked);

                    this.Buttons[i, j] = button;
                    this.ResultTable.Controls.Add(button, j, i);
                }
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.Text = currentNumber.ToString();
            string[] tmpCoords = button.Name.Split(',');
            int i = int.Parse(tmpCoords[0]);
            int j = int.Parse(tmpCoords[1]);
            Grid[i,j] = currentNumber++;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (this.currentNumber - 1 == this.originForm.size * this.originForm.size - this.originForm.nbBlanks)
            {
                originForm.result.Grid = this.Grid;
                this.Close();
            }
        }
    }
}
