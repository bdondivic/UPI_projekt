using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Backlog
{

    public partial class MainUser : Form
    {
        public PretragaIgara pretragaIgara { get; private set; }
        public Korisnik korisnik;

        public List<ListBox> liste { get; private set; }
        public List<Label> labele { get; private set; }

        public List<Igra> listIgre { get; private set; }

        public MainUser()
        {
            InitializeComponent();
        }

        public MainUser(string name, string sur, string uname, string pass, int ID) ////OVERLOAD KONSTRUKTOR
        {
            InitializeComponent();

            liste = new List<ListBox>();
            liste.Add(lbBacklog);
            liste.Add(lbIgram);
            liste.Add(lbIgrao);

            labele = new List<Label>();
            labele.Add(lblBacklog);
            labele.Add(lblIgram);
            labele.Add(lblIgrao);
            labele.Add(lblPostotak);
            labele.Add(lblUkupnoVr);


            this.korisnik = new Korisnik(name, sur, uname, pass, ID);
            this.listIgre = new List<Igra>();
            this.korisnik.posljPrijava();
            this.pretragaIgara = new PretragaIgara();
        }

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            lbIgre.Items.Clear();
            List<Igra> igre = pretragaIgara.Trazi(listIgre, cbZanr.SelectedIndex, txtPretraga.Text);
            foreach (Igra i in igre)
                lbIgre.Items.Add(i.naziv);
        }


        private void MainUser_Load(object sender, EventArgs e)
        {
            listIgre = pretragaIgara.LoadIgre();
            foreach (Igra i in listIgre)
            {
                lbIgre.Items.Add(i.naziv);
            }
            ///INICIJALNO UČITAVANJE U LISTBOXOVE (BACKLOG, IGRAM, IGRAO) IZ BP
            korisnik.dohvatiBacklog(lbBacklog);
            korisnik.dohvatiIgram(lbIgram);
            korisnik.dohvatiIgrao(lbIgrao);
            List<string> zanrovi = pretragaIgara.UcitajZanrove();
            foreach (string zanr in zanrovi)
            {
                cbZanr.Items.Add(zanr);
            }
            cbZanr.SelectedIndex = 0;
            CueProvider.SetCue(txtPretraga, "Pretraži listu igara");
            korisnik.podaciKor(lblIme, lblPrezime, lblKorIme);
        }

        private void lbIgre_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gameName = lbIgre.SelectedItem.ToString();
            rtbOpis.Clear();
            List<object> lista = pretragaIgara.UcitajOpis(gameName);

            rtbOpis.AppendText($"Naziv: {lista[0]}\n");
            rtbOpis.AppendText($"Platforma: {lista[1]}\n");
            rtbOpis.AppendText($"Godina: {lista[2]}\n");
            rtbOpis.AppendText($"Žanr: {cbZanr.Items[(int)lista[3]]}\n");
            rtbOpis.AppendText($"Izdavač: {lista[4]}\n");
            rtbOpis.AppendText($"NA sales: {lista[5]}\n");
            rtbOpis.AppendText($"EU sales: {lista[6]}\n");
            rtbOpis.AppendText($"JP sales: {lista[7]}\n");
            rtbOpis.AppendText($"Other sales: {lista[8]}\n");
            rtbOpis.AppendText($"Global sales: {lista[9]}\n");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rtbOpis_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbZanr_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbIgre.Items.Clear();
            List<Igra> igre =  pretragaIgara.Trazi(listIgre, cbZanr.SelectedIndex, txtPretraga.Text);
            foreach (Igra i in igre)
                lbIgre.Items.Add(i.naziv);
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (lbIgre.SelectedIndex == -1)
            {
                MessageBox.Show("Niste odabrali igru koju želite dodati!");
                return;

            }
            //PROVJERAVA POSTOJI LI IGRA VEĆ U JEDNOJ OD LISTA
            string nazivIgre = lbIgre.SelectedItem.ToString();
            bool postoji = korisnik.postojiZapis(nazivIgre);

            //OTVARANJE FORME ZA DODAVANJE
            if (!postoji)
            {
                Add add = new Add(nazivIgre, ref korisnik, liste);
                add.ShowDialog();
            }

        }


        //UKLANJANJE IGARA IZ LISTI
        private void btnUkloniBacklog_Click(object sender, EventArgs e)
        {
            if (lbBacklog.SelectedIndex == -1)
            {
                MessageBox.Show("Niste odabrali koju igru želite ukloniti!");
                return;
            }
            DialogResult dr = MessageBox.Show("Potvrđujete li unklanjanje odabrane igre?", "Potvrda", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                string nazivIgre = lbBacklog.SelectedItem.ToString();
                korisnik.UkloniBacklog(nazivIgre, lbBacklog, rtbBacklogOpis);
            }
        }

        private void btnUkloniIgram_Click(object sender, EventArgs e)
        {
            if (lbIgram.SelectedIndex == -1)
            {
                MessageBox.Show("Niste odabrali koju igru želite ukloniti!");
                return;
            }
            DialogResult dr = MessageBox.Show("Potvrđujete li unklanjanje odabrane igre?", "Potvrda", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                string nazivIgre = lbIgram.SelectedItem.ToString();
                korisnik.UkloniIgram(nazivIgre, lbIgram, rtbIgramOpis);
            }
        }

        private void btnUkloniIgrao_Click(object sender, EventArgs e)
        {
            if (lbIgrao.SelectedIndex == -1)
            {
                MessageBox.Show("Niste odabrali koju igru želite ukloniti!");
                return;
            }
            DialogResult dr = MessageBox.Show("Potvrđujete li unklanjanje odabrane igre?", "Potvrda", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                string nazivIgre = lbIgrao.SelectedItem.ToString();
                korisnik.UkloniIgrao(nazivIgre, lbIgrao, rtbIgraoOpis);
            }
        }

        private void lbBacklog_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbBacklog.SelectedIndex != -1)
            {
                string nazivIgre = lbBacklog.SelectedItem.ToString();
                korisnik.dohvatiOpis(nazivIgre, "BACKLOG", rtbBacklogOpis);
            }

        }

        private void lbIgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbIgram.SelectedIndex != -1)
            {
                string nazivIgre = lbIgram.SelectedItem.ToString();
                korisnik.dohvatiOpis(nazivIgre, "IGRAM", rtbIgramOpis);
            }

        }

        private void lbIgrao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbIgrao.SelectedIndex != -1)
            {
                string nazivIgre = lbIgrao.SelectedItem.ToString();
                korisnik.dohvatiOpis(nazivIgre, "IGRAO", rtbIgraoOpis);
            }

        }

        private void btnBacklogIgram_Click(object sender, EventArgs e)
        {
            if (lbBacklog.SelectedIndex == -1)
            {
                MessageBox.Show("Niste odabrali koju igru želite prenijeti");
                return;
            }

            string nazivIgre = lbBacklog.SelectedItem.ToString();
            MoveTo move = new MoveTo("backlogIgram", nazivIgre, ref korisnik, liste);
            move.ShowDialog();
        }

        private void btnIgramIgrao_Click(object sender, EventArgs e)
        {
            if (lbIgram.SelectedIndex == -1)
            {
                MessageBox.Show("Niste odabrali koju igru želite prenijeti");
                return;
            }

            string nazivIgre = lbIgram.SelectedItem.ToString();
            MoveTo move = new MoveTo("igramIgrao", nazivIgre, ref korisnik, liste);
            move.ShowDialog();

        }

        private void btnIgraoIgram_Click(object sender, EventArgs e)
        {
            if (lbIgrao.SelectedIndex == -1)
            {
                MessageBox.Show("Niste odabrali koju igru želite prenijeti");
                return;
            }

            string nazivIgre = lbIgrao.SelectedItem.ToString();
            MoveTo move = new MoveTo("igraoIgram", nazivIgre, ref korisnik, liste);
            move.ShowDialog();
        }

        private void tcKartice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcKartice.SelectedIndex == 4)
            {
                List<string> lista = korisnik.korStatistika();
                for (int i = 0; i < labele.Count; i++) 
                    labele[i].Text = lista[i];
            }
        }

        private void btnPromjLoz_Click(object sender, EventArgs e)
        {
            lblOldPass.Visible = true;
            lblNewPass.Visible = true;
            txtOldPass.Visible = true;
            txtNewPass.Visible = true;
            btnPotvrdiPass.Visible = true;
            btnOdustaniPass.Visible = true;
            cb_showPass.Visible = true;
            btnPromjLoz.Visible = false;
        }

        private void sakrijKontrole()
        {
            lblOldPass.Visible = false;
            lblNewPass.Visible = false;
            txtOldPass.Visible = false;
            txtOldPass.Clear();
            txtNewPass.Clear();
            txtNewPass.Visible = false;
            cb_showPass.Checked = false;
            btnPotvrdiPass.Visible = false;
            btnOdustaniPass.Visible = false;
            cb_showPass.Visible = false;
            btnPromjLoz.Visible = true;
        }

        private void btnOdustaniPass_Click(object sender, EventArgs e)
        {
            sakrijKontrole();
        }

        private void btnPotvrdiPass_Click(object sender, EventArgs e)
        {
            string staraLoz = txtOldPass.Text.Trim();
            string novaLoz = txtNewPass.Text.Trim();
            if (staraLoz == "" || novaLoz == "")
            {
                MessageBox.Show("Polja za staru i novu lozinku ne mogu biti prazna!");
                return;
            }
            else if (staraLoz != korisnik.pass)
            {
                MessageBox.Show("Neispravna stara lozinka!");
                return;
            }
            else if (novaLoz.Length < 6 || novaLoz.Length > 20)
            {
                MessageBox.Show("Lozinka mora sadržavati između 6 i 20 znakova!");
                return;
            }
            else if (novaLoz == staraLoz)
            {
                MessageBox.Show("Nova lozinka ne može biti ista poput stare loznike!");
                return;
            }
            string message = korisnik.promijeniPass(novaLoz);
            MessageBox.Show(message);
            if (message == "Loznika je uspješno izmijenjena!")
            {
                sakrijKontrole();
            }
        }

        private void prikaziLogin()
        {
            this.Hide();
            var Login = new Login();
            Login.Closed += (s, args) => this.Close();
            Login.Show();
        }

        private void btnOdjava_Click(object sender, EventArgs e)
        {
            prikaziLogin();
        }

        private void btnBrisiRac_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Potvrđujete li brisanje korisničkog računa?", "Potvrda", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                string message = korisnik.izbrisiRacun();
                MessageBox.Show(message);
                if (message == "Račun je uspješno izbrisan!")
                {
                    sakrijKontrole();
                }
            }
        }

        private void cb_showPass_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_showPass.Checked)
            {
                txtOldPass.PasswordChar = '\0';
                txtNewPass.PasswordChar = '\0';
            }
            else
            {
                txtOldPass.PasswordChar = '*';
                txtNewPass.PasswordChar = '*';
            }
        }

        private void tpProfil_Click(object sender, EventArgs e)
        {

        }
    }
}
