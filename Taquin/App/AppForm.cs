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
    public partial class AppForm : Form
    {
        public AppForm()
        {
            InitializeComponent();
        }

        private GameFormN launchedGame;

        private void btn2_Click(object sender, EventArgs e)
        {
            GameFormN gameForm = new GameFormN(5);
            launchedGame = gameForm;
            gameForm.Show();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            SolverForm solvForm;
            if (launchedGame != null)
                solvForm = new SolverForm(null);
            else
                solvForm = new SolverForm();
            solvForm.Show();
        }
    }
}
