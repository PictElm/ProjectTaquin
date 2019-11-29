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

        private int size;
        private int gaps;

        private Game _game;
        public Game Game
        {
            get
            {
                if (this._game == null)
                {
                    this.size = (int)this.gameSizeNum.Value;
                    this.gaps = (int)this.gapCountNum.Value;
                    this._game = new Game(this.size, this.gaps);
                }
                return this._game;
            }
        }

        public AppForm()
        {
            this.InitializeComponent();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            this.Game.Shuffle(new Random(), (int)this.shuffleMovesNum.Value);

            GameFormN launchedGame = new GameFormN(this.Game);
            launchedGame.Show();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            this.Game.Shuffle(new Random(), (int)this.shuffleMovesNum.Value);

            SolverFormN solvForm = new SolverFormN();
            solvForm.Show();
        }

    }
}
