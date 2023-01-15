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
            this.tcKartice = new System.Windows.Forms.TabControl();
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
            this.cb_showPass = new System.Windows.Forms.CheckBox();
            this.btnOdustaniPass = new System.Windows.Forms.Button();
            this.btnPotvrdiPass = new System.Windows.Forms.Button();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.lblNewPass = new System.Windows.Forms.Label();
            this.txtOldPass = new System.Windows.Forms.TextBox();
            this.lblOldPass = new System.Windows.Forms.Label();
            this.btnBrisiRac = new System.Windows.Forms.Button();
            this.btnOdjava = new System.Windows.Forms.Button();
            this.btnPromjLoz = new System.Windows.Forms.Button();
            this.lblUkupnoVr = new System.Windows.Forms.Label();
            this.lblPostotak = new System.Windows.Forms.Label();
            this.lblIgrao = new System.Windows.Forms.Label();
            this.lblIgram = new System.Windows.Forms.Label();
            this.lblBacklog = new System.Windows.Forms.Label();
            this.lblPrezime = new System.Windows.Forms.Label();
            this.lblIme = new System.Windows.Forms.Label();
            this.lblKorIme = new System.Windows.Forms.Label();
            this.tcKartice.SuspendLayout();
            this.tpPretraga.SuspendLayout();
            this.tpBacklog.SuspendLayout();
            this.tpIgram.SuspendLayout();
            this.tpIgrao.SuspendLayout();
            this.tpProfil.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcKartice
            // 
            this.tcKartice.Controls.Add(this.tpPretraga);
            this.tcKartice.Controls.Add(this.tpBacklog);
            this.tcKartice.Controls.Add(this.tpIgram);
            this.tcKartice.Controls.Add(this.tpIgrao);
            this.tcKartice.Controls.Add(this.tpProfil);
            this.tcKartice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcKartice.Location = new System.Drawing.Point(0, 0);
            this.tcKartice.Name = "tcKartice";
            this.tcKartice.SelectedIndex = 0;
            this.tcKartice.Size = new System.Drawing.Size(1006, 721);
            this.tcKartice.TabIndex = 1;
            this.tcKartice.SelectedIndexChanged += new System.EventHandler(this.tcKartice_SelectedIndexChanged);
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
            this.btnDodaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodaj.Location = new System.Drawing.Point(481, 346);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(157, 57);
            this.btnDodaj.TabIndex = 4;
            this.btnDodaj.Text = "DODAJ";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // cbZanr
            // 
            this.cbZanr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbZanr.FormattingEnabled = true;
            this.cbZanr.Items.AddRange(new object[] {
            "Svi žanrovi"});
            this.cbZanr.Location = new System.Drawing.Point(481, 80);
            this.cbZanr.Name = "cbZanr";
            this.cbZanr.Size = new System.Drawing.Size(196, 24);
            this.cbZanr.TabIndex = 3;
            this.cbZanr.SelectedIndexChanged += new System.EventHandler(this.cbZanr_SelectedIndexChanged);
            // 
            // rtbOpis
            // 
            this.rtbOpis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbOpis.Location = new System.Drawing.Point(481, 145);
            this.rtbOpis.Name = "rtbOpis";
            this.rtbOpis.ReadOnly = true;
            this.rtbOpis.Size = new System.Drawing.Size(492, 195);
            this.rtbOpis.TabIndex = 2;
            this.rtbOpis.Text = "";
            this.rtbOpis.TextChanged += new System.EventHandler(this.rtbOpis_TextChanged);
            // 
            // lbIgre
            // 
            this.lbIgre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIgre.FormattingEnabled = true;
            this.lbIgre.ItemHeight = 16;
            this.lbIgre.Location = new System.Drawing.Point(26, 145);
            this.lbIgre.Name = "lbIgre";
            this.lbIgre.Size = new System.Drawing.Size(434, 468);
            this.lbIgre.TabIndex = 1;
            this.lbIgre.SelectedIndexChanged += new System.EventHandler(this.lbIgre_SelectedIndexChanged);
            // 
            // txtPretraga
            // 
            this.txtPretraga.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPretraga.Location = new System.Drawing.Point(26, 80);
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
            this.btnBacklogIgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnUkloniBacklog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.rtbBacklogOpis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbBacklogOpis.Location = new System.Drawing.Point(481, 112);
            this.rtbBacklogOpis.Name = "rtbBacklogOpis";
            this.rtbBacklogOpis.ReadOnly = true;
            this.rtbBacklogOpis.Size = new System.Drawing.Size(492, 195);
            this.rtbBacklogOpis.TabIndex = 4;
            this.rtbBacklogOpis.Text = "";
            // 
            // lbBacklog
            // 
            this.lbBacklog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnIgramIgrao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnUkloniIgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.rtbIgramOpis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbIgramOpis.Location = new System.Drawing.Point(481, 112);
            this.rtbIgramOpis.Name = "rtbIgramOpis";
            this.rtbIgramOpis.ReadOnly = true;
            this.rtbIgramOpis.Size = new System.Drawing.Size(492, 195);
            this.rtbIgramOpis.TabIndex = 6;
            this.rtbIgramOpis.Text = "";
            // 
            // lbIgram
            // 
            this.lbIgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnIgraoIgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnUkloniIgrao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.rtbIgraoOpis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbIgraoOpis.Location = new System.Drawing.Point(481, 112);
            this.rtbIgraoOpis.Name = "rtbIgraoOpis";
            this.rtbIgraoOpis.ReadOnly = true;
            this.rtbIgraoOpis.Size = new System.Drawing.Size(492, 195);
            this.rtbIgraoOpis.TabIndex = 6;
            this.rtbIgraoOpis.Text = "";
            // 
            // lbIgrao
            // 
            this.lbIgrao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.tpProfil.Controls.Add(this.cb_showPass);
            this.tpProfil.Controls.Add(this.btnOdustaniPass);
            this.tpProfil.Controls.Add(this.btnPotvrdiPass);
            this.tpProfil.Controls.Add(this.txtNewPass);
            this.tpProfil.Controls.Add(this.lblNewPass);
            this.tpProfil.Controls.Add(this.txtOldPass);
            this.tpProfil.Controls.Add(this.lblOldPass);
            this.tpProfil.Controls.Add(this.btnBrisiRac);
            this.tpProfil.Controls.Add(this.btnOdjava);
            this.tpProfil.Controls.Add(this.btnPromjLoz);
            this.tpProfil.Controls.Add(this.lblUkupnoVr);
            this.tpProfil.Controls.Add(this.lblPostotak);
            this.tpProfil.Controls.Add(this.lblIgrao);
            this.tpProfil.Controls.Add(this.lblIgram);
            this.tpProfil.Controls.Add(this.lblBacklog);
            this.tpProfil.Controls.Add(this.lblPrezime);
            this.tpProfil.Controls.Add(this.lblIme);
            this.tpProfil.Controls.Add(this.lblKorIme);
            this.tpProfil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpProfil.Location = new System.Drawing.Point(4, 25);
            this.tpProfil.Name = "tpProfil";
            this.tpProfil.Size = new System.Drawing.Size(998, 692);
            this.tpProfil.TabIndex = 4;
            this.tpProfil.Text = "PROFIL";
            this.tpProfil.UseVisualStyleBackColor = true;
            this.tpProfil.Click += new System.EventHandler(this.tpProfil_Click);
            // 
            // cb_showPass
            // 
            this.cb_showPass.AutoSize = true;
            this.cb_showPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_showPass.Location = new System.Drawing.Point(34, 592);
            this.cb_showPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_showPass.Name = "cb_showPass";
            this.cb_showPass.Size = new System.Drawing.Size(120, 21);
            this.cb_showPass.TabIndex = 24;
            this.cb_showPass.Text = "Prikaži lozinku";
            this.cb_showPass.UseVisualStyleBackColor = true;
            this.cb_showPass.Visible = false;
            this.cb_showPass.CheckedChanged += new System.EventHandler(this.cb_showPass_CheckedChanged);
            // 
            // btnOdustaniPass
            // 
            this.btnOdustaniPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOdustaniPass.Location = new System.Drawing.Point(138, 626);
            this.btnOdustaniPass.Name = "btnOdustaniPass";
            this.btnOdustaniPass.Size = new System.Drawing.Size(107, 35);
            this.btnOdustaniPass.TabIndex = 23;
            this.btnOdustaniPass.Text = "ODUSTANI";
            this.btnOdustaniPass.UseVisualStyleBackColor = true;
            this.btnOdustaniPass.Visible = false;
            this.btnOdustaniPass.Click += new System.EventHandler(this.btnOdustaniPass_Click);
            // 
            // btnPotvrdiPass
            // 
            this.btnPotvrdiPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPotvrdiPass.Location = new System.Drawing.Point(34, 626);
            this.btnPotvrdiPass.Name = "btnPotvrdiPass";
            this.btnPotvrdiPass.Size = new System.Drawing.Size(98, 35);
            this.btnPotvrdiPass.TabIndex = 22;
            this.btnPotvrdiPass.Text = "POTVRDI";
            this.btnPotvrdiPass.UseVisualStyleBackColor = true;
            this.btnPotvrdiPass.Visible = false;
            this.btnPotvrdiPass.Click += new System.EventHandler(this.btnPotvrdiPass_Click);
            // 
            // txtNewPass
            // 
            this.txtNewPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPass.Location = new System.Drawing.Point(36, 559);
            this.txtNewPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.PasswordChar = '*';
            this.txtNewPass.Size = new System.Drawing.Size(209, 23);
            this.txtNewPass.TabIndex = 21;
            this.txtNewPass.Visible = false;
            // 
            // lblNewPass
            // 
            this.lblNewPass.AutoSize = true;
            this.lblNewPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPass.Location = new System.Drawing.Point(36, 532);
            this.lblNewPass.Name = "lblNewPass";
            this.lblNewPass.Size = new System.Drawing.Size(89, 17);
            this.lblNewPass.TabIndex = 20;
            this.lblNewPass.Text = "Nova lozinka";
            this.lblNewPass.Visible = false;
            // 
            // txtOldPass
            // 
            this.txtOldPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldPass.Location = new System.Drawing.Point(36, 499);
            this.txtOldPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtOldPass.Name = "txtOldPass";
            this.txtOldPass.PasswordChar = '*';
            this.txtOldPass.Size = new System.Drawing.Size(209, 23);
            this.txtOldPass.TabIndex = 19;
            this.txtOldPass.Visible = false;
            // 
            // lblOldPass
            // 
            this.lblOldPass.AutoSize = true;
            this.lblOldPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldPass.Location = new System.Drawing.Point(36, 472);
            this.lblOldPass.Name = "lblOldPass";
            this.lblOldPass.Size = new System.Drawing.Size(90, 17);
            this.lblOldPass.TabIndex = 18;
            this.lblOldPass.Text = "Stara lozinka";
            this.lblOldPass.Visible = false;
            // 
            // btnBrisiRac
            // 
            this.btnBrisiRac.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrisiRac.Location = new System.Drawing.Point(805, 599);
            this.btnBrisiRac.Name = "btnBrisiRac";
            this.btnBrisiRac.Size = new System.Drawing.Size(166, 48);
            this.btnBrisiRac.TabIndex = 10;
            this.btnBrisiRac.Text = "IZBRIŠI RAČUN";
            this.btnBrisiRac.UseVisualStyleBackColor = true;
            this.btnBrisiRac.Click += new System.EventHandler(this.btnBrisiRac_Click);
            // 
            // btnOdjava
            // 
            this.btnOdjava.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOdjava.Location = new System.Drawing.Point(805, 34);
            this.btnOdjava.Name = "btnOdjava";
            this.btnOdjava.Size = new System.Drawing.Size(166, 48);
            this.btnOdjava.TabIndex = 9;
            this.btnOdjava.Text = "ODJAVA";
            this.btnOdjava.UseVisualStyleBackColor = true;
            this.btnOdjava.Click += new System.EventHandler(this.btnOdjava_Click);
            // 
            // btnPromjLoz
            // 
            this.btnPromjLoz.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPromjLoz.Location = new System.Drawing.Point(34, 409);
            this.btnPromjLoz.Name = "btnPromjLoz";
            this.btnPromjLoz.Size = new System.Drawing.Size(166, 48);
            this.btnPromjLoz.TabIndex = 8;
            this.btnPromjLoz.Text = "PROMIJENI LOZINKU";
            this.btnPromjLoz.UseVisualStyleBackColor = true;
            this.btnPromjLoz.Click += new System.EventHandler(this.btnPromjLoz_Click);
            // 
            // lblUkupnoVr
            // 
            this.lblUkupnoVr.AutoSize = true;
            this.lblUkupnoVr.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUkupnoVr.Location = new System.Drawing.Point(234, 350);
            this.lblUkupnoVr.Name = "lblUkupnoVr";
            this.lblUkupnoVr.Size = new System.Drawing.Size(163, 39);
            this.lblUkupnoVr.TabIndex = 7;
            this.lblUkupnoVr.Text = "ukupnoVr";
            // 
            // lblPostotak
            // 
            this.lblPostotak.AutoSize = true;
            this.lblPostotak.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostotak.Location = new System.Drawing.Point(234, 274);
            this.lblPostotak.Name = "lblPostotak";
            this.lblPostotak.Size = new System.Drawing.Size(149, 39);
            this.lblPostotak.TabIndex = 6;
            this.lblPostotak.Text = "Postotak";
            // 
            // lblIgrao
            // 
            this.lblIgrao.AutoSize = true;
            this.lblIgrao.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIgrao.Location = new System.Drawing.Point(691, 208);
            this.lblIgrao.Name = "lblIgrao";
            this.lblIgrao.Size = new System.Drawing.Size(95, 39);
            this.lblIgrao.TabIndex = 5;
            this.lblIgrao.Text = "Igrao";
            // 
            // lblIgram
            // 
            this.lblIgram.AutoSize = true;
            this.lblIgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIgram.Location = new System.Drawing.Point(475, 208);
            this.lblIgram.Name = "lblIgram";
            this.lblIgram.Size = new System.Drawing.Size(104, 39);
            this.lblIgram.TabIndex = 4;
            this.lblIgram.Text = "Igram";
            // 
            // lblBacklog
            // 
            this.lblBacklog.AutoSize = true;
            this.lblBacklog.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBacklog.Location = new System.Drawing.Point(234, 208);
            this.lblBacklog.Name = "lblBacklog";
            this.lblBacklog.Size = new System.Drawing.Size(139, 39);
            this.lblBacklog.TabIndex = 3;
            this.lblBacklog.Text = "Backlog";
            // 
            // lblPrezime
            // 
            this.lblPrezime.AutoSize = true;
            this.lblPrezime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrezime.Location = new System.Drawing.Point(27, 88);
            this.lblPrezime.Name = "lblPrezime";
            this.lblPrezime.Size = new System.Drawing.Size(142, 39);
            this.lblPrezime.TabIndex = 2;
            this.lblPrezime.Text = "Prezime";
            // 
            // lblIme
            // 
            this.lblIme.AutoSize = true;
            this.lblIme.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIme.Location = new System.Drawing.Point(29, 32);
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(74, 39);
            this.lblIme.TabIndex = 1;
            this.lblIme.Text = "Ime";
            // 
            // lblKorIme
            // 
            this.lblKorIme.AutoSize = true;
            this.lblKorIme.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKorIme.Location = new System.Drawing.Point(27, 144);
            this.lblKorIme.Name = "lblKorIme";
            this.lblKorIme.Size = new System.Drawing.Size(121, 39);
            this.lblKorIme.TabIndex = 0;
            this.lblKorIme.Text = "korIme";
            // 
            // MainUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.tcKartice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "MainUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainUser_Load);
            this.tcKartice.ResumeLayout(false);
            this.tpPretraga.ResumeLayout(false);
            this.tpPretraga.PerformLayout();
            this.tpBacklog.ResumeLayout(false);
            this.tpIgram.ResumeLayout(false);
            this.tpIgrao.ResumeLayout(false);
            this.tpProfil.ResumeLayout(false);
            this.tpProfil.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcKartice;
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
        private System.Windows.Forms.Label lblPrezime;
        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.Label lblKorIme;
        private System.Windows.Forms.Label lblPostotak;
        private System.Windows.Forms.Label lblIgrao;
        private System.Windows.Forms.Label lblIgram;
        private System.Windows.Forms.Label lblBacklog;
        private System.Windows.Forms.Label lblUkupnoVr;
        private System.Windows.Forms.Button btnBrisiRac;
        private System.Windows.Forms.Button btnOdjava;
        private System.Windows.Forms.Button btnPromjLoz;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Label lblNewPass;
        private System.Windows.Forms.TextBox txtOldPass;
        private System.Windows.Forms.Label lblOldPass;
        private System.Windows.Forms.Button btnOdustaniPass;
        private System.Windows.Forms.Button btnPotvrdiPass;
        private System.Windows.Forms.CheckBox cb_showPass;
    }
}