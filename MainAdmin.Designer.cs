namespace Backlog
{
    partial class MainAdmin
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
            this.rtbInf = new System.Windows.Forms.RichTextBox();
            this.lbKorisnici = new System.Windows.Forms.ListBox();
            this.txtPretraga = new System.Windows.Forms.TextBox();
            this.btnPreuzPodKor = new System.Windows.Forms.Button();
            this.btnBrisiRacun = new System.Windows.Forms.Button();
            this.btnPreuzKorSvi = new System.Windows.Forms.Button();
            this.btnOdjava = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbInf
            // 
            this.rtbInf.Location = new System.Drawing.Point(485, 156);
            this.rtbInf.Name = "rtbInf";
            this.rtbInf.Size = new System.Drawing.Size(492, 195);
            this.rtbInf.TabIndex = 5;
            this.rtbInf.Text = "";
            // 
            // lbKorisnici
            // 
            this.lbKorisnici.FormattingEnabled = true;
            this.lbKorisnici.ItemHeight = 16;
            this.lbKorisnici.Location = new System.Drawing.Point(30, 156);
            this.lbKorisnici.Name = "lbKorisnici";
            this.lbKorisnici.Size = new System.Drawing.Size(434, 468);
            this.lbKorisnici.TabIndex = 4;
            this.lbKorisnici.SelectedIndexChanged += new System.EventHandler(this.lbKorisnici_SelectedIndexChanged);
            // 
            // txtPretraga
            // 
            this.txtPretraga.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPretraga.Location = new System.Drawing.Point(30, 96);
            this.txtPretraga.Name = "txtPretraga";
            this.txtPretraga.Size = new System.Drawing.Size(434, 28);
            this.txtPretraga.TabIndex = 3;
            this.txtPretraga.TextChanged += new System.EventHandler(this.txtPretraga_TextChanged);
            // 
            // btnPreuzPodKor
            // 
            this.btnPreuzPodKor.Location = new System.Drawing.Point(485, 357);
            this.btnPreuzPodKor.Name = "btnPreuzPodKor";
            this.btnPreuzPodKor.Size = new System.Drawing.Size(152, 46);
            this.btnPreuzPodKor.TabIndex = 6;
            this.btnPreuzPodKor.Text = "PREUZMI LISTE";
            this.btnPreuzPodKor.UseVisualStyleBackColor = true;
            this.btnPreuzPodKor.Click += new System.EventHandler(this.btnPreuzPodKor_Click);
            // 
            // btnBrisiRacun
            // 
            this.btnBrisiRacun.Location = new System.Drawing.Point(643, 357);
            this.btnBrisiRacun.Name = "btnBrisiRacun";
            this.btnBrisiRacun.Size = new System.Drawing.Size(152, 46);
            this.btnBrisiRacun.TabIndex = 7;
            this.btnBrisiRacun.Text = "IZBRIŠI KORISNIČKI RAČUN";
            this.btnBrisiRacun.UseVisualStyleBackColor = true;
            this.btnBrisiRacun.Click += new System.EventHandler(this.btnBrisiRacun_Click);
            // 
            // btnPreuzKorSvi
            // 
            this.btnPreuzKorSvi.Location = new System.Drawing.Point(485, 409);
            this.btnPreuzKorSvi.Name = "btnPreuzKorSvi";
            this.btnPreuzKorSvi.Size = new System.Drawing.Size(310, 46);
            this.btnPreuzKorSvi.TabIndex = 8;
            this.btnPreuzKorSvi.Text = "PREUZMI KORISNIČKE PODATKE SVIH KORISNIKA";
            this.btnPreuzKorSvi.UseVisualStyleBackColor = true;
            this.btnPreuzKorSvi.Click += new System.EventHandler(this.btnPreuzKorSvi_Click);
            // 
            // btnOdjava
            // 
            this.btnOdjava.Location = new System.Drawing.Point(828, 34);
            this.btnOdjava.Name = "btnOdjava";
            this.btnOdjava.Size = new System.Drawing.Size(166, 48);
            this.btnOdjava.TabIndex = 10;
            this.btnOdjava.Text = "ODJAVA";
            this.btnOdjava.UseVisualStyleBackColor = true;
            this.btnOdjava.Click += new System.EventHandler(this.btnOdjava_Click);
            // 
            // MainAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.btnOdjava);
            this.Controls.Add(this.btnPreuzKorSvi);
            this.Controls.Add(this.btnBrisiRacun);
            this.Controls.Add(this.btnPreuzPodKor);
            this.Controls.Add(this.rtbInf);
            this.Controls.Add(this.lbKorisnici);
            this.Controls.Add(this.txtPretraga);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainAdmin";
            this.Text = "MainAdmin";
            this.Load += new System.EventHandler(this.MainAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbInf;
        private System.Windows.Forms.ListBox lbKorisnici;
        private System.Windows.Forms.TextBox txtPretraga;
        private System.Windows.Forms.Button btnPreuzPodKor;
        private System.Windows.Forms.Button btnBrisiRacun;
        private System.Windows.Forms.Button btnPreuzKorSvi;
        private System.Windows.Forms.Button btnOdjava;
    }
}