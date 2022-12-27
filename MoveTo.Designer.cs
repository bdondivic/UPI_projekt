namespace Test
{
    partial class MoveTo
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
            this.btnPotvrdi = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUkupno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtKraj = new System.Windows.Forms.DateTimePicker();
            this.dtPocetak = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnPotvrdi
            // 
            this.btnPotvrdi.Location = new System.Drawing.Point(19, 253);
            this.btnPotvrdi.Name = "btnPotvrdi";
            this.btnPotvrdi.Size = new System.Drawing.Size(136, 40);
            this.btnPotvrdi.TabIndex = 19;
            this.btnPotvrdi.Text = "POTVRDI";
            this.btnPotvrdi.UseVisualStyleBackColor = true;
            this.btnPotvrdi.Click += new System.EventHandler(this.btnPotvrdi_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Ukupno Vrijeme Igranja";
            // 
            // txtUkupno
            // 
            this.txtUkupno.Location = new System.Drawing.Point(16, 191);
            this.txtUkupno.Name = "txtUkupno";
            this.txtUkupno.Size = new System.Drawing.Size(152, 22);
            this.txtUkupno.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Kraj Igranja";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Početak Igranja";
            // 
            // dtKraj
            // 
            this.dtKraj.Location = new System.Drawing.Point(222, 96);
            this.dtKraj.Name = "dtKraj";
            this.dtKraj.Size = new System.Drawing.Size(200, 22);
            this.dtKraj.TabIndex = 12;
            // 
            // dtPocetak
            // 
            this.dtPocetak.Location = new System.Drawing.Point(16, 96);
            this.dtPocetak.Name = "dtPocetak";
            this.dtPocetak.Size = new System.Drawing.Size(200, 22);
            this.dtPocetak.TabIndex = 11;
            // 
            // Move
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 450);
            this.Controls.Add(this.btnPotvrdi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUkupno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtKraj);
            this.Controls.Add(this.dtPocetak);
            this.Name = "Move";
            this.Text = "Move";
            this.Load += new System.EventHandler(this.Move_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPotvrdi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUkupno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtKraj;
        private System.Windows.Forms.DateTimePicker dtPocetak;
    }
}