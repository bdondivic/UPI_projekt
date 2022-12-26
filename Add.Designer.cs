namespace Test
{
    partial class Add
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
            this.dtPocetak = new System.Windows.Forms.DateTimePicker();
            this.dtKraj = new System.Windows.Forms.DateTimePicker();
            this.cbLista = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUkupno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPrioritet = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPotvrdi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtPocetak
            // 
            this.dtPocetak.Location = new System.Drawing.Point(12, 136);
            this.dtPocetak.Name = "dtPocetak";
            this.dtPocetak.Size = new System.Drawing.Size(200, 22);
            this.dtPocetak.TabIndex = 0;
            // 
            // dtKraj
            // 
            this.dtKraj.Location = new System.Drawing.Point(218, 136);
            this.dtKraj.Name = "dtKraj";
            this.dtKraj.Size = new System.Drawing.Size(200, 22);
            this.dtKraj.TabIndex = 1;
            // 
            // cbLista
            // 
            this.cbLista.FormattingEnabled = true;
            this.cbLista.Items.AddRange(new object[] {
            "BACKLOG",
            "IGRAM",
            "IGRAO"});
            this.cbLista.Location = new System.Drawing.Point(12, 46);
            this.cbLista.Name = "cbLista";
            this.cbLista.Size = new System.Drawing.Size(192, 24);
            this.cbLista.TabIndex = 2;
            this.cbLista.SelectedIndexChanged += new System.EventHandler(this.cbLista_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Početak Igranja";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Kraj Igranja";
            // 
            // txtUkupno
            // 
            this.txtUkupno.Location = new System.Drawing.Point(12, 231);
            this.txtUkupno.Name = "txtUkupno";
            this.txtUkupno.Size = new System.Drawing.Size(152, 22);
            this.txtUkupno.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ukupno Vrijeme Igranja";
            // 
            // cbPrioritet
            // 
            this.cbPrioritet.FormattingEnabled = true;
            this.cbPrioritet.Items.AddRange(new object[] {
            "NISKI",
            "SREDNJI",
            "VISOKI"});
            this.cbPrioritet.Location = new System.Drawing.Point(12, 312);
            this.cbPrioritet.Name = "cbPrioritet";
            this.cbPrioritet.Size = new System.Drawing.Size(192, 24);
            this.cbPrioritet.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 293);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Prioritet";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Prioritet";
            // 
            // btnPotvrdi
            // 
            this.btnPotvrdi.Location = new System.Drawing.Point(12, 373);
            this.btnPotvrdi.Name = "btnPotvrdi";
            this.btnPotvrdi.Size = new System.Drawing.Size(136, 40);
            this.btnPotvrdi.TabIndex = 10;
            this.btnPotvrdi.Text = "POTVRDI";
            this.btnPotvrdi.UseVisualStyleBackColor = true;
            this.btnPotvrdi.Click += new System.EventHandler(this.btnPotvrdi_Click);
            // 
            // Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 450);
            this.Controls.Add(this.btnPotvrdi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbPrioritet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUkupno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbLista);
            this.Controls.Add(this.dtKraj);
            this.Controls.Add(this.dtPocetak);
            this.Name = "Add";
            this.Text = "Add";
            this.Load += new System.EventHandler(this.Add_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtPocetak;
        private System.Windows.Forms.DateTimePicker dtKraj;
        private System.Windows.Forms.ComboBox cbLista;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUkupno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbPrioritet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPotvrdi;
    }
}