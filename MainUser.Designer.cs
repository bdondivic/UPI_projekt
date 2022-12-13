namespace Backlog
{
    partial class MainUser
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpPretraga = new System.Windows.Forms.TabPage();
            this.cbZanr = new System.Windows.Forms.ComboBox();
            this.rtbOpis = new System.Windows.Forms.RichTextBox();
            this.lbIgre = new System.Windows.Forms.ListBox();
            this.txtPretraga = new System.Windows.Forms.TextBox();
            this.tpBacklog = new System.Windows.Forms.TabPage();
            this.tpIgram = new System.Windows.Forms.TabPage();
            this.tpIgrao = new System.Windows.Forms.TabPage();
            this.tpProfil = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tpPretraga.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpPretraga);
            this.tabControl1.Controls.Add(this.tpBacklog);
            this.tabControl1.Controls.Add(this.tpIgram);
            this.tabControl1.Controls.Add(this.tpIgrao);
            this.tabControl1.Controls.Add(this.tpProfil);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1006, 721);
            this.tabControl1.TabIndex = 1;
            // 
            // tpPretraga
            // 
            this.tpPretraga.Controls.Add(this.cbZanr);
            this.tpPretraga.Controls.Add(this.rtbOpis);
            this.tpPretraga.Controls.Add(this.lbIgre);
            this.tpPretraga.Controls.Add(this.txtPretraga);
            this.tpPretraga.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpPretraga.Location = new System.Drawing.Point(4, 25);
            this.tpPretraga.Name = "tpPretraga";
            this.tpPretraga.Padding = new System.Windows.Forms.Padding(3);
            this.tpPretraga.Size = new System.Drawing.Size(998, 692);
            this.tpPretraga.TabIndex = 0;
            this.tpPretraga.Text = "PRETRAGA";
            this.tpPretraga.UseVisualStyleBackColor = true;
            // 
            // cbZanr
            // 
            this.cbZanr.FormattingEnabled = true;
            this.cbZanr.Location = new System.Drawing.Point(503, 32);
            this.cbZanr.Name = "cbZanr";
            this.cbZanr.Size = new System.Drawing.Size(196, 24);
            this.cbZanr.TabIndex = 3;
            this.cbZanr.SelectedIndexChanged += new System.EventHandler(this.cbZanr_SelectedIndexChanged);
            // 
            // rtbOpis
            // 
            this.rtbOpis.Location = new System.Drawing.Point(488, 94);
            this.rtbOpis.Name = "rtbOpis";
            this.rtbOpis.Size = new System.Drawing.Size(492, 195);
            this.rtbOpis.TabIndex = 2;
            this.rtbOpis.Text = "";
            this.rtbOpis.TextChanged += new System.EventHandler(this.rtbOpis_TextChanged);
            // 
            // lbIgre
            // 
            this.lbIgre.FormattingEnabled = true;
            this.lbIgre.ItemHeight = 16;
            this.lbIgre.Location = new System.Drawing.Point(33, 94);
            this.lbIgre.Name = "lbIgre";
            this.lbIgre.Size = new System.Drawing.Size(434, 468);
            this.lbIgre.TabIndex = 1;
            this.lbIgre.SelectedIndexChanged += new System.EventHandler(this.lbIgre_SelectedIndexChanged);
            // 
            // txtPretraga
            // 
            this.txtPretraga.Location = new System.Drawing.Point(33, 34);
            this.txtPretraga.Name = "txtPretraga";
            this.txtPretraga.Size = new System.Drawing.Size(434, 22);
            this.txtPretraga.TabIndex = 0;
            this.txtPretraga.TextChanged += new System.EventHandler(this.txtPretraga_TextChanged);
            // 
            // tpBacklog
            // 
            this.tpBacklog.Location = new System.Drawing.Point(4, 25);
            this.tpBacklog.Name = "tpBacklog";
            this.tpBacklog.Padding = new System.Windows.Forms.Padding(3);
            this.tpBacklog.Size = new System.Drawing.Size(998, 692);
            this.tpBacklog.TabIndex = 1;
            this.tpBacklog.Text = "BACKLOG";
            this.tpBacklog.UseVisualStyleBackColor = true;
            // 
            // tpIgram
            // 
            this.tpIgram.Location = new System.Drawing.Point(4, 25);
            this.tpIgram.Name = "tpIgram";
            this.tpIgram.Padding = new System.Windows.Forms.Padding(3);
            this.tpIgram.Size = new System.Drawing.Size(998, 692);
            this.tpIgram.TabIndex = 2;
            this.tpIgram.Text = "IGRAM";
            this.tpIgram.UseVisualStyleBackColor = true;
            // 
            // tpIgrao
            // 
            this.tpIgrao.Location = new System.Drawing.Point(4, 25);
            this.tpIgrao.Name = "tpIgrao";
            this.tpIgrao.Size = new System.Drawing.Size(998, 692);
            this.tpIgrao.TabIndex = 3;
            this.tpIgrao.Text = "IGRAO";
            this.tpIgrao.UseVisualStyleBackColor = true;
            // 
            // tpProfil
            // 
            this.tpProfil.Location = new System.Drawing.Point(4, 25);
            this.tpProfil.Name = "tpProfil";
            this.tpProfil.Size = new System.Drawing.Size(998, 692);
            this.tpProfil.TabIndex = 4;
            this.tpProfil.Text = "PROFIL";
            this.tpProfil.UseVisualStyleBackColor = true;
            // 
            // MainUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainUser";
            this.Load += new System.EventHandler(this.MainUser_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpPretraga.ResumeLayout(false);
            this.tpPretraga.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpPretraga;
        private System.Windows.Forms.TabPage tpBacklog;
        private System.Windows.Forms.TabPage tpIgram;
        private System.Windows.Forms.TabPage tpIgrao;
        private System.Windows.Forms.TabPage tpProfil;
        private System.Windows.Forms.ComboBox cbZanr;
        private System.Windows.Forms.RichTextBox rtbOpis;
        private System.Windows.Forms.ListBox lbIgre;
        private System.Windows.Forms.TextBox txtPretraga;
    }
}