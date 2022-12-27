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
            this.korisnik = new Korisnik(uname, pass, ID, liste);
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
    }
}
