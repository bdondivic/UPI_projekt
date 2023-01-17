using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Backlog
{
    public partial class MainAdmin : Form
    {
        public PretragaKorisnika pretragaKorisnika { get; private set; }
        public List<Korisnik> korisnici { get; private set; }
        public Admin admin { get; private set; }
        public MainAdmin()
        {
            InitializeComponent();
            pretragaKorisnika = new PretragaKorisnika();
            admin = new Admin();

        }

        private void MainAdmin_Load(object sender, EventArgs e)
        {
            ActiveControl = lbKorisnici;
            CueProvider.SetCue(txtPretraga, "Pretraži korisnike");
            korisnici = pretragaKorisnika.ucitajKorisnike();
            foreach (Korisnik k in korisnici)
                lbKorisnici.Items.Add(k.uName);
        }

        private void lbKorisnici_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbKorisnici.SelectedIndex != -1)
            {
                rtbInf.Clear();
                string uName = lbKorisnici.SelectedItem.ToString();
                List<object> lista = pretragaKorisnika.ucitajInf(uName);

                rtbInf.AppendText("Ime: " + lista[0] + "\n");
                rtbInf.AppendText("Prezime: " + lista[1] + "\n");
                rtbInf.AppendText("Korisničko ime: " + lista[2] + "\n");
                rtbInf.AppendText("Lozinka: " + lista[3] + "\n");
                rtbInf.AppendText("Datum registracije: " + lista[4] + "\n");
                rtbInf.AppendText("Posljednja prijava: " + lista[5] + "\n");

                rtbInf.AppendText("Backlog: " + lista[6] + "\n");
                rtbInf.AppendText("Igram: " + lista[7] + "\n");
                rtbInf.AppendText("Igrao: " + lista[8] + "\n");
            }
        }

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            string text = txtPretraga.Text;
            lbKorisnici.Items.Clear();
            List<Korisnik> lista = pretragaKorisnika.Trazi(korisnici, text);
            foreach (Korisnik k in lista)
            {
                lbKorisnici.Items.Add(k.uName);
            }

        }

        private void btnPreuzPodKor_Click(object sender, EventArgs e)
        {
            string uName = lbKorisnici.SelectedItem.ToString();
            admin.preuzmiPodKor(uName);
        }

        private void btnBrisiRacun_Click(object sender, EventArgs e)
        {
            if (lbKorisnici.SelectedIndex == -1)
            {
                MessageBox.Show("Niste odabrali koji korisnički račun želite izbrisati!");
                return;
            }
            DialogResult dr = MessageBox.Show("Potvrđujete li brisanje korisničkog računa?", "Potvrda", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                string uName = lbKorisnici.SelectedItem.ToString();
                admin.izbrisiRacun(lbKorisnici, rtbInf, korisnici, uName);
            }
        }

        private void btnPreuzKorSvi_Click(object sender, EventArgs e)
        {
            admin.preuzmiPodSvi();
        }

        private void btnOdjava_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Login = new Login();
            Login.Closed += (s, args) => this.Close();
            Login.Show();
        }
    }
}
