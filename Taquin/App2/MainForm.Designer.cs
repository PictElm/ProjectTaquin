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
            this.ResultTable = new System.Windows.Forms.TableLayoutPanel();
            this.TaquinTable = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ResetButton = new System.Windows.Forms.Button();
            this.SizeButton = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.CadreSolveur.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // SolverTracker
            // 
            this.SolverTracker.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SolverTracker.FormattingEnabled = true;
            this.SolverTracker.Location = new System.Drawing.Point(3, 3);
            this.SolverTracker.Name = "SolverTracker";
            this.SolverTracker.Size = new System.Drawing.Size(199, 433);
            this.SolverTracker.TabIndex = 0;
            // 
            // SolverLaunch
            // 
            this.SolverLaunch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SolverLaunch.Location = new System.Drawing.Point(3, 443);
            this.SolverLaunch.Name = "SolverLaunch";
            this.SolverLaunch.Size = new System.Drawing.Size(199, 41);
            this.SolverLaunch.TabIndex = 1;
            this.SolverLaunch.Text = "Lancer Le Solveur";
            this.SolverLaunch.UseVisualStyleBackColor = true;
            this.SolverLaunch.Click += new System.EventHandler(this.SolverLaunch_Click);
            // 
            // CadreSolveur
            // 
            this.CadreSolveur.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CadreSolveur.ColumnCount = 1;
            this.CadreSolveur.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CadreSolveur.Controls.Add(this.SolverTracker, 0, 0);
            this.CadreSolveur.Controls.Add(this.SolverLaunch, 0, 1);
            this.CadreSolveur.Location = new System.Drawing.Point(12, 12);
            this.CadreSolveur.Name = "CadreSolveur";
            this.CadreSolveur.RowCount = 2;
            this.CadreSolveur.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.55441F));
            this.CadreSolveur.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.445585F));
            this.CadreSolveur.Size = new System.Drawing.Size(205, 487);
            this.CadreSolveur.TabIndex = 2;
            // 
            // ResultTable
            // 
            this.ResultTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultTable.ColumnCount = 1;
            this.ResultTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ResultTable.Location = new System.Drawing.Point(582, 12);
            this.ResultTable.Name = "ResultTable";
            this.ResultTable.RowCount = 1;
            this.ResultTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ResultTable.Size = new System.Drawing.Size(215, 187);
            this.ResultTable.TabIndex = 4;
            // 
            // TaquinTable
            // 
            this.TaquinTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TaquinTable.ColumnCount = 1;
            this.TaquinTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TaquinTable.Location = new System.Drawing.Point(220, 12);
            this.TaquinTable.Name = "TaquinTable";
            this.TaquinTable.RowCount = 1;
            this.TaquinTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TaquinTable.Size = new System.Drawing.Size(356, 442);
            this.TaquinTable.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel2.Controls.Add(this.ResetButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.SizeButton, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.numericUpDown1, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(220, 455);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(356, 44);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(3, 3);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(116, 38);
            this.ResetButton.TabIndex = 0;
            this.ResetButton.Text = "Réinitialiser";
            this.ResetButton.UseVisualStyleBackColor = true;
            // 
            // SizeButton
            // 
            this.SizeButton.Location = new System.Drawing.Point(247, 3);
            this.SizeButton.Name = "SizeButton";
            this.SizeButton.Size = new System.Drawing.Size(106, 38);
            this.SizeButton.TabIndex = 1;
            this.SizeButton.Text = "Changer la taille du Taquin";
            this.SizeButton.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(125, 3);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(116, 20);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 511);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.TaquinTable);
            this.Controls.Add(this.ResultTable);
            this.Controls.Add(this.CadreSolveur);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "Solveur Traquin";
            this.CadreSolveur.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox SolverTracker;
        private System.Windows.Forms.Button SolverLaunch;
        private System.Windows.Forms.TableLayoutPanel CadreSolveur;
        private System.Windows.Forms.TableLayoutPanel ResultTable;
        private System.Windows.Forms.TableLayoutPanel TaquinTable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button SizeButton;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

