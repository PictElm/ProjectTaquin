namespace App
{
    partial class AppForm
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
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.gameSizeNum = new System.Windows.Forms.NumericUpDown();
            this.shuffleMovesNum = new System.Windows.Forms.NumericUpDown();
            this.gapCountNum = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameSizeNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shuffleMovesNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gapCountNum)).BeginInit();
            this.SuspendLayout();
            // 
            // btn1
            // 
            this.btn1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn1.Location = new System.Drawing.Point(280, 3);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(187, 148);
            this.btn1.TabIndex = 0;
            this.btn1.Text = "Launch Solver";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn2
            // 
            this.btn2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn2.Location = new System.Drawing.Point(3, 3);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(186, 187);
            this.btn2.TabIndex = 1;
            this.btn2.Text = "Launch Game";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.90909F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.90909F));
            this.tableLayoutPanel1.Controls.Add(this.btn2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(470, 193);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.gameSizeNum, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.shuffleMovesNum, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.gapCountNum, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(195, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(79, 187);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // gameSizeNum
            // 
            this.gameSizeNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gameSizeNum.Location = new System.Drawing.Point(3, 21);
            this.gameSizeNum.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.gameSizeNum.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.gameSizeNum.Name = "gameSizeNum";
            this.gameSizeNum.Size = new System.Drawing.Size(73, 20);
            this.gameSizeNum.TabIndex = 2;
            this.gameSizeNum.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // shuffleMovesNum
            // 
            this.shuffleMovesNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.shuffleMovesNum.Location = new System.Drawing.Point(3, 83);
            this.shuffleMovesNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.shuffleMovesNum.Name = "shuffleMovesNum";
            this.shuffleMovesNum.Size = new System.Drawing.Size(73, 20);
            this.shuffleMovesNum.TabIndex = 3;
            this.shuffleMovesNum.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // gapCountNum
            // 
            this.gapCountNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gapCountNum.Location = new System.Drawing.Point(3, 145);
            this.gapCountNum.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.gapCountNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.gapCountNum.Name = "gapCountNum";
            this.gapCountNum.Size = new System.Drawing.Size(73, 20);
            this.gapCountNum.TabIndex = 4;
            this.gapCountNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 219);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AppForm";
            this.Text = "butt";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gameSizeNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shuffleMovesNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gapCountNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown gameSizeNum;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.NumericUpDown shuffleMovesNum;
        private System.Windows.Forms.NumericUpDown gapCountNum;
    }
}