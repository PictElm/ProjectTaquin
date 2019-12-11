namespace App2
{
    partial class InitForm
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
            this.btnStepBack = new System.Windows.Forms.Button();
            this.tlpbottom = new System.Windows.Forms.TableLayoutPanel();
            this.btnStepForward = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.InitTable = new System.Windows.Forms.TableLayoutPanel();
            this.tlpbottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStepBack
            // 
            this.btnStepBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStepBack.Location = new System.Drawing.Point(3, 3);
            this.btnStepBack.Name = "btnStepBack";
            this.btnStepBack.Size = new System.Drawing.Size(152, 50);
            this.btnStepBack.TabIndex = 0;
            this.btnStepBack.Text = "Vers l\'arrière";
            this.btnStepBack.UseVisualStyleBackColor = true;
            this.btnStepBack.Click += new System.EventHandler(this.btnStepBack_Click);
            // 
            // tlpbottom
            // 
            this.tlpbottom.ColumnCount = 3;
            this.tlpbottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpbottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tlpbottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 243F));
            this.tlpbottom.Controls.Add(this.btnStepBack, 0, 0);
            this.tlpbottom.Controls.Add(this.btnStepForward, 1, 0);
            this.tlpbottom.Controls.Add(this.btnSend, 2, 0);
            this.tlpbottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpbottom.Location = new System.Drawing.Point(0, 441);
            this.tlpbottom.Name = "tlpbottom";
            this.tlpbottom.RowCount = 1;
            this.tlpbottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpbottom.Size = new System.Drawing.Size(524, 56);
            this.tlpbottom.TabIndex = 2;
            this.tlpbottom.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // btnStepForward
            // 
            this.btnStepForward.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStepForward.Location = new System.Drawing.Point(161, 3);
            this.btnStepForward.Name = "btnStepForward";
            this.btnStepForward.Size = new System.Drawing.Size(117, 50);
            this.btnStepForward.TabIndex = 1;
            this.btnStepForward.Text = "Vers l\'Avant";
            this.btnStepForward.UseVisualStyleBackColor = true;
            this.btnStepForward.Click += new System.EventHandler(this.btnStepForward_Click);
            // 
            // btnSend
            // 
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSend.Location = new System.Drawing.Point(284, 3);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(237, 50);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Sauvegarder";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // InitTable
            // 
            this.InitTable.ColumnCount = 1;
            this.InitTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.InitTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InitTable.Location = new System.Drawing.Point(0, 0);
            this.InitTable.Name = "InitTable";
            this.InitTable.RowCount = 1;
            this.InitTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.InitTable.Size = new System.Drawing.Size(524, 497);
            this.InitTable.TabIndex = 3;
            this.InitTable.Paint += new System.Windows.Forms.PaintEventHandler(this.ResultTable_Paint);
            // 
            // InitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 497);
            this.Controls.Add(this.tlpbottom);
            this.Controls.Add(this.InitTable);
            this.Name = "InitForm";
            this.Text = "InitForm";
            this.tlpbottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStepBack;
        private System.Windows.Forms.TableLayoutPanel tlpbottom;
        private System.Windows.Forms.Button btnStepForward;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TableLayoutPanel InitTable;
    }
}