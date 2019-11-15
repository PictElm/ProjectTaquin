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
    public partial class AppForm : Form
    {
        public AppForm()
        {
            InitializeComponent();
        }

        private AGameForm launchedGame;
        public Game newGame;  // = new Game(3, 2);
        private int sizeChoice = 3;

        private void btn2_Click(object sender, EventArgs e)
        {
            if (sizeChoice == 3)
                launchedGame = new GameForm();
            else if (sizeChoice == 5)
                launchedGame = new GameForm5();
            newGame = new Game(sizeChoice, 2);
            launchedGame.SetGame(newGame);
            launchedGame.Show();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            SolverForm solvForm;
            if (launchedGame != null)
                solvForm = new SolverForm(newGame);
            else
                solvForm = new SolverForm();
            solvForm.Show();
        }

        private void btnSize3_Click(object sender, EventArgs e)
        {
            sizeChoice = 3;
            btnSize3.BackColor = Color.DarkGray;
            btnSize3.ForeColor = Color.White;

            btnSize5.BackColor = Color.LightGray;
            btnSize5.ForeColor = Color.Black;
        }

        private void btnSize5_Click(object sender, EventArgs e)
        {
            sizeChoice = 5;
            btnSize5.BackColor = Color.DarkGray;
            btnSize5.ForeColor = Color.White;

            btnSize3.BackColor = Color.LightGray;
            btnSize3.ForeColor = Color.Black;
        }
    }
}
