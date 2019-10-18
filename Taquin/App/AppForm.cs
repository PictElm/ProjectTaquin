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

        private Game game;
        private int size;

        private GameFormN launchedGame;

        public AppForm()
        {
            this.InitializeComponent();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (this.size == 0)
                this.size = (int)this.gameSizeNum.Value;

            this.game = new Game(this.size, 6);
            this.launchedGame = new GameFormN(this.size);

            this.launchedGame.SetGame(this.game);
            this.launchedGame.Show();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (this.size == 0)
                this.size = (int)this.gameSizeNum.Value;

            SolverFormN solvForm;
            if (this.game != null)
                solvForm = new SolverFormN(this.size, this.game);
            else
                solvForm = new SolverFormN(this.size);
            solvForm.Show();
        }

    }
}
