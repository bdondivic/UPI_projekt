using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Test;

namespace Backlog
{

    public partial class MainUser : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OlEDB.4.0;Data Source=db_Backlog.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        Korisnik korisnik;
        public MainUser()
        {
            InitializeComponent();
        }

        public MainUser(string uname, string pass, int ID) ////OVERLOAD KONTRUKTOS
        {
            InitializeComponent();

            List<ListBox> liste = new List<ListBox>();
            liste.Add(lbBacklog);
            liste.Add(lbIgram);
            liste.Add(lbIgrao);

            List<RichTextBox> opisi = new List<RichTextBox>();
            opisi.Add(rtbBacklogOpis);
            opisi.Add(rtbIgramOpis);
            opisi.Add(rtbIgraoOpis);

            List<Label> labele = new List<Label>();
            labele.Add(lblBacklog);
            labele.Add(lblIgram);
            labele.Add(lblIgrao);
            labele.Add(lblPostotak);
            labele.Add(lblUkupnoVr);


            this.korisnik = new Korisnik(uname, pass, ID, liste, opisi, labele);
        }

        Pretraga pretraga = new Pretraga();

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            lbIgre.Items.Clear();
            pretraga.Trazi(lbIgre, listIgre, cbZanr, txtPretraga);
        }

        List<Igra> listIgre=new List<Igra>(); 
        private void MainUser_Load(object sender, EventArgs e)
        {
            listIgre = pretraga.LoadIgre(lbIgre);
            ///INICIJALNO UČITAVANJE U LISTBOXOVE (BACKLOG, IGRAM, IGRAO) IZ BP
            korisnik.dohvatiBacklog();   
            korisnik.dohvatiIgram();
            korisnik.dohvatiIgrao();
            List<string> zanrovi = pretraga.UcitajZanrove();
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
            pretraga.UcitajOpis(rtbOpis, cbZanr, gameName);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rtbOpis_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbZanr_SelectedIndexChanged(object sender, EventArgs e)
        {
            pretraga.Trazi(lbIgre, listIgre, cbZanr, txtPretraga);
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
            con.Open();
            string naredba = $"SELECT * FROM Tb_Korisnik_Igra WHERE Korisnik_ID=" +
                $"(SELECT ID_Korisnik from tb_Korisnik WHERE KorisnIme='{korisnik.uName}')" +
                $"AND Igra_ID=(SELECT ID_igra from tb_Igra WHERE Naziv='{nazivIgre}')";
            cmd = new OleDbCommand(naredba, con);
            OleDbDataReader odg = cmd.ExecuteReader();
            if (odg.Read() == true)
            {
                con.Close();
                MessageBox.Show("Zapis sa obabranom igrom već postoji!");
                return;
            }
            con.Close();

            //OTVARANJE FORME ZA DODAVANJE
            Add add = new Add(nazivIgre, ref korisnik);
            add.ShowDialog();
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
                korisnik.UkloniBacklog(nazivIgre);
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
                korisnik.UkloniIgram(nazivIgre);
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
                korisnik.UkloniIgrao(nazivIgre);
            }    
        }

        private void lbBacklog_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lbBacklog.SelectedIndex != -1)
            {
                string nazivIgre = lbBacklog.SelectedItem.ToString();
                korisnik.dohvatiOpis(nazivIgre, "BACKLOG");
            }
            
        }

        private void lbIgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lbIgram.SelectedIndex != -1)
            {
                string nazivIgre = lbIgram.SelectedItem.ToString();
                korisnik.dohvatiOpis(nazivIgre, "IGRAM");
            }
            
        }

        private void lbIgrao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbIgrao.SelectedIndex != -1)
            {
                string nazivIgre = lbIgrao.SelectedItem.ToString();
                korisnik.dohvatiOpis(nazivIgre, "IGRAO");
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
            MoveTo move = new MoveTo("backlogIgram", nazivIgre, ref korisnik);
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
            MoveTo move = new MoveTo("igramIgrao", nazivIgre, ref korisnik);
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
            MoveTo move = new MoveTo("igraoIgram", nazivIgre, ref korisnik);
            move.ShowDialog();
        }

        private void tcKartice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcKartice.SelectedIndex == 4)
            {
                korisnik.korStatistika();
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

        public void sakrijKontrole()
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
            if(staraLoz == "" || novaLoz == "")
            {
                MessageBox.Show("Polja za staru i novu lozinku ne mogu biti prazna!");
                return;
            }
            else if (staraLoz != korisnik.pass)
            {
                MessageBox.Show("Neispravna stara lozinka!");
                return;
            }
            else if(novaLoz.Length<6 || novaLoz.Length > 20)
            {
                MessageBox.Show("Lozinka mora sadržavati između 6 i 20 znakova!");
                return;
            }
            else if (novaLoz == staraLoz)
            {
                MessageBox.Show("Nova lozinka ne može biti ista poput stare loznike!");
                return;
            }
            bool uspjeh = korisnik.promijeniPass(novaLoz);
            if (uspjeh)
            {
                sakrijKontrole();
            }
        }

        public void prikaziLogin()
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
                bool uspjeh = korisnik.izbrisiRacun();
                if (uspjeh)
                {
                    prikaziLogin();
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
    }
}
