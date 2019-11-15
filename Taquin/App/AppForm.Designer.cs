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
            this.btnSize3 = new System.Windows.Forms.Button();
            this.btnSize5 = new System.Windows.Forms.Button();
            this.lblChoiceSize = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn1
            // 
            this.btn1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn1.Location = new System.Drawing.Point(236, 3);
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
            this.btn2.Size = new System.Drawing.Size(185, 148);
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.Controls.Add(this.btn2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn1, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(426, 154);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btnSize3
            // 
            this.btnSize3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSize3.Location = new System.Drawing.Point(223, 184);
            this.btnSize3.Name = "btnSize3";
            this.btnSize3.Size = new System.Drawing.Size(75, 23);
            this.btnSize3.TabIndex = 3;
            this.btnSize3.Text = "3 x 3";
            this.btnSize3.UseVisualStyleBackColor = true;
            this.btnSize3.Click += new System.EventHandler(this.btnSize3_Click);
            // 
            // btnSize5
            // 
            this.btnSize5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSize5.Location = new System.Drawing.Point(343, 184);
            this.btnSize5.Name = "btnSize5";
            this.btnSize5.Size = new System.Drawing.Size(75, 23);
            this.btnSize5.TabIndex = 4;
            this.btnSize5.Text = "5 x 5";
            this.btnSize5.UseVisualStyleBackColor = true;
            this.btnSize5.Click += new System.EventHandler(this.btnSize5_Click);
            // 
            // lblChoiceSize
            // 
            this.lblChoiceSize.AutoSize = true;
            this.lblChoiceSize.Location = new System.Drawing.Point(21, 189);
            this.lblChoiceSize.Name = "lblChoiceSize";
            this.lblChoiceSize.Size = new System.Drawing.Size(152, 13);
            this.lblChoiceSize.TabIndex = 5;
            this.lblChoiceSize.Text = "Choisissez la Taille du Taquin :";
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 219);
            this.Controls.Add(this.lblChoiceSize);
            this.Controls.Add(this.btnSize5);
            this.Controls.Add(this.btnSize3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AppForm";
            this.Text = "butt";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnSize3;
        private System.Windows.Forms.Button btnSize5;
        private System.Windows.Forms.Label lblChoiceSize;
    }
}