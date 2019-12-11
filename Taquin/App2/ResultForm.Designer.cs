namespace App2
{
    partial class ResultForm
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
            this.tlpBottom = new System.Windows.Forms.TableLayoutPanel();
            this.btnStepBack = new System.Windows.Forms.Button();
            this.btnStepForward = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.ResultTable = new System.Windows.Forms.TableLayoutPanel();
            this.tlpBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpBottom
            // 
            this.tlpBottom.ColumnCount = 3;
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 243F));
            this.tlpBottom.Controls.Add(this.btnStepBack, 0, 0);
            this.tlpBottom.Controls.Add(this.btnStepForward, 1, 0);
            this.tlpBottom.Controls.Add(this.btnSend, 2, 0);
            this.tlpBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpBottom.Location = new System.Drawing.Point(0, 396);
            this.tlpBottom.Name = "tlpBottom";
            this.tlpBottom.RowCount = 1;
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBottom.Size = new System.Drawing.Size(481, 56);
            this.tlpBottom.TabIndex = 0;
            // 
            // btnStepBack
            // 
            this.btnStepBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStepBack.Location = new System.Drawing.Point(3, 3);
            this.btnStepBack.Name = "btnStepBack";
            this.btnStepBack.Size = new System.Drawing.Size(109, 50);
            this.btnStepBack.TabIndex = 0;
            this.btnStepBack.Text = "Vers l\'arrière";
            this.btnStepBack.UseVisualStyleBackColor = true;
            this.btnStepBack.Click += new System.EventHandler(this.btnStepBack_Click);
            // 
            // btnStepForward
            // 
            this.btnStepForward.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStepForward.Location = new System.Drawing.Point(118, 3);
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
            this.btnSend.Location = new System.Drawing.Point(241, 3);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(237, 50);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Sauvegarder";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // ResultTable
            // 
            this.ResultTable.ColumnCount = 1;
            this.ResultTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ResultTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultTable.Location = new System.Drawing.Point(0, 0);
            this.ResultTable.Name = "ResultTable";
            this.ResultTable.RowCount = 1;
            this.ResultTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ResultTable.Size = new System.Drawing.Size(481, 396);
            this.ResultTable.TabIndex = 1;
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 452);
            this.Controls.Add(this.ResultTable);
            this.Controls.Add(this.tlpBottom);
            this.Name = "ResultForm";
            this.Text = "ResultForm";
            this.tlpBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpBottom;
        private System.Windows.Forms.TableLayoutPanel ResultTable;
        private System.Windows.Forms.Button btnStepBack;
        private System.Windows.Forms.Button btnStepForward;
        private System.Windows.Forms.Button btnSend;
    }
}