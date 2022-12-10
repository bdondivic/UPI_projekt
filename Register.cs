using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Test;

namespace Backlog
{
    public partial class Register : Form
    {
        public Register()
        {
     
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OlEDB.4.0;Data Source=db_Backlog.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        
        private void Register_Load(object sender, EventArgs e)
        {

        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            string ime = txtName.Text.Trim();
            string prezime = txtSurname.Text.Trim();
            string uName = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();
            string passConf = txtConfirmPass.Text.Trim();
            Registracija reg = new Registracija(ime, prezime, uName, pass, passConf);
            

            bool isprPod = reg.Provjera();
            //if (ime.Length < 3 || ime.Length > 12)
            //{
            //    MessageBox.Show("Ime mora sadržavati između 3 i 12 znakova!");
            //    return;
            //}
            //if (prezime.Length < 3 || prezime.Length > 12)
            //{
            //    MessageBox.Show("Prezime mora sadržavati između 3 i 12 znakova!");
            //    return;
            //}
            //if (uName.Length < 5 || uName.Length > 12)
            //{
            //    MessageBox.Show("Korisničko ime mora sadržavati između 5 i 12 znakova!");
            //    return;
            //}
            //if (pass.Length < 6 || pass.Length > 20)
            //{
            //    MessageBox.Show("Lozinka mora sadržavati između 5 i 20 znakova!");
            //    return;
            //}
            //if (pass != passConf)
            //{
            //    MessageBox.Show("Lozinka se moraju podudarati!");
            //    return;
            //}
            if (isprPod == true)
            {

                if (reg.uNameZauzet() == true)
                {
                    return;
                }
                //try
                //{
                //    con.Open();
                //    string naredba = $"SELECT * FROM tb_Korisnik WHERE KorisnIme='{uName}'";
                //    cmd = new OleDbCommand(naredba, con);
                //    OleDbDataReader odg = cmd.ExecuteReader();
                //    if (odg.Read() == true)
                //    {
                //        MessageBox.Show("Korisničko ime nije dostupno jer ga koristi drugi korinik!");
                //        con.Close();
                //        return;
                //    }
                //    con.Close();

                //}
                //catch (Exception exp)
                //{
                //    MessageBox.Show(exp.ToString());
                //}

                reg.noviKorisnik(this);
                //try
                //{
                //    con.Open();
                //    string naredba = $"INSERT INTO tb_Korisnik (Ime, Prezime, KorisnIme, Lozinka, JeAdmin) VALUES ('{ime}', '{prezime}', '{uName}', '{pass}', {0})";
                //    cmd = new OleDbCommand(naredba, con);
                //    cmd.ExecuteNonQuery();
                //    con.Close();
                //    MessageBox.Show("Registracija je bila uspješna!");
                //    this.Hide();
                //    var Login = new Login();
                //    Login.Closed += (s, args) => this.Close();
                //    Login.Show();

                //}
                //catch (Exception exp)
                //{
                //    MessageBox.Show(exp.ToString());
                //}

            }
        }

        private void cb_showPass_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_showPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtConfirmPass.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
                txtConfirmPass.PasswordChar = '*';
            }
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Login = new Login();
            Login.Closed += (s, args) => this.Close();
            Login.Show();

        }
    }
}
