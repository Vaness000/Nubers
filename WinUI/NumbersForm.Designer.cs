namespace WinUI
{
    partial class NumbersForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.getFrequenceBtn = new System.Windows.Forms.Button();
            this.numberTB = new System.Windows.Forms.TextBox();
            this.getNumbersByFrequenceBtn = new System.Windows.Forms.Button();
            this.numbersByFrequenceRtb = new System.Windows.Forms.RichTextBox();
            this.getTopFrequenceBtn = new System.Windows.Forms.Button();
            this.topFrequenceRtb = new System.Windows.Forms.RichTextBox();
            this.frequencyTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // getFrequenceBtn
            // 
            this.getFrequenceBtn.Location = new System.Drawing.Point(10, 27);
            this.getFrequenceBtn.Name = "getFrequenceBtn";
            this.getFrequenceBtn.Size = new System.Drawing.Size(250, 23);
            this.getFrequenceBtn.TabIndex = 0;
            this.getFrequenceBtn.Text = "Get frequence by number";
            this.getFrequenceBtn.UseVisualStyleBackColor = true;
            this.getFrequenceBtn.Click += new System.EventHandler(this.getFrequenceBtn_Click);
            // 
            // numberTB
            // 
            this.numberTB.Location = new System.Drawing.Point(264, 27);
            this.numberTB.Name = "numberTB";
            this.numberTB.Size = new System.Drawing.Size(107, 23);
            this.numberTB.TabIndex = 1;
            // 
            // getNumbersByFrequenceBtn
            // 
            this.getNumbersByFrequenceBtn.Location = new System.Drawing.Point(10, 61);
            this.getNumbersByFrequenceBtn.Name = "getNumbersByFrequenceBtn";
            this.getNumbersByFrequenceBtn.Size = new System.Drawing.Size(250, 23);
            this.getNumbersByFrequenceBtn.TabIndex = 2;
            this.getNumbersByFrequenceBtn.Text = "Get numbers by frequence";
            this.getNumbersByFrequenceBtn.UseVisualStyleBackColor = true;
            this.getNumbersByFrequenceBtn.Click += new System.EventHandler(this.getNumbersByFrequenceBtn_Click);
            // 
            // numbersByFrequenceRtb
            // 
            this.numbersByFrequenceRtb.Location = new System.Drawing.Point(11, 94);
            this.numbersByFrequenceRtb.Name = "numbersByFrequenceRtb";
            this.numbersByFrequenceRtb.Size = new System.Drawing.Size(360, 187);
            this.numbersByFrequenceRtb.TabIndex = 3;
            this.numbersByFrequenceRtb.Text = "";
            // 
            // getTopFrequenceBtn
            // 
            this.getTopFrequenceBtn.Location = new System.Drawing.Point(12, 287);
            this.getTopFrequenceBtn.Name = "getTopFrequenceBtn";
            this.getTopFrequenceBtn.Size = new System.Drawing.Size(359, 23);
            this.getTopFrequenceBtn.TabIndex = 4;
            this.getTopFrequenceBtn.Text = "Get top frequence";
            this.getTopFrequenceBtn.UseVisualStyleBackColor = true;
            this.getTopFrequenceBtn.Click += new System.EventHandler(this.getTopFrequenceBtn_Click);
            // 
            // topFrequenceRtb
            // 
            this.topFrequenceRtb.Location = new System.Drawing.Point(12, 316);
            this.topFrequenceRtb.Name = "topFrequenceRtb";
            this.topFrequenceRtb.Size = new System.Drawing.Size(359, 311);
            this.topFrequenceRtb.TabIndex = 5;
            this.topFrequenceRtb.Text = "";
            // 
            // frequencyTB
            // 
            this.frequencyTB.Location = new System.Drawing.Point(264, 61);
            this.frequencyTB.Name = "frequencyTB";
            this.frequencyTB.Size = new System.Drawing.Size(107, 23);
            this.frequencyTB.TabIndex = 6;
            // 
            // NumbersFrorm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 639);
            this.Controls.Add(this.frequencyTB);
            this.Controls.Add(this.topFrequenceRtb);
            this.Controls.Add(this.getTopFrequenceBtn);
            this.Controls.Add(this.numbersByFrequenceRtb);
            this.Controls.Add(this.getNumbersByFrequenceBtn);
            this.Controls.Add(this.numberTB);
            this.Controls.Add(this.getFrequenceBtn);
            this.Name = "NumbersFrorm";
            this.Text = "Numbers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button getFrequenceBtn;
        private TextBox numberTB;
        private Button getNumbersByFrequenceBtn;
        private RichTextBox numbersByFrequenceRtb;
        private Button getTopFrequenceBtn;
        private RichTextBox topFrequenceRtb;
        private TextBox frequencyTB;
    }
}