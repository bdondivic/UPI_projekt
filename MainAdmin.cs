using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Test;

namespace Backlog
{
    public partial class MainAdmin : Form
    {
        PretragaKorisnika pretragaKorisnika;
        List<Korisnik> korisnici;
        Admin admin;
        public MainAdmin()
        {
            InitializeComponent();
            pretragaKorisnika = new PretragaKorisnika();
            admin = new Admin();

        }

        private void MainAdmin_Load(object sender, EventArgs e)
        {
            korisnici = pretragaKorisnika.ucitajKorisnike(lbKorisnici);
        }

        private void lbKorisnici_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbKorisnici.SelectedIndex!=-1)
            {
                string uName = lbKorisnici.SelectedItem.ToString();
                pretragaKorisnika.ucitajInf(rtbInf, uName);
            }
        }

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            pretragaKorisnika.Trazi(lbKorisnici, korisnici, txtPretraga);
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
                admin.izbrisiRacun(lbKorisnici, rtbInf, uName);
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
