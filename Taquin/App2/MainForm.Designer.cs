namespace App2
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.SolverTracker = new System.Windows.Forms.ListBox();
            this.SolverLaunch = new System.Windows.Forms.Button();
            this.CadreSolveur = new System.Windows.Forms.TableLayoutPanel();
            this.ShuffleButton = new System.Windows.Forms.Button();
            this.tLPRight = new System.Windows.Forms.TableLayoutPanel();
            this.ResultTable = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnChangeResult = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnStepBack = new System.Windows.Forms.Button();
            this.btnStepForward = new System.Windows.Forms.Button();
            this.btnChangeInit = new System.Windows.Forms.Button();
            this.tLPDown = new System.Windows.Forms.TableLayoutPanel();
            this.ResetButton = new System.Windows.Forms.Button();
            this.SizeButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.nUDSize = new System.Windows.Forms.NumericUpDown();
            this.lblTailleTaquin = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.nUDBlanks = new System.Windows.Forms.NumericUpDown();
            this.TaquinTable = new System.Windows.Forms.TableLayoutPanel();
            this.backgroundSolver = new System.ComponentModel.BackgroundWorker();
            this.CadreSolveur.SuspendLayout();
            this.tLPRight.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tLPDown.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDSize)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDBlanks)).BeginInit();
            this.SuspendLayout();
            // 
            // SolverTracker
            // 
            this.SolverTracker.Dock = System.Windows.Forms.DockStyle.Left;
            this.SolverTracker.FormattingEnabled = true;
            this.SolverTracker.Location = new System.Drawing.Point(3, 3);
            this.SolverTracker.Name = "SolverTracker";
            this.SolverTracker.Size = new System.Drawing.Size(178, 425);
            this.SolverTracker.TabIndex = 0;
            this.SolverTracker.SelectedIndexChanged += new System.EventHandler(this.SolverTracker_SelectedIndexChanged);
            // 
            // SolverLaunch
            // 
            this.SolverLaunch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SolverLaunch.Location = new System.Drawing.Point(3, 434);
            this.SolverLaunch.Name = "SolverLaunch";
            this.SolverLaunch.Size = new System.Drawing.Size(178, 34);
            this.SolverLaunch.TabIndex = 1;
            this.SolverLaunch.Text = "Lancer le Solveur";
            this.SolverLaunch.UseVisualStyleBackColor = true;
            this.SolverLaunch.Click += new System.EventHandler(this.SolverLaunch_Click);
            // 
            // CadreSolveur
            // 
            this.CadreSolveur.ColumnCount = 1;
            this.CadreSolveur.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CadreSolveur.Controls.Add(this.SolverTracker, 0, 0);
            this.CadreSolveur.Controls.Add(this.SolverLaunch, 0, 1);
            this.CadreSolveur.Controls.Add(this.ShuffleButton, 0, 2);
            this.CadreSolveur.Dock = System.Windows.Forms.DockStyle.Left;
            this.CadreSolveur.Location = new System.Drawing.Point(0, 0);
            this.CadreSolveur.Name = "CadreSolveur";
            this.CadreSolveur.RowCount = 3;
            this.CadreSolveur.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CadreSolveur.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.CadreSolveur.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.CadreSolveur.Size = new System.Drawing.Size(184, 511);
            this.CadreSolveur.TabIndex = 2;
            // 
            // ShuffleButton
            // 
            this.ShuffleButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShuffleButton.Location = new System.Drawing.Point(3, 474);
            this.ShuffleButton.Name = "ShuffleButton";
            this.ShuffleButton.Size = new System.Drawing.Size(178, 34);
            this.ShuffleButton.TabIndex = 2;
            this.ShuffleButton.Text = "Mélanger le Jeu";
            this.ShuffleButton.UseVisualStyleBackColor = true;
            this.ShuffleButton.Click += new System.EventHandler(this.ButtonShuffle_Click);
            // 
            // tLPRight
            // 
            this.tLPRight.ColumnCount = 1;
            this.tLPRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLPRight.Controls.Add(this.ResultTable, 0, 0);
            this.tLPRight.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tLPRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.tLPRight.Location = new System.Drawing.Point(687, 0);
            this.tLPRight.Name = "tLPRight";
            this.tLPRight.RowCount = 2;
            this.tLPRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLPRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 316F));
            this.tLPRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tLPRight.Size = new System.Drawing.Size(200, 511);
            this.tLPRight.TabIndex = 7;
            // 
            // ResultTable
            // 
            this.ResultTable.ColumnCount = 1;
            this.ResultTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ResultTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.ResultTable.Location = new System.Drawing.Point(3, 3);
            this.ResultTable.Name = "ResultTable";
            this.ResultTable.RowCount = 1;
            this.ResultTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ResultTable.Size = new System.Drawing.Size(194, 187);
            this.ResultTable.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.48454F));
            this.tableLayoutPanel1.Controls.Add(this.btnChangeResult, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnChangeInit, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 198);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.91195F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(194, 310);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // btnChangeResult
            // 
            this.btnChangeResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChangeResult.Location = new System.Drawing.Point(3, 3);
            this.btnChangeResult.Name = "btnChangeResult";
            this.btnChangeResult.Size = new System.Drawing.Size(188, 39);
            this.btnChangeResult.TabIndex = 1;
            this.btnChangeResult.Text = "Changer le résultat";
            this.btnChangeResult.UseVisualStyleBackColor = true;
            this.btnChangeResult.Click += new System.EventHandler(this.btnChangeResult_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnStepBack, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnStepForward, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 167);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(188, 59);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // btnStepBack
            // 
            this.btnStepBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStepBack.Location = new System.Drawing.Point(3, 3);
            this.btnStepBack.Name = "btnStepBack";
            this.btnStepBack.Size = new System.Drawing.Size(88, 53);
            this.btnStepBack.TabIndex = 0;
            this.btnStepBack.Text = "Coup précédent";
            this.btnStepBack.UseVisualStyleBackColor = true;
            this.btnStepBack.Click += new System.EventHandler(this.btnStepBack_Click);
            // 
            // btnStepForward
            // 
            this.btnStepForward.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStepForward.Location = new System.Drawing.Point(97, 3);
            this.btnStepForward.Name = "btnStepForward";
            this.btnStepForward.Size = new System.Drawing.Size(88, 53);
            this.btnStepForward.TabIndex = 1;
            this.btnStepForward.Text = "Coup\r\nsuivant";
            this.btnStepForward.UseVisualStyleBackColor = true;
            this.btnStepForward.Click += new System.EventHandler(this.btnStepForward_Click);
            // 
            // btnChangeInit
            // 
            this.btnChangeInit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChangeInit.Location = new System.Drawing.Point(3, 48);
            this.btnChangeInit.Name = "btnChangeInit";
            this.btnChangeInit.Size = new System.Drawing.Size(188, 37);
            this.btnChangeInit.TabIndex = 3;
            this.btnChangeInit.Text = "Changer la grille actuelle";
            this.btnChangeInit.UseVisualStyleBackColor = true;
            this.btnChangeInit.Click += new System.EventHandler(this.btnChangeInit_Click);
            // 
            // tLPDown
            // 
            this.tLPDown.ColumnCount = 4;
            this.tLPDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.22134F));
            this.tLPDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.77866F));
            this.tLPDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 129F));
            this.tLPDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tLPDown.Controls.Add(this.ResetButton, 0, 0);
            this.tLPDown.Controls.Add(this.SizeButton, 3, 0);
            this.tLPDown.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tLPDown.Controls.Add(this.tableLayoutPanel4, 2, 0);
            this.tLPDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tLPDown.Location = new System.Drawing.Point(184, 456);
            this.tLPDown.Name = "tLPDown";
            this.tLPDown.RowCount = 1;
            this.tLPDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLPDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tLPDown.Size = new System.Drawing.Size(503, 55);
            this.tLPDown.TabIndex = 9;
            // 
            // ResetButton
            // 
            this.ResetButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResetButton.Location = new System.Drawing.Point(3, 3);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(114, 49);
            this.ResetButton.TabIndex = 0;
            this.ResetButton.Text = "Réinitialiser";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // SizeButton
            // 
            this.SizeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SizeButton.Location = new System.Drawing.Point(380, 3);
            this.SizeButton.Name = "SizeButton";
            this.SizeButton.Size = new System.Drawing.Size(120, 49);
            this.SizeButton.TabIndex = 1;
            this.SizeButton.Text = "Changer la taille du Taquin";
            this.SizeButton.UseVisualStyleBackColor = true;
            this.SizeButton.Click += new System.EventHandler(this.SizeButton_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.nUDSize, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblTailleTaquin, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(123, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(122, 49);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // nUDSize
            // 
            this.nUDSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nUDSize.Location = new System.Drawing.Point(3, 3);
            this.nUDSize.Name = "nUDSize";
            this.nUDSize.Size = new System.Drawing.Size(116, 20);
            this.nUDSize.TabIndex = 3;
            this.nUDSize.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lblTailleTaquin
            // 
            this.lblTailleTaquin.AutoSize = true;
            this.lblTailleTaquin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTailleTaquin.Location = new System.Drawing.Point(3, 24);
            this.lblTailleTaquin.Name = "lblTailleTaquin";
            this.lblTailleTaquin.Size = new System.Drawing.Size(116, 25);
            this.lblTailleTaquin.TabIndex = 4;
            this.lblTailleTaquin.Text = "Taille Taquin";
            this.lblTailleTaquin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.nUDBlanks, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(251, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(123, 49);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nb Blancs";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nUDBlanks
            // 
            this.nUDBlanks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nUDBlanks.Location = new System.Drawing.Point(3, 3);
            this.nUDBlanks.Name = "nUDBlanks";
            this.nUDBlanks.Size = new System.Drawing.Size(117, 20);
            this.nUDBlanks.TabIndex = 4;
            this.nUDBlanks.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TaquinTable
            // 
            this.TaquinTable.ColumnCount = 1;
            this.TaquinTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TaquinTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TaquinTable.Location = new System.Drawing.Point(184, 0);
            this.TaquinTable.Name = "TaquinTable";
            this.TaquinTable.RowCount = 1;
            this.TaquinTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TaquinTable.Size = new System.Drawing.Size(503, 456);
            this.TaquinTable.TabIndex = 10;
            // 
            // backgroundSolver
            // 
            this.backgroundSolver.WorkerSupportsCancellation = true;
            this.backgroundSolver.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundSolver_DoWork);
            this.backgroundSolver.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundSolver_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 511);
            this.Controls.Add(this.TaquinTable);
            this.Controls.Add(this.tLPDown);
            this.Controls.Add(this.tLPRight);
            this.Controls.Add(this.CadreSolveur);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solveur Traquin";
            this.CadreSolveur.ResumeLayout(false);
            this.tLPRight.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tLPDown.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDSize)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDBlanks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox SolverTracker;
        private System.Windows.Forms.Button SolverLaunch;
        private System.Windows.Forms.TableLayoutPanel CadreSolveur;
        private System.Windows.Forms.TableLayoutPanel tLPRight;
        private System.Windows.Forms.TableLayoutPanel tLPDown;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button SizeButton;
        private System.Windows.Forms.TableLayoutPanel TaquinTable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.NumericUpDown nUDSize;
        private System.Windows.Forms.Label lblTailleTaquin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nUDBlanks;
        private System.ComponentModel.BackgroundWorker backgroundSolver;
        private System.Windows.Forms.TableLayoutPanel ResultTable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnChangeResult;
        private System.Windows.Forms.Button ShuffleButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnStepBack;
        private System.Windows.Forms.Button btnStepForward;
        private System.Windows.Forms.Button btnChangeInit;
    }
}

