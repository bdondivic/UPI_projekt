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
            this.btnDodaj = new System.Windows.Forms.Button();
            this.cbZanr = new System.Windows.Forms.ComboBox();
            this.rtbOpis = new System.Windows.Forms.RichTextBox();
            this.lbIgre = new System.Windows.Forms.ListBox();
            this.txtPretraga = new System.Windows.Forms.TextBox();
            this.tpBacklog = new System.Windows.Forms.TabPage();
            this.btnBacklogIgram = new System.Windows.Forms.Button();
            this.btnUkloniBacklog = new System.Windows.Forms.Button();
            this.rtbBacklogOpis = new System.Windows.Forms.RichTextBox();
            this.lbBacklog = new System.Windows.Forms.ListBox();
            this.tpIgram = new System.Windows.Forms.TabPage();
            this.btnIgramIgrao = new System.Windows.Forms.Button();
            this.btnUkloniIgram = new System.Windows.Forms.Button();
            this.rtbIgramOpis = new System.Windows.Forms.RichTextBox();
            this.lbIgram = new System.Windows.Forms.ListBox();
            this.tpIgrao = new System.Windows.Forms.TabPage();
            this.btnIgraoIgram = new System.Windows.Forms.Button();
            this.btnUkloniIgrao = new System.Windows.Forms.Button();
            this.rtbIgraoOpis = new System.Windows.Forms.RichTextBox();
            this.lbIgrao = new System.Windows.Forms.ListBox();
            this.tpProfil = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tpPretraga.SuspendLayout();
            this.tpBacklog.SuspendLayout();
            this.tpIgram.SuspendLayout();
            this.tpIgrao.SuspendLayout();
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
            this.tpPretraga.Controls.Add(this.btnDodaj);
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
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(488, 295);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(157, 57);
            this.btnDodaj.TabIndex = 4;
            this.btnDodaj.Text = "DODAJ";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // cbZanr
            // 
            this.cbZanr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbZanr.FormattingEnabled = true;
            this.cbZanr.Items.AddRange(new object[] {
            "Svi žanrovi"});
            this.cbZanr.Location = new System.Drawing.Point(503, 32);
            this.cbZanr.Name = "cbZanr";
            this.cbZanr.Size = new System.Drawing.Size(196, 26);
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
            this.txtPretraga.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPretraga.Location = new System.Drawing.Point(33, 34);
            this.txtPretraga.Name = "txtPretraga";
            this.txtPretraga.Size = new System.Drawing.Size(434, 28);
            this.txtPretraga.TabIndex = 0;
            this.txtPretraga.TextChanged += new System.EventHandler(this.txtPretraga_TextChanged);
            // 
            // tpBacklog
            // 
            this.tpBacklog.Controls.Add(this.btnBacklogIgram);
            this.tpBacklog.Controls.Add(this.btnUkloniBacklog);
            this.tpBacklog.Controls.Add(this.rtbBacklogOpis);
            this.tpBacklog.Controls.Add(this.lbBacklog);
            this.tpBacklog.Location = new System.Drawing.Point(4, 25);
            this.tpBacklog.Name = "tpBacklog";
            this.tpBacklog.Padding = new System.Windows.Forms.Padding(3);
            this.tpBacklog.Size = new System.Drawing.Size(998, 692);
            this.tpBacklog.TabIndex = 1;
            this.tpBacklog.Text = "BACKLOG";
            this.tpBacklog.UseVisualStyleBackColor = true;
            // 
            // btnBacklogIgram
            // 
            this.btnBacklogIgram.Location = new System.Drawing.Point(644, 313);
            this.btnBacklogIgram.Name = "btnBacklogIgram";
            this.btnBacklogIgram.Size = new System.Drawing.Size(157, 57);
            this.btnBacklogIgram.TabIndex = 6;
            this.btnBacklogIgram.Text = "PRENESI U IGRAM";
            this.btnBacklogIgram.UseVisualStyleBackColor = true;
            this.btnBacklogIgram.Click += new System.EventHandler(this.btnBacklogIgram_Click);
            // 
            // btnUkloniBacklog
            // 
            this.btnUkloniBacklog.Location = new System.Drawing.Point(481, 313);
            this.btnUkloniBacklog.Name = "btnUkloniBacklog";
            this.btnUkloniBacklog.Size = new System.Drawing.Size(157, 57);
            this.btnUkloniBacklog.TabIndex = 5;
            this.btnUkloniBacklog.Text = "UKLONI IZ LISTE";
            this.btnUkloniBacklog.UseVisualStyleBackColor = true;
            this.btnUkloniBacklog.Click += new System.EventHandler(this.btnUkloniBacklog_Click);
            // 
            // rtbBacklogOpis
            // 
            this.rtbBacklogOpis.Location = new System.Drawing.Point(481, 112);
            this.rtbBacklogOpis.Name = "rtbBacklogOpis";
            this.rtbBacklogOpis.Size = new System.Drawing.Size(492, 195);
            this.rtbBacklogOpis.TabIndex = 4;
            this.rtbBacklogOpis.Text = "";
            // 
            // lbBacklog
            // 
            this.lbBacklog.FormattingEnabled = true;
            this.lbBacklog.ItemHeight = 16;
            this.lbBacklog.Location = new System.Drawing.Point(26, 112);
            this.lbBacklog.Name = "lbBacklog";
            this.lbBacklog.Size = new System.Drawing.Size(434, 468);
            this.lbBacklog.TabIndex = 3;
            this.lbBacklog.SelectedIndexChanged += new System.EventHandler(this.lbBacklog_SelectedIndexChanged);
            // 
            // tpIgram
            // 
            this.tpIgram.Controls.Add(this.btnIgramIgrao);
            this.tpIgram.Controls.Add(this.btnUkloniIgram);
            this.tpIgram.Controls.Add(this.rtbIgramOpis);
            this.tpIgram.Controls.Add(this.lbIgram);
            this.tpIgram.Location = new System.Drawing.Point(4, 25);
            this.tpIgram.Name = "tpIgram";
            this.tpIgram.Padding = new System.Windows.Forms.Padding(3);
            this.tpIgram.Size = new System.Drawing.Size(998, 692);
            this.tpIgram.TabIndex = 2;
            this.tpIgram.Text = "IGRAM";
            this.tpIgram.UseVisualStyleBackColor = true;
            // 
            // btnIgramIgrao
            // 
            this.btnIgramIgrao.Location = new System.Drawing.Point(644, 313);
            this.btnIgramIgrao.Name = "btnIgramIgrao";
            this.btnIgramIgrao.Size = new System.Drawing.Size(157, 57);
            this.btnIgramIgrao.TabIndex = 8;
            this.btnIgramIgrao.Text = "PRENESI U IGRAO";
            this.btnIgramIgrao.UseVisualStyleBackColor = true;
            this.btnIgramIgrao.Click += new System.EventHandler(this.btnIgramIgrao_Click);
            // 
            // btnUkloniIgram
            // 
            this.btnUkloniIgram.Location = new System.Drawing.Point(481, 313);
            this.btnUkloniIgram.Name = "btnUkloniIgram";
            this.btnUkloniIgram.Size = new System.Drawing.Size(157, 57);
            this.btnUkloniIgram.TabIndex = 7;
            this.btnUkloniIgram.Text = "UKLONI IZ LISTE";
            this.btnUkloniIgram.UseVisualStyleBackColor = true;
            this.btnUkloniIgram.Click += new System.EventHandler(this.btnUkloniIgram_Click);
            // 
            // rtbIgramOpis
            // 
            this.rtbIgramOpis.Location = new System.Drawing.Point(481, 112);
            this.rtbIgramOpis.Name = "rtbIgramOpis";
            this.rtbIgramOpis.Size = new System.Drawing.Size(492, 195);
            this.rtbIgramOpis.TabIndex = 6;
            this.rtbIgramOpis.Text = "";
            // 
            // lbIgram
            // 
            this.lbIgram.FormattingEnabled = true;
            this.lbIgram.ItemHeight = 16;
            this.lbIgram.Location = new System.Drawing.Point(26, 112);
            this.lbIgram.Name = "lbIgram";
            this.lbIgram.Size = new System.Drawing.Size(434, 468);
            this.lbIgram.TabIndex = 5;
            this.lbIgram.SelectedIndexChanged += new System.EventHandler(this.lbIgram_SelectedIndexChanged);
            // 
            // tpIgrao
            // 
            this.tpIgrao.Controls.Add(this.btnIgraoIgram);
            this.tpIgrao.Controls.Add(this.btnUkloniIgrao);
            this.tpIgrao.Controls.Add(this.rtbIgraoOpis);
            this.tpIgrao.Controls.Add(this.lbIgrao);
            this.tpIgrao.Location = new System.Drawing.Point(4, 25);
            this.tpIgrao.Name = "tpIgrao";
            this.tpIgrao.Size = new System.Drawing.Size(998, 692);
            this.tpIgrao.TabIndex = 3;
            this.tpIgrao.Text = "IGRAO";
            this.tpIgrao.UseVisualStyleBackColor = true;
            // 
            // btnIgraoIgram
            // 
            this.btnIgraoIgram.Location = new System.Drawing.Point(644, 313);
            this.btnIgraoIgram.Name = "btnIgraoIgram";
            this.btnIgraoIgram.Size = new System.Drawing.Size(157, 57);
            this.btnIgraoIgram.TabIndex = 8;
            this.btnIgraoIgram.Text = "PRENESI U IGRAM";
            this.btnIgraoIgram.UseVisualStyleBackColor = true;
            this.btnIgraoIgram.Click += new System.EventHandler(this.btnIgraoIgram_Click);
            // 
            // btnUkloniIgrao
            // 
            this.btnUkloniIgrao.Location = new System.Drawing.Point(481, 313);
            this.btnUkloniIgrao.Name = "btnUkloniIgrao";
            this.btnUkloniIgrao.Size = new System.Drawing.Size(157, 57);
            this.btnUkloniIgrao.TabIndex = 7;
            this.btnUkloniIgrao.Text = "UKLONI IZ LISTE";
            this.btnUkloniIgrao.UseVisualStyleBackColor = true;
            this.btnUkloniIgrao.Click += new System.EventHandler(this.btnUkloniIgrao_Click);
            // 
            // rtbIgraoOpis
            // 
            this.rtbIgraoOpis.Location = new System.Drawing.Point(481, 112);
            this.rtbIgraoOpis.Name = "rtbIgraoOpis";
            this.rtbIgraoOpis.Size = new System.Drawing.Size(492, 195);
            this.rtbIgraoOpis.TabIndex = 6;
            this.rtbIgraoOpis.Text = "";
            // 
            // lbIgrao
            // 
            this.lbIgrao.FormattingEnabled = true;
            this.lbIgrao.ItemHeight = 16;
            this.lbIgrao.Location = new System.Drawing.Point(26, 112);
            this.lbIgrao.Name = "lbIgrao";
            this.lbIgrao.Size = new System.Drawing.Size(434, 468);
            this.lbIgrao.TabIndex = 5;
            this.lbIgrao.SelectedIndexChanged += new System.EventHandler(this.lbIgrao_SelectedIndexChanged);
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
            this.tpBacklog.ResumeLayout(false);
            this.tpIgram.ResumeLayout(false);
            this.tpIgrao.ResumeLayout(false);
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
        private System.Windows.Forms.RichTextBox rtbBacklogOpis;
        private System.Windows.Forms.ListBox lbBacklog;
        private System.Windows.Forms.RichTextBox rtbIgramOpis;
        private System.Windows.Forms.ListBox lbIgram;
        private System.Windows.Forms.RichTextBox rtbIgraoOpis;
        private System.Windows.Forms.ListBox lbIgrao;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnBacklogIgram;
        private System.Windows.Forms.Button btnUkloniBacklog;
        private System.Windows.Forms.Button btnIgramIgrao;
        private System.Windows.Forms.Button btnUkloniIgram;
        private System.Windows.Forms.Button btnIgraoIgram;
        private System.Windows.Forms.Button btnUkloniIgrao;
    }
}