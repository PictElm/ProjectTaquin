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
    public partial class SolverForm : Form
    {
        public SolverForm()
        {
            InitializeComponent();
        }
        
        public List<Button> BtnList;

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedNode = (int[,])lb1.SelectedItem;
            BtnList = new List<Button> { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };
            int m = 0;
            int n = 0;
            for (int i = 0; i < 9; i++)
            {
                if (m > 2)
                {
                    m = 0;
                    n++;
                }
                BtnList[i].Text = selectedNode[n, m].ToString();
                if (BtnList[i].Text == "0")
                {
                    BtnList[i].BackColor = Color.White;
                    BtnList[i].Text = "";
                }
                else
                {
                    BtnList[i].BackColor = Color.DarkGray;
                    BtnList[i].ForeColor = Color.White;
                }
                m++;
            }
        }
    }
}
