namespace App
{
    partial class SolverFormN
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.solvingBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.solverSidePanel = new System.Windows.Forms.TableLayoutPanel();
            this.solutionListBox = new System.Windows.Forms.ListBox();
            this.solveButton = new System.Windows.Forms.Button();
            this.gameTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.shuffleButton = new System.Windows.Forms.Button();
            this.solverSidePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // solvingBackgroundWorker
            // 
            this.solvingBackgroundWorker.WorkerSupportsCancellation = true;
            this.solvingBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.solvingBackgroundWorker_DoWork);
            this.solvingBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.solvingBackgroundWorker_RunWorkerCompleted);
            // 
            // solverSidePanel
            // 
            this.solverSidePanel.ColumnCount = 1;
            this.solverSidePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.solverSidePanel.Controls.Add(this.solutionListBox, 0, 0);
            this.solverSidePanel.Controls.Add(this.solveButton, 0, 1);
            this.solverSidePanel.Controls.Add(this.shuffleButton, 0, 2);
            this.solverSidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.solverSidePanel.Location = new System.Drawing.Point(0, 0);
            this.solverSidePanel.Name = "solverSidePanel";
            this.solverSidePanel.RowCount = 3;
            this.solverSidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.solverSidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.solverSidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.solverSidePanel.Size = new System.Drawing.Size(120, 261);
            this.solverSidePanel.TabIndex = 0;
            // 
            // solutionListBox
            // 
            this.solutionListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.solutionListBox.FormattingEnabled = true;
            this.solutionListBox.Location = new System.Drawing.Point(3, 3);
            this.solutionListBox.Name = "solutionListBox";
            this.solutionListBox.Size = new System.Drawing.Size(114, 175);
            this.solutionListBox.TabIndex = 0;
            this.solutionListBox.SelectedIndexChanged += new System.EventHandler(this.solutionListBox_SelectedIndexChanged);
            // 
            // solveButton
            // 
            this.solveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.solveButton.Location = new System.Drawing.Point(3, 184);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(114, 34);
            this.solveButton.TabIndex = 1;
            this.solveButton.Text = "Résoudre";
            this.solveButton.UseVisualStyleBackColor = true;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // gameTablePanel
            // 
            this.gameTablePanel.ColumnCount = 1;
            this.gameTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.gameTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.gameTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameTablePanel.Location = new System.Drawing.Point(120, 0);
            this.gameTablePanel.Name = "gameTablePanel";
            this.gameTablePanel.RowCount = 1;
            this.gameTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.gameTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 261F));
            this.gameTablePanel.Size = new System.Drawing.Size(164, 261);
            this.gameTablePanel.TabIndex = 1;
            // 
            // shuffleButton
            // 
            this.shuffleButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shuffleButton.Location = new System.Drawing.Point(3, 224);
            this.shuffleButton.Name = "shuffleButton";
            this.shuffleButton.Size = new System.Drawing.Size(114, 34);
            this.shuffleButton.TabIndex = 2;
            this.shuffleButton.Text = "Mélanger";
            this.shuffleButton.UseVisualStyleBackColor = true;
            this.shuffleButton.Click += new System.EventHandler(this.shuffleButton_Click);
            // 
            // SolverFormN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.gameTablePanel);
            this.Controls.Add(this.solverSidePanel);
            this.Name = "SolverFormN";
            this.Text = "SolverFormN";
            this.solverSidePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker solvingBackgroundWorker;
        private System.Windows.Forms.TableLayoutPanel solverSidePanel;
        private System.Windows.Forms.ListBox solutionListBox;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.TableLayoutPanel gameTablePanel;
        private System.Windows.Forms.Button shuffleButton;
    }
}